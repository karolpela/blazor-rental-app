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
            e.HasOne(r => r.Equipment)
                .WithMany(se => se.Rentals);

            e.HasOne(r => r.Insurance)
                .WithOne(i => i.Rental)
                .HasForeignKey<Rental>(r => r.Id);

            e.HasMany(r => r.ProtectiveGear)
                .WithMany(pg => pg.Rentals);
        });

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Subordinates)
            .WithOne(p => p.Supervisor)
            .IsRequired(false);
    }
}