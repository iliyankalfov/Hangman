using Blazor.Clients;
using Blazor.Components;
using Blazor.Shared.Data;
using GameLogic;
using Hangman.GameLogic;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ApiClient>();
            services.AddSingleton<Game>();
            services.AddSingleton<GameTracker>();
            services.AddSingleton<JsInteropClient>();
            services.AddSingleton<SessionClass>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
