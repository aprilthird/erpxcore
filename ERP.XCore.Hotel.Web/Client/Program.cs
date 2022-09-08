using ERP.XCore.Hotel.Web.Client;
using ERP.XCore.Hotel.Web.Client._keenthemes.libs;
using ERP.XCore.Hotel.Web.Client._keenthemes;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ERP.XCore.Hotel.Web.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ERP.XCore.Hotel.Web.ServerAPI"));
builder.Services.AddScoped<IKTTheme, KTTheme>();
builder.Services.AddScoped<IBootstrapBase, BootstrapBase>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
