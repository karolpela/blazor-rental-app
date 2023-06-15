using Microsoft.EntityFrameworkCore;

namespace RentalApp.Server.Data;

public class RentalAppContext : DbContext
{
    private const string DbPath = "rental.db";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
