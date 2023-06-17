namespace RentalApp.Shared.Models.Equipment.Skates;

public class IceSkates : SportsEquipment
{
    public IceSkates(int id, decimal size, string purpose, bool isFunctional, string bladeMaterial, bool hasToePick) :
        base(id, size, purpose, isFunctional)
    {
        BladeMaterial = bladeMaterial;
        HasToePick = hasToePick;
    }

    public string BladeMaterial { get; set; }
    public bool HasToePick { get; set; }
}