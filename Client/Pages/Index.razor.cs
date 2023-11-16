using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RentalApp.Client.Pages;

public partial class Index
{
    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        NavigationManager.NavigateTo("active-rentals");
    }
}