using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
     public void Configure(EntityTypeBuilder<Size> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(8).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Products)
                    .WithOne(x => x.Size)
                    .HasForeignKey(x => x.SizeId)
                    // => Kısıtlandı.
                    // => Ürün Bedeni silinirken silinmek istenen bedenle ilişkili ürünler varsa beden silinemesin.
                    .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedData

          var size1 = new Size() { Id = 1, Name = "XS", CreatedDate = new DateTime(2022, 09, 08) };
          var size2 = new Size() { Id = 2, Name = "S", CreatedDate = new DateTime(2022, 09, 08) };
          var size3 = new Size() { Id = 3, Name = "M", CreatedDate = new DateTime(2022, 09, 08) };
          var size4 = new Size() { Id = 4, Name = "L", CreatedDate = new DateTime(2022, 09, 08) };
          var size5 = new Size() { Id = 5, Name = "XL", CreatedDate = new DateTime(2022, 09, 08) };
          var size6 = new Size() { Id = 6, Name = "2XL", CreatedDate = new DateTime(2022, 09, 08) };
          var size7 = new Size() { Id = 7, Name = "3XL", CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(size1, size2, size3, size4, size5, size6, size7);

          #endregion
     }
}
