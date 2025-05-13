using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Proyecto2.Frontend.Services.Auth;

public class TokenAuthorizationMessageHandler : DelegatingHandler
{
    private readonly NavigationManager _navigation;

    public TokenAuthorizationMessageHandler(NavigationManager navigation)
    {
        _navigation = navigation;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // Redirige al login si el token no es válido
            _navigation.NavigateTo("/login", forceLoad: true);
        }

        return response;
    }
}
