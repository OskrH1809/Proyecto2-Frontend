using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly IJSRuntime _js;
    private readonly NavigationManager _navigation;

    public AuthHeaderHandler(IJSRuntime js, NavigationManager navigation)
    {
        _js = js;
        _navigation = navigation;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // ✅ Leer token del localStorage
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await base.SendAsync(request, cancellationToken);

        // ❌ Si es 401, redirige al login
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");

            // Puedes guardar un mensaje opcional para mostrar después del login
            await _js.InvokeVoidAsync("localStorage.setItem", "authRedirectReason", "expired");

            _navigation.NavigateTo("/login", forceLoad: true);
        }

        return response;
    }
}
