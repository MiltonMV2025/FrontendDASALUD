using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FrontendDASALUD.Services
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string route, CancellationToken ct = default);
        Task<T?> PostAsync<T>(string route, object body, CancellationToken ct = default);
        Task<HttpResponseMessage> PostRawAsync(string route, object body, CancellationToken ct = default);
        Task<HttpResponseMessage> PutRawAsync(string route, object body, CancellationToken ct = default);
        Task<HttpResponseMessage> DeleteAsync(string route, CancellationToken ct = default);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _auth;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService(HttpClient http, IAuthService auth)
        {
            _http = http;
            _auth = auth;
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };
        }

        private async Task EnsureAuthHeaderAsync()
        {
            var token = await _auth.GetTokenAsync();
            
            _http.DefaultRequestHeaders.Authorization = null;
            
            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<T?> GetAsync<T>(string route, CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();
            
            var response = await _http.GetAsync(route, ct);
            
            if (!response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAsync: {response.StatusCode}");
                return default;
            }
            
            var content = await response.Content.ReadAsStringAsync(ct);
            System.Diagnostics.Debug.WriteLine($"JSON recibido de {route}: {content}");
            
            var result = JsonSerializer.Deserialize<T>(content, _jsonOptions);
            return result;
        }

        public async Task<T?> PostAsync<T>(string route, object body, CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();
            var res = await _http.PostAsJsonAsync(route, body, _jsonOptions, ct);
            if (!res.IsSuccessStatusCode) return default;
            
            var content = await res.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<T>(content, _jsonOptions);
        }

        public async Task<HttpResponseMessage> PostRawAsync(string route, object body, CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();
            return await _http.PostAsJsonAsync(route, body, _jsonOptions, ct);
        }

        public async Task<HttpResponseMessage> PutRawAsync(string route, object body, CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();
            return await _http.PutAsJsonAsync(route, body, _jsonOptions, ct);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string route, CancellationToken ct = default)
        {
            await EnsureAuthHeaderAsync();
            return await _http.DeleteAsync(route, ct);
        }
    }
}
