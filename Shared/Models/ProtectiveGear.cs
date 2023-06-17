namespace RentalApp.Shared.Models;

public class ProtectiveGear

{
    public ProtectiveGear(int id, string type, string size)
    {
        Id = id;
        Type = type;
        Size = size;
    }

    public int Id { get; set; }
    public string Type { get; set; }
    public string Size { get; set; }

    public IEnumerable<Rental> Rentals { get; } = new List<Rental>();
}