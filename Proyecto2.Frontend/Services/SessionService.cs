using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

public class SessionService : AuthenticationStateProvider, ISessionService
{
    private readonly IJSRuntime _js;
    private readonly NavigationManager _nav;

    private ClaimsPrincipal _usuarioActual = new ClaimsPrincipal(new ClaimsIdentity());

    public SessionService(IJSRuntime js, NavigationManager nav)
    {
        _js = js;
        _nav = nav;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrWhiteSpace(token))
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        // Aquí podrías parsear el token si fuera JWT y extraer los claims reales
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "UsuarioAutenticado")
        }, "jwt");

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public async Task LogoutAsync()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        _nav.NavigateTo("/login", forceLoad: true);
    }

    public void NotifyUsuarioAutenticado(ClaimsPrincipal usuario)
    {
        _usuarioActual = usuario;
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(usuario)));
    }
}
