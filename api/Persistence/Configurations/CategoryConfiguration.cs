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
     }
}
