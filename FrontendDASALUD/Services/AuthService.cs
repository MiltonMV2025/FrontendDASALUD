using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FrontendDASALUD.Models;

namespace FrontendDASALUD.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(UserCredentials creds);
        Task LogoutAsync();
        ValueTask<string?> GetTokenAsync();
        ValueTask<bool> IsAuthenticatedAsync();
        ValueTask<AuthData?> GetUserDataAsync();
    }

    public class AuthService : IAuthService
    {
        private const string TokenKey = "auth_token";
        private const string AuthDataKey = "auth_data";
        private readonly HttpClient _http;
        private readonly ILocalStorageHelper _storage;

        public AuthService(HttpClient http, ILocalStorageHelper storage)
        {
            _http = http;
            _storage = storage;
        }

        public async Task<bool> LoginAsync(UserCredentials creds)
        {
            _http.DefaultRequestHeaders.Authorization = null;
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = "api/Auth/login"; 
            var res = await _http.PostAsJsonAsync(requestUri, creds);

            if (res.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                var body = await res.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"MethodNotAllowed (405) calling '{requestUri}'. Response body: {body}");
            }

            if (!res.IsSuccessStatusCode) return false;

            var apiResp = await res.Content.ReadFromJsonAsync<ApiResponse<AuthData>>();
            if (apiResp?.Data is null) return false;

            var token = apiResp.Data.Token;
            if (string.IsNullOrEmpty(token)) return false;

            await _storage.SetItemAsync(TokenKey, token);
            await _storage.SetItemAsync(AuthDataKey, apiResp.Data);
            return true;
        }

        public async Task LogoutAsync()
        {
            await _storage.RemoveItemAsync(TokenKey);
            await _storage.RemoveItemAsync(AuthDataKey);
            
            _http.DefaultRequestHeaders.Authorization = null;
            _http.DefaultRequestHeaders.Clear();
        }

        public ValueTask<string?> GetTokenAsync() => _storage.GetItemAsync<string>(TokenKey);

        public async ValueTask<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public ValueTask<AuthData?> GetUserDataAsync() => _storage.GetItemAsync<AuthData>(AuthDataKey);
    }
}
