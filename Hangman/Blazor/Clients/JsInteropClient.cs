using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.Clients
{
    public class JsInteropClient
    {
        private readonly IJSRuntime jSRuntime;

        public JsInteropClient(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task<string> GetSessionStorage(string key)
        {
            return await jSRuntime.InvokeAsync<string>("sessionStorageManager.get", key);
        }

        public async Task<bool> SetSessionStorage(string key, string value)
        {
            return await jSRuntime.InvokeAsync<bool>("sessionStorageManager.set", key, value);
        }

        public async Task<bool> RemoveSessionStorageItem(string key)
        {
            return await jSRuntime.InvokeAsync<bool>("sessionStorageManager.remove", key);
        }
    }
}
