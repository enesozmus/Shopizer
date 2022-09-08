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

          #region SeedData

          var product1 = new Product() { Id = 1, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 1, IsOfferable = true, IsSold = false, Name = "Dik Yaka Erkek Deri Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product2 = new Product() { Id = 2, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 2, IsOfferable = true, IsSold = false, Name = "Biker Yaka Erkek Deri Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product3 = new Product() { Id = 3, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 3, IsOfferable = true, IsSold = false, Name = "Gömlek Yaka Erkek Şişme Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(product1, product2);

          #endregion
     }
}
