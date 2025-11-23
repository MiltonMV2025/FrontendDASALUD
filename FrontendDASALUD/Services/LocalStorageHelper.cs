using System.Text.Json;
using Microsoft.JSInterop;

namespace FrontendDASALUD.Services
{
    public interface ILocalStorageHelper
    {
        ValueTask SetItemAsync<T>(string key, T item);
        ValueTask<T?> GetItemAsync<T>(string key);
        ValueTask RemoveItemAsync(string key);
    }

    public sealed class LocalStorageHelper : ILocalStorageHelper
    {
        private readonly IJSRuntime _js;
        public LocalStorageHelper(IJSRuntime js) => _js = js;

        public ValueTask SetItemAsync<T>(string key, T item)
            => _js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(item));

        public async ValueTask<T?> GetItemAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string?>("localStorage.getItem", key);
            return json is null ? default : JsonSerializer.Deserialize<T>(json);
        }

        public ValueTask RemoveItemAsync(string key) => _js.InvokeVoidAsync("localStorage.removeItem", key);
    }
}
