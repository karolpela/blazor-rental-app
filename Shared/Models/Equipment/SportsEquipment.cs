namespace RentalApp.Shared.Models.Equipment;

public abstract class SportsEquipment
{
    protected SportsEquipment(int id, decimal size, string purpose, bool isFunctional)
    {
        Id = id;
        Size = size;
        Purpose = purpose;
        IsFunctional = isFunctional;
    }

    public int Id { get; set; }
    public decimal Size { get; set; }
    public string Purpose { get; set; }
    public bool IsFunctional { get; set; }

    public IEnumerable<Rental> Rentals { get; } = new List<Rental>();
}