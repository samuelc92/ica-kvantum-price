using IcaKvantumPrice.ApiService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IcaKvantumPrice.ApiService.Database.Configurations;

public class ShoppingConfiguration : IEntityTypeConfiguration<Shopping>
{
    public void Configure(EntityTypeBuilder<Shopping> builder)
    {
        builder
            .Property(p => p.ProductIdentifier)
            .HasMaxLength(15)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength(50)
            .IsRequired();
    }
}
