using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MinApp.Client;
using MinApp.Client.Services;
using MinApp.Core.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// Brug MockService under udvikling - skift til ProductionService for at tale med server
builder.Services.AddScoped<IService, MockService>();

await builder.Build().RunAsync();
