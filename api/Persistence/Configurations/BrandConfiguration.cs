using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
     public void Configure(EntityTypeBuilder<Brand> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Products)
                    .WithOne(x => x.Brand)
                    .HasForeignKey(x => x.BrandId)
                    // => Kısıtlandı.
                    // => Marka silinirken silinmek istenen markayla ilişkili ürünler varsa marka silinemesin.
                    .OnDelete(DeleteBehavior.Restrict);

          #endregion
     }
}
