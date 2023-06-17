namespace RentalApp.Shared.Models;

public class Insurance
{
    public Insurance(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    public decimal Cost => 0m; //TODO
    public required Rental Rental { get; set; }
}