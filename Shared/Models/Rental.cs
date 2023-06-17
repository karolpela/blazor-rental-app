using RentalApp.Shared.Models.Equipment;

namespace RentalApp.Shared.Models;

public class Rental
{
    public const decimal OverdueHourlyRate = 5.0m;

    public Rental(int id, DateTimeOffset startDate,
        DateTimeOffset scheduledEndDate, DateTimeOffset? endDate, bool equipmentDamaged)
    {
        Id = id;
        StartDate = startDate;
        ScheduledEndDate = scheduledEndDate;
        EndDate = endDate;
        EquipmentDamaged = equipmentDamaged;
    }

    public int Id { get; set; }

    public required Person Client { get; set; }
    public required SportsEquipment Equipment { get; set; }
    public Insurance? Insurance { get; set; }
    public IEnumerable<ProtectiveGear> ProtectiveGear { get; } = new List<ProtectiveGear>();
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