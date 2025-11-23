using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontendDASALUD;
using FrontendDASALUD.Services;
using FrontendDASALUD.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

using var configHttp = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
try
{
    using var stream = await configHttp.GetStreamAsync("appsettings.json");
    builder.Configuration.AddJsonStream(stream);
}
catch
{
}


var backendBase = builder.Configuration["Backend:BaseUrl"] ?? builder.HostEnvironment.BaseAddress;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(backendBase) });

builder.Services.AddScoped<ILocalStorageHelper, LocalStorageHelper>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();
