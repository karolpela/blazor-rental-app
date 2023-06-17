namespace RentalApp.Shared.Models.Equipment.Skates;

public class InlineSkates : SportsEquipment
{
    public InlineSkates(int id, decimal size, string purpose, bool isFunctional, decimal wheelDiameter,
        string bearingType) : base(id, size, purpose, isFunctional)
    {
        WheelDiameter = wheelDiameter;
        BearingType = bearingType;
    }

    public decimal WheelDiameter { get; set; }
    public string BearingType { get; set; }
}