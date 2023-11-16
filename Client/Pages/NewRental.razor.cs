using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using NuGet.Packaging;
using Radzen;
using Radzen.Blazor;
using RentalApp.Shared.Models;
using RentalApp.Shared.Models.Equipment;

namespace RentalApp.Client.Pages;

public partial class NewRental
{
    private readonly Dictionary<string, decimal> gearPerDay = new()
    {
        { "Helmet", 10m },
        { "KneePads", 5m },
        { "Gloves", 5m }
    };

    private Person? _client;
    private SportsEquipment? _equipment;

    private Person[]? allClients;

    private SportsEquipment[]? availableEquipment;

    private ProtectiveGear[]? availableGear;

    private bool insuranceWanted;

    private string? pesel;

    private bool peselInSystem;

    // Data

    private Rental? rental;

    // There's no second selector so set seconds to 0

    private DateTimeOffset scheduledEndDate =
        DateTimeOffset.UtcNow.AddDays(1).AddSeconds(-DateTimeOffset.UtcNow.Second);

    private IEnumerable<int> selectedGear = Array.Empty<int>();

    private DateTimeOffset startDate = DateTimeOffset.UtcNow.AddSeconds(-DateTimeOffset.UtcNow.Second);

    private RadzenTemplateForm<Rental>? templateForm;

    // Fields used to create new rental
    private Person? Client
    {
        get => _client;
        set
        {
            _client = value;
            CreateOrUpdateRental();
        }
    }

    private SportsEquipment? Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            CreateOrUpdateRental();
        }
    }

    [Inject] protected IOptions<JsonSerializerOptions> JsonOptions { get; set; } = default!;

    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected DialogService DialogService { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private int TotalHours => (int)Math.Ceiling((scheduledEndDate - startDate).TotalHours);
    private int TotalDays => (int)Math.Ceiling((scheduledEndDate - startDate).TotalDays);

    private bool InsuranceWanted
    {
        get => insuranceWanted;
        set
        {
            if (rental != null)
            {
                if (value)
                {
                    rental.Insurance = new Insurance(rental);
                    rental.Insurance.CalculateCost();
                }
                else
                {
                    rental.Insurance = null;
                }
            }

            insuranceWanted = value;
            templateForm?.EditContext?.Validate();
        }
    }

    private decimal DailyEquipmentCost => (Equipment?.HourlyFee ?? 0) * 24;

    private decimal TotalEquipmentCost => (Equipment?.HourlyFee ?? 0) * TotalHours;

    private decimal DailyInsuranceCost => rental?.Insurance?.Cost ?? 0;

    private decimal TotalInsuranceCost => DailyInsuranceCost * TotalDays;

    private decimal DailyGearCost
    {
        get
        {
            var cost = 0m;
            if (!selectedGear.IsNullOrEmpty())
                cost = availableGear?.Where(pg => selectedGear.Contains(pg.Id))
                    .Select(pg => gearPerDay[pg.Type])
                    .Sum() ?? 0;
            return cost;
        }
    }

    private decimal? TotalGearCost => DailyGearCost * TotalDays;

    private decimal? TotalRentalCost => TotalEquipmentCost + TotalInsuranceCost + TotalGearCost;

    protected override async Task OnInitializedAsync()
    {
        allClients = await Http.GetFromJsonAsync<Person[]>("api/People?role=client&sort=firstName");
        availableGear = await Http.GetFromJsonAsync<ProtectiveGear[]>("api/ProtectiveGear?availableOnly=true");
        availableEquipment = await Http.GetFromJsonAsync<SportsEquipment[]>("api/Equipment?availableOnly=true",
            JsonOptions.Value);
    }

    private void CreateOrUpdateRental()
    {
        // Do nothing if either client or equipment are not yet selected
        if (Client == null || Equipment == null) return;
        // Do nothing if client or equipment haven't changed
        if (rental?.Client == Client && rental?.Equipment == Equipment) return;

        if (rental == null)
        {
            // Create if rental not initialized
            rental = new Rental(Client, Equipment, startDate, scheduledEndDate, null, false);
        }
        else
        {
            // If initialized only assign properties
            rental.Client = Client;
            rental.Equipment = Equipment;
        }
    }

    private async Task AddRentalAsync()
    {
        if (rental == null) return;

        // Add objects for currently selected gear
        var gearToAdd = availableGear?.Where(pg => selectedGear.Contains(pg.Id)).ToList();
        rental.ProtectiveGear.AddRange(gearToAdd);

        // Add PESEL if not in system
        if (!peselInSystem) rental.Client.Pesel = pesel;

        var response = await Http.PostAsJsonAsync("api/Rentals", rental, JsonOptions.Value);

        if (response.IsSuccessStatusCode)
        {
            var returnToDashboard = await DialogService.Alert("Rental created!", "Success",
                new AlertOptions { OkButtonText = "Return" });
            if (returnToDashboard ?? false) NavigationManager.NavigateTo("/");
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            {
                await DialogService.Alert(error?.Message, "Error",
                    new AlertOptions { OkButtonText = "OK" });
            }
        }
    }
}