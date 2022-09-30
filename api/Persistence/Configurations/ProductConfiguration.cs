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
                    .OnDelete(DeleteBehavior.Restrict);

          builder.HasMany(x => x.BasketItems)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    // => Kısıtlandı.
                    // => Ürün silinirken silinmek istenen ürünle ilişkili sepet içeriği varsa ürün silinemesin.
                    .OnDelete(DeleteBehavior.Restrict);

          //builder.HasMany(x => x.ProductImageFiles)
          //          .WithOne(x => x.Product)
          //          .HasForeignKey(x => x.ProductId)
          //          .IsRequired(true)
          //          // => Ürün silinirken silinmek istenen ürünle ilişkili fotoğraflar de silinmeli.
          //          .OnDelete(DeleteBehavior.Cascade);

          #endregion

          #region SeedData

          var product1 = new Product() { Id = 1, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 1, IsOfferable = true, IsSold = false, Name = "Dik Yaka Erkek Deri Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product2 = new Product() { Id = 2, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 2, IsOfferable = true, IsSold = false, Name = "Biker Yaka Erkek Deri Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product3 = new Product() { Id = 3, CategoryId = 1, AppUserId = 1, SizeId = 1, BrandId = 1, ColorId = 3, IsOfferable = true, IsSold = false, Name = "Gömlek Yaka Erkek Şişme Mont", Stock = 400, Price = 2699.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product4 = new Product() { Id = 4, CategoryId = 2, AppUserId = 1, SizeId = 2, BrandId = 4, ColorId = 4, IsOfferable = true, IsSold = false, Name = "Kuşak Detaylı Uzun Kollu Kadın Triko Hırka", Stock = 400, Price = 499.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product5 = new Product() { Id = 5, CategoryId = 2, AppUserId = 2, SizeId = 3, BrandId = 5, ColorId = 5, IsOfferable = true, IsSold = false, Name = "Kapüşonlu Kendinden Desenli Kadın Süveter", Stock = 400, Price = 189.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product6 = new Product() { Id = 6, CategoryId = 3, AppUserId = 2, SizeId = 3, BrandId = 6, ColorId = 6, IsOfferable = true, IsSold = false, Name = "Balıkçı Yaka Uzun Kollu Erkek Triko Kazak", Stock = 400, Price = 79.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product7 = new Product() { Id = 7, CategoryId = 3, AppUserId = 2, SizeId = 4, BrandId = 7, ColorId = 7, IsOfferable = true, IsSold = false, Name = "Bisiklet Yaka Uzun Kollu Çizgili Erkek Triko Kazak", Stock = 400, Price = 149.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product8 = new Product() { Id = 8, CategoryId = 4, AppUserId = 2, SizeId = 4, BrandId = 8, ColorId = 8, IsOfferable = false, IsSold = false, Name = "Kalp Yaka Kolsız Kadın Blız", Stock = 400, Price = 449.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product9 = new Product() { Id = 9, CategoryId = 4, AppUserId = 3, SizeId = 5, BrandId = 9, ColorId = 9, IsOfferable = true, IsSold = true, Name = "Renk Bloklu Uzun Kollu Kadın Bluz", Stock = 400, Price = 599.99f, CreatedDate = new DateTime(2022, 09, 08) };
          
          var product10 = new Product() { Id = 10, CategoryId = 5, AppUserId = 3, SizeId = 5, BrandId = 1, ColorId = 10, IsOfferable = true, IsSold = false, Name = "Uzun Kollu Poplin Erkek Gömlek", Stock = 400, Price = 349.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product11 = new Product() { Id = 11, CategoryId = 5, AppUserId = 3, SizeId = 6, BrandId = 2, ColorId = 11, IsOfferable = true, IsSold = false, Name = "Uzun Kollu Keten Erkek Gömlek", Stock = 400, Price = 349.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product12 = new Product() { Id = 12, CategoryId = 6, AppUserId = 3, SizeId = 6, BrandId = 3, ColorId = 12, IsOfferable = false, IsSold = false, Name = "Tül Detaylı Kadın Lima Tişört", Stock = 400, Price = 199.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product13 = new Product() { Id = 13, CategoryId = 6, AppUserId = 4, SizeId = 7, BrandId = 4, ColorId = 13, IsOfferable = true, IsSold = false, Name = "Bisiklet Yaka Baskılı Kadın Tişört", Stock = 400, Price = 199.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product14 = new Product() { Id = 14, CategoryId = 7, AppUserId = 5, SizeId = 7, BrandId = 5, ColorId = 14, IsOfferable = true, IsSold = false, Name = "Baskılı Erkek Sweatshirt", Stock = 400, Price = 299.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product15 = new Product() { Id = 15, CategoryId = 7, AppUserId = 6, SizeId = 1, BrandId = 6, ColorId = 11, IsOfferable = true, IsSold = true, Name = "Outdoor Kapüşonlu Erkek Sweatshirt", Stock = 400, Price = 269.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product16 = new Product() { Id = 16, CategoryId = 8, AppUserId = 7, SizeId = 1, BrandId = 7, ColorId = 12, IsOfferable = true, IsSold = false, Name = "Tül Kemer Detaylı Kadın Jean", Stock = 400, Price = 349.99f, CreatedDate = new DateTime(2022, 09, 08) };
          var product17 = new Product() { Id = 17, CategoryId = 8, AppUserId = 8, SizeId = 2, BrandId = 8, ColorId = 10, IsOfferable = true, IsSold = true, Name = "Cepli Kadın Flare Jean", Stock = 400, Price = 269.99f, CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(product1, product2, product3, product4, product5, product6, product7, product8, product9
               , product10, product11, product12, product13, product14, product15, product16, product17);

          #endregion
     }
}
