using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BookMyHome.Web;
using Radzen;
using BookMyHome.Web.Extensions;
using BookMyHome.Web.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var proxyBase = builder.Configuration["ProxyUrl"];

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(proxyBase!) });
builder.Services.AddRadzenComponents();

builder.Services.AddBookMyHomeServices();
builder.Services.AddBookMyHomeState();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(serviceProvider =>
    serviceProvider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();
