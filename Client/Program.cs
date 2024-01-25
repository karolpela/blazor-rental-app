using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using RentalApp.Client;
using RentalApp.Shared.Converters;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
Console.Write(builder.HostEnvironment.Environment);
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configure JSON serializer for use with HttpClient,
// which does not use the default serializer settings,
// therefore the options are injected and passed as a parameter on the appropriate pages.
builder.Services.Configure<JsonSerializerOptions>(options =>
{
    // options.Converters.Add(new SportsEquipmentConverter());
    // Use web defaults
    options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.PropertyNameCaseInsensitive = true;
    options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
});

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();