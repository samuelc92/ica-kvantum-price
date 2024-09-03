using Microsoft.EntityFrameworkCore;

namespace IcaKvantumPrice.ApiService.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DatabaseContext>();
        try
        {
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
        }
    }
}
