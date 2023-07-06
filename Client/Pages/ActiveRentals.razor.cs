using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using RentalApp.Shared.Converters;
using RentalApp.Shared.Models;

namespace RentalApp.Client.Pages;

public partial class ActiveRentals
{
    protected IEnumerable<Rental> rentals;

    protected int rentalsCount;

    private readonly JsonSerializerOptions serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected NotificationService NotificationService { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private void rentalsLoadData()
    {
        try
        {
            rentalsCount = rentals.Count();
        }
        catch (Exception)
        {
            NotificationService.Notify(new NotificationMessage
                { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "Unable to load" });
        }
    }


    protected override async Task OnInitializedAsync()
    {
        serializerOptions.Converters.Add(new SportsEquipmentConverter());

        var rentalsResponse = await Http.GetAsync("api/Rentals?activeOnly=true");
        var rentalsJson = await rentalsResponse.Content.ReadAsStringAsync();
        rentals = JsonSerializer.Deserialize<IEnumerable<Rental>>(rentalsJson, serializerOptions) ??
                  Array.Empty<Rental>();
    }
}