using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2.Frontend;
using Proyecto2.Frontend.Services;
using Proyecto2.Frontend.Services.Auth;
using MudBlazor.Services;
using Microsoft.JSInterop;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient con AuthHeaderHandler personalizado (adjunta token y redirige si 401)
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
        BaseAddress = new Uri("https://localhost:7279/") // Cambia según tu backend
    };
});

// Registro de servicios personalizados
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IAutorService, AutorService>();

// Autenticación y sesión
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, SessionService>();
builder.Services.AddScoped<ISessionService, SessionService>();

// MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();
