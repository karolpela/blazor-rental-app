using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using RentalApp.Shared.Models;

namespace RentalApp.Client.Pages;

public partial class RegisterClient
{
    private readonly Person client = new(PersonRole.Client, string.Empty, string.Empty);
    private string? badNumber;

    private RadzenTemplateForm<Person>? form;

    [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected DialogService DialogService { get; set; } = default!;

    [Inject] protected HttpClient Http { get; set; } = default!;

    private async Task AddClientAsync()
    {
        var response = await Http.PostAsJsonAsync("api/People", client);
        if (response.IsSuccessStatusCode)
        {
            var returnToDashboard = await DialogService.Alert("Client registered!", "Success",
                new AlertOptions { OkButtonText = "Return" });
            if (returnToDashboard ?? false) NavigationManager.NavigateTo("/");
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            if (error?.Message == "PhoneNumberNotUnique")
                badNumber = client.PhoneNumber!;
            else
                await DialogService.Alert(error?.Message, "Error",
                    new AlertOptions { OkButtonText = "OK" });
        }
    }
}