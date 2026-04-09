using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;
using WebApp.Service;
using WebApp.Pages;

using Blazored.LocalStorage;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Skift ItemServiceMock til ItemServiceHttp for at tale med server
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Config.ServerUrl) });
builder.Services.AddScoped<IItemService, ItemServiceHttp>();
builder.Services.AddSingleton<LoginService>();

await builder.Build().RunAsync();
