using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp4;
using BlazorApp4.Pages;
using BlazorApp4.Service;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Config.ServerUrl) });
builder.Services.AddScoped<IItemService, ItemServiceHttp>();
builder.Services.AddScoped<IKøbsanmodningerService, KøbsanmodningerServiceHttp>();
builder.Services.AddScoped<IBrugerService, BrugerServiceHttp>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
