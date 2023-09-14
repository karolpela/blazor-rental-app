using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RentalApp.Shared.Converters;
using RentalApp.Shared.Models;
using RentalApp.Shared.Models.Equipment;
using RentalApp.Shared.Models.Equipment.Skates;

namespace RentalApp.Server.Data;

public class RentalAppContext : DbContext
{
    private const string DbPath = "rental.db";

    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public RentalAppContext(DbContextOptions<RentalAppContext> options)
        : base(options)
    {
        _serializerOptions.Converters.Add(new SportsEquipmentConverter());
    }

    public DbSet<Person> People => Set<Person>();
    public DbSet<SportsEquipment> Equipment => Set<SportsEquipment>();
    public DbSet<IceSkates> IceSkates => Set<IceSkates>();
    public DbSet<InlineSkates> InlineSkates => Set<InlineSkates>();
    public DbSet<RollerSkates> RollerSkates => Set<RollerSkates>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<ProtectiveGear> ProtectiveGear => Set<ProtectiveGear>();
    public DbSet<Insurance> Insurances => Set<Insurance>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

    public override int SaveChanges()
    {
        CalculateInsuranceCosts();
        return base.SaveChanges();
    }

    private void CalculateInsuranceCosts()
    {
        var entitiesToCalculate = ChangeTracker.Entries<Insurance>()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var insurance in entitiesToCalculate) insurance.CalculateCost();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Person>(e =>
        {
            e.HasMany(p => p.Subordinates)
                .WithOne(p => p.Supervisor)
                .IsRequired(false);

            // Check if the role contains 'Client' (bitwise AND with 1)
            e.HasIndex(p => p.PhoneNumber)
                .IsUnique()
                .HasFilter("[Role] & 1 = 1");

            // Check if the role contains 'Attendant', 'Mechanic', or 'Owner' (bitwise AND with 2, 4, and 8 respectively)
            e.HasIndex(p => p.EmployeeId)
                .IsUnique()
                .HasFilter("[Role] & 2 = 2 OR [Role] & 4 = 4 OR [Role] & 8 = 8");

            var jsonData = File.ReadAllText("Data/SeedData/person.json");
            var people = JsonSerializer.Deserialize<Person[]>(jsonData, _serializerOptions);
            if (people != null) e.HasData(people);
        });

        modelBuilder.Entity<IceSkates>(e =>
        {
            var iceSkatesData = File.ReadAllText("Data/SeedData/SportsEquipment/iceSkates.json");
            var iceSkates = JsonSerializer.Deserialize<IceSkates[]>(iceSkatesData, _serializerOptions);
            if (iceSkates != null) e.HasData(iceSkates);
        });
        modelBuilder.Entity<InlineSkates>(e =>
        {
            var inlineSkatesData = File.ReadAllText("Data/SeedData/SportsEquipment/inlineSkates.json");
            var inlineSkates = JsonSerializer.Deserialize<InlineSkates[]>(inlineSkatesData, _serializerOptions);
            if (inlineSkates != null) e.HasData(inlineSkates);
        });
        modelBuilder.Entity<RollerSkates>(e =>
        {
            var rollerSkatesData = File.ReadAllText("Data/SeedData/SportsEquipment/rollerSkates.json");
            var rollerSkates = JsonSerializer.Deserialize<RollerSkates[]>(rollerSkatesData, _serializerOptions);
            if (rollerSkates != null) e.HasData(rollerSkates);
        });

        modelBuilder.Entity<ProtectiveGear>(e =>
        {
            var protectiveGearData = File.ReadAllText("Data/SeedData/protectiveGear.json");
            var protectiveGear = JsonSerializer.Deserialize<ProtectiveGear[]>(protectiveGearData, _serializerOptions);
            if (protectiveGear != null) e.HasData(protectiveGear);
        });

        modelBuilder.Entity<Rental>(e =>
        {
            e.Property<int>("ClientId");

            e.HasOne(r => r.Client)
                .WithMany(p => p.Rentals)
                .HasForeignKey("ClientId");

            e.Property<int>("EquipmentId");

            e.HasOne(r => r.Equipment)
                .WithMany(se => se.Rentals)
                .HasForeignKey("EquipmentId");

            e.HasOne(r => r.Insurance)
                .WithOne(i => i.Rental)
                .HasForeignKey<Insurance>(i => i.RentalId)
                .IsRequired(false);

            e.HasMany(r => r.ProtectiveGear)
                .WithMany(pg => pg.Rentals);

            var rentalsData = File.ReadAllText("Data/SeedData/rental.json");
            var rentals = JsonSerializer.Deserialize<Rental[]>(rentalsData, _serializerOptions);
            if (rentals == null) return;
            foreach (var rental in rentals)
                modelBuilder.Entity<Rental>().HasData(new
                {
                    rental.Id,
                    ClientId = rental.Client.Id,
                    EquipmentId = rental.Equipment.Id,
                    rental.StartDate,
                    rental.ScheduledEndDate,
                    rental.EndDate,
                    rental.EquipmentDamaged
                });
        });
    }
}