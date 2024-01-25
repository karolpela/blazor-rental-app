using System.Text.Json.Serialization;

namespace RentalApp.Shared.Models;

public class Insurance
{
    // For EF Core
    private Insurance()
    {
    }

    // Default constructor
    public Insurance(Rental rental)
    {
        Rental = rental;
    }

    public int Id { get; set; }
    public decimal Cost { get; set; }

    [JsonIgnore] public Rental Rental { get; } = null!;

    public int RentalId { get; set; }

    public void CalculateCost()
    {
        // Base cost according to equipment type
        var cost = Rental.Equipment.Discriminator switch
        {
            "IceSkates" => 10.0m,
            "InlineSkates" => 10.0m,
            "RollerSkates" => 5.0m,
            _ => throw new ArgumentOutOfRangeException()
        };

        // Added cost based on hourly fee
        cost += 0.1m * Rental.Equipment.HourlyFee * 24;

        // Check if client's last 10 rentals were damage-free
        var anyDamaged = Rental.Client.Rentals
            .OrderByDescending(r => r.StartDate)
            .Take(10)
            .Any(r => r.EquipmentDamaged);

        if (!anyDamaged) cost *= 0.85m; // 15% discount

        Cost = cost;
    }
}