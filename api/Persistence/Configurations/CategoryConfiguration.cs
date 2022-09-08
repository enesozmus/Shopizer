using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
     public void Configure(EntityTypeBuilder<Category> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Products)
                      .WithOne(x => x.Category)
                      .HasForeignKey(x => x.CategoryId)
                      // => Kısıtlandı.
                      // => Kategori silinirken silinmek istenen kategoriyle ilişkili ürünler varsa kategori silinemesin.
                      .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedData

          var category1 = new Category() { Id = 1, Name = "Mont", CreatedDate = new DateTime(2022, 09, 08) };
          var category2 = new Category() { Id = 2, Name = "Hırka ve Süveter", CreatedDate = new DateTime(2022, 09, 08) };
          var category3 = new Category() { Id = 3, Name = "Kazak", CreatedDate = new DateTime(2022, 09, 08) };
          var category4 = new Category() { Id = 4, Name = "Bluz", CreatedDate = new DateTime(2022, 09, 08) };
          var category5 = new Category() { Id = 5, Name = "Gömlek", CreatedDate = new DateTime(2022, 09, 08) };
          var category6 = new Category() { Id = 6, Name = "Tişört", CreatedDate = new DateTime(2022, 09, 08) };
          var category7 = new Category() { Id = 7, Name = "Sweatshirt", CreatedDate = new DateTime(2022, 09, 08) };
          var category8 = new Category() { Id = 8, Name = "Jean", CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(category1, category2, category3, category4, category5, category6, category7, category8);

          #endregion
     }
}
