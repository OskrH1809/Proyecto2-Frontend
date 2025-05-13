namespace Proyecto2.Frontend.Auth;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public abstract class ProtectedComponentBase : ComponentBase
{
    [Inject] protected IJSRuntime JS { get; set; }
    [Inject] protected NavigationManager NavManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var token = await JS.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrWhiteSpace(token))
        {
            NavManager.NavigateTo("/login", forceLoad: true);
        }
        else
        {
            await OnAuthenticatedInitializedAsync();
        }
    }

    protected abstract Task OnAuthenticatedInitializedAsync();
}
