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

          #region SeedData

          var brand1 = new Brand() { Id = 1, Name = "LCWAIKIKI", CreatedDate = new DateTime(2022, 09, 08) };
          var brand2 = new Brand() { Id = 2, Name = "LCWAIKIKI Limited", CreatedDate = new DateTime(2022, 09, 08) };
          var brand3 = new Brand() { Id = 3, Name = "LCWAIKIKI Modest", CreatedDate = new DateTime(2022, 09, 08) };
          var brand4 = new Brand() { Id = 4, Name = "LCWAIKIKI Casual", CreatedDate = new DateTime(2022, 09, 08) };
          var brand5 = new Brand() { Id = 5, Name = "LCWAIKIKI Vision", CreatedDate = new DateTime(2022, 09, 08) };
          var brand6 = new Brand() { Id = 6, Name = "MIZALLE", CreatedDate = new DateTime(2022, 09, 08) };
          var brand7 = new Brand() { Id = 7, Name = "BENETTON", CreatedDate = new DateTime(2022, 09, 08) };
          var brand8 = new Brand() { Id = 8, Name = "BIANCA", CreatedDate = new DateTime(2022, 09, 08) };
          var brand9 = new Brand() { Id = 9, Name = "QOOQ STORE", CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(brand1, brand2, brand3, brand4, brand5, brand6, brand7, brand8, brand9);

          #endregion
     }
}
