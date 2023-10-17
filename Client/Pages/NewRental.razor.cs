using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using NuGet.Packaging;
using Radzen;
using Radzen.Blazor;
using RentalApp.Shared.Converters;
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

    private readonly Insurance insurance = new();

    private readonly Rental rental = new(
        DateTimeOffset.MinValue,
        DateTimeOffset.MinValue,
        null,
        false);

    private readonly JsonSerializerOptions serializerOptions = new();
    private bool _insuranceWanted;
    private string? _pesel;

    private IEnumerable<Person>? clients;

    private IEnumerable<SportsEquipment>? equipment;
    private bool peselInSystem;

    private IEnumerable<ProtectiveGear>? protectiveGear;

    private IEnumerable<int> selectedGear = Array.Empty<int>();

    private RadzenTemplateForm<Rental>? templateForm;
    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected DialogService DialogService { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private string? Pesel
    {
        get => _pesel;
        set
        {
            _pesel = value;
            if (rental.Client != null) rental.Client.Pesel = _pesel;
        }
    }

    private int totalHours => (int)Math.Ceiling((rental.ScheduledEndDate - rental.StartDate).TotalHours);
    private int totalDays => (int)Math.Ceiling((rental.ScheduledEndDate - rental.StartDate).TotalDays);

    private bool InsuranceWanted
    {
        get => _insuranceWanted;
        set
        {
            _insuranceWanted = value;
            rental.Insurance = _insuranceWanted
                ? insurance
                : null;
            rental.Insurance?.CalculateCost();
            templateForm?.EditContext.Validate();
        }
    }

    private decimal DailyEquipmentCost => (rental.Equipment?.HourlyFee ?? 0) * 24;

    private decimal TotalEquipmentCost => (rental.Equipment?.HourlyFee ?? 0) * totalHours;

    private decimal DailyInsuranceCost => rental.Insurance?.Cost ?? 0;

    private decimal TotalInsuranceCost => DailyInsuranceCost * totalDays;


    private decimal DailyGearCost
    {
        get
        {
            if (!selectedGear.IsNullOrEmpty())
                return protectiveGear?.Where(pg => selectedGear.Contains(pg.Id)).Select(pg => gearPerDay[pg.Type])
                    .Sum() ?? 0;
            return 0;
        }
    }

    private decimal? TotalGearCost => DailyGearCost * totalDays;

    private decimal? TotalRentalCost => TotalEquipmentCost + TotalInsuranceCost + TotalGearCost;

    protected override async Task OnInitializedAsync()
    {
        serializerOptions.Converters.Add(new SportsEquipmentConverter());

        var now = DateTimeOffset.Now;
        var nowWithoutSeconds = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0, now.Offset);

        rental.StartDate = nowWithoutSeconds;
        rental.ScheduledEndDate = nowWithoutSeconds + TimeSpan.FromDays(1);

        insurance.Rental = rental;

        clients = await Http.GetFromJsonAsync<IEnumerable<Person>>("api/People?role=client&sort=firstName");
        protectiveGear =
            await Http.GetFromJsonAsync<IEnumerable<ProtectiveGear>>("api/ProtectiveGear?availableOnly=true");

        var equipmentResponse = await Http.GetAsync("api/Equipment?availableOnly=true");
        var equipmentJson = await equipmentResponse.Content.ReadAsStringAsync();
        equipment = JsonSerializer.Deserialize<IEnumerable<SportsEquipment>>(equipmentJson, serializerOptions);
    }

    private async Task AddRentalAsync()
    {
        // Add objects for currently selected gear
        var gearToAdd = protectiveGear?.Where(pg => selectedGear.Contains(pg.Id)).ToList();
        rental.ProtectiveGear.AddRange(gearToAdd);

        var rentalJson = JsonSerializer.Serialize(rental, serializerOptions);
        var httpContent = new StringContent(rentalJson, Encoding.UTF8, "application/json");
        var response = await Http.PostAsync("api/Rentals", httpContent);
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