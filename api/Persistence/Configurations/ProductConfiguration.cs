using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
     public void Configure(EntityTypeBuilder<Product> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
          builder.Property(x => x.Stock).IsRequired();
          builder.Property(x => x.IsOfferable).IsRequired();
          builder.Property(x => x.IsSold).IsRequired();
          builder.Property(x => x.Price).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Offers)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    .IsRequired(true)
                    // => Ürün silinirken silinmek istenen ürünle ilişkili teklifler de silinmeli.
                    .OnDelete(DeleteBehavior.Cascade);

          builder.HasMany(x => x.ProductImageFiles)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    .IsRequired(true)
                    // => Ürün silinirken silinmek istenen ürünle ilişkili fotoğraflar de silinmeli.
                    .OnDelete(DeleteBehavior.Cascade);

          #endregion
     }
}
