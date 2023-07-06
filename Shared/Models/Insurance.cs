using System.Text.Json.Serialization;

namespace RentalApp.Shared.Models;

public class Insurance
{
    public int Id { get; set; }
    public decimal Cost { get; set; }

    [JsonIgnore] public Rental? Rental { get; set; }

    public int RentalId { get; set; }

    public void CalculateCost()
    {
        if (Rental?.Equipment == null || Rental?.Client == null)
            // throw new InvalidOperationException("Cannot calculate cost: rental, equipment, or client is null.");
            return;

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