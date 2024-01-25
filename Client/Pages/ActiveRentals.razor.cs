using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using RentalApp.Shared.Models;

namespace RentalApp.Client.Pages;

public partial class ActiveRentals
{
    private RadzenDataGrid<Rental>? dataGrid;
    private Rental[]? rentals;

    protected int RentalsCount;

    [Inject] protected IOptions<JsonSerializerOptions> JsonOptions { get; set; } = default!;

    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected NotificationService NotificationService { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private void RentalsLoadData()
    {
        try
        {
            RentalsCount = rentals?.Length ?? 0;
        }
        catch (Exception)
        {
            NotificationService.Notify(new NotificationMessage
                { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Unable to load" });
        }
    }

    private async Task EndRental(Rental rental, bool damaged)
    {
        rental.EndDate = DateTimeOffset.Now;
        rental.EquipmentDamaged = damaged;
        try
        {
            await Http.PutAsJsonAsync($"api/Rentals/{rental.Id}", rental);
            NotificationService.Notify(new NotificationMessage
                { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Rental successfully ended" });

            // Fetch new data from server
            await OnInitializedAsync();
            dataGrid?.Reload();
        }
        catch (Exception)
        {
            NotificationService.Notify(new NotificationMessage
                { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Unable to end" });
        }
    }

    protected override async Task OnInitializedAsync()
    {
        rentals = await Http.GetFromJsonAsync<Rental[]>("api/Rentals?activeOnly=true", JsonOptions.Value);
    }
}