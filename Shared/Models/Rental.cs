using RentalApp.Shared.Models.Equipment;

namespace RentalApp.Shared.Models;

public class Rental
{
    public const decimal OverdueHourlyRate = 5.0m;
    private Person _client = null!;
    private SportsEquipment _equipment = null!;

    public Rental(DateTimeOffset startDate, DateTimeOffset scheduledEndDate,
        DateTimeOffset? endDate, bool equipmentDamaged)
    {
        StartDate = startDate;
        ScheduledEndDate = scheduledEndDate;
        EndDate = endDate;
        EquipmentDamaged = equipmentDamaged;
    }

    public int Id { get; set; }

    public Person Client
    {
        get => _client;
        set
        {
            _client = value;
            Insurance?.CalculateCost();
        }
    }

    public SportsEquipment Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            Insurance?.CalculateCost();
        }
    }

    public Insurance? Insurance { get; set; }
    public IList<ProtectiveGear> ProtectiveGear { get; set; } = new List<ProtectiveGear>();
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset ScheduledEndDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }

    public bool EquipmentDamaged { get; set; }

    public bool Overdue =>
        (EndDate ?? DateTimeOffset.Now) > ScheduledEndDate;

    public void End()
    {
        EndDate = DateTimeOffset.Now;
    }

    public void EndDamaged()
    {
        EndDate = DateTimeOffset.Now;
        EquipmentDamaged = true;
    }
}