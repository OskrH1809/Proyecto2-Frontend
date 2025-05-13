using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2.Frontend;
using Proyecto2.Frontend.Services;
using Proyecto2.Frontend.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Servicios
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<AuthenticationStateProvider, SessionService>();

// HttpClient con handler personalizado
builder.Services.AddScoped(sp =>
{
    var js = sp.GetRequiredService<IJSRuntime>();
    var nav = sp.GetRequiredService<NavigationManager>();
    var handler = new AuthHeaderHandler(js, nav)
    {
        InnerHandler = new HttpClientHandler()
    };

    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7279/")
    };
});

builder.Services.AddMudServices();

await builder.Build().RunAsync();
