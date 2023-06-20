using System.Collections;
using System.Net.Http.Json;
using System.Text.Json;
using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RentalApp.Shared.Converters;
using RentalApp.Shared.Models;
using RentalApp.Shared.Models.Equipment;

namespace RentalApp.Client.Pages;

public partial class NewRental
{
    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private IEnumerable<Person>? clients;

    private IEnumerable<SportsEquipment>? equipment;

    private string pesel = "09328402943";

    private IEnumerable<ProtectiveGear>? protectiveGear;

    private Rental rental = new(
        DateTimeOffset.Now,
        DateTimeOffset.Now,
        null,
        false);

    private IEnumerable<int> selectedGear = Array.Empty<int>();

    private bool _insuranceWanted;

    private Insurance insurance = new Insurance();
    
    private bool InsuranceWanted
    {
        get => _insuranceWanted;
        set
        {
            _insuranceWanted = value;
            rental.Insurance = _insuranceWanted
                ? insurance
                : null;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        clients = await Http.GetFromJsonAsync<IEnumerable<Person>>("api/People?role=client&sort=firstName");
        
        var response = await Http.GetAsync("api/Equipment");
        var responseText = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions();
        options.Converters.Add(new SportsEquipmentConverter());

        equipment = JsonSerializer.Deserialize<IEnumerable<SportsEquipment>>(responseText, options);
        
    }
}