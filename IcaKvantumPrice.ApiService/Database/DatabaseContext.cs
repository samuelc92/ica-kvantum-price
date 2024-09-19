using IcaKvantumPrice.ApiService.Database.Configurations;
using IcaKvantumPrice.ApiService.Shoppings;
using Microsoft.EntityFrameworkCore;

namespace IcaKvantumPrice.ApiService.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Shopping> Shoppings{ get; set; } = default!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ShoppingConfiguration().Configure(modelBuilder.Entity<Shopping>());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

