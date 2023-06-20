using Microsoft.EntityFrameworkCore;
using RentalApp.Shared.Models;
using RentalApp.Shared.Models.Equipment;
using RentalApp.Shared.Models.Equipment.Skates;

namespace RentalApp.Server.Data;

public class RentalAppContext : DbContext
{
    private const string DbPath = "rental.db";


    public RentalAppContext(DbContextOptions<RentalAppContext> options)
        : base(options)
    {
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rental>(e =>
        {
            e.HasOne(r => r.Client)
                .WithMany(p => p.Rentals)
                .HasForeignKey(r => r.ClientId);

            e.HasOne(r => r.Equipment)
                .WithMany(se => se.Rentals)
                .HasForeignKey(r => r.EquipmentId);

            e.HasOne(r => r.Insurance)
                .WithOne(i => i.Rental)
                .HasForeignKey<Rental>(r => r.Id);

            e.HasMany(r => r.ProtectiveGear)
                .WithMany(pg => pg.Rentals);
        });

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
        });
    }
}