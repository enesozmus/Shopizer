using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
     public void Configure(EntityTypeBuilder<Color> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Products)
                      .WithOne(x => x.Color)
                      .HasForeignKey(x => x.ColorId)
                      // => Kısıtlandı.
                      // => Renk silinirken silinmek istenen renkle ilişkili ürünler varsa renk silinemesin.
                      .OnDelete(DeleteBehavior.Restrict);

          #endregion

          #region SeedData

          var color1 = new Color() { Id = 1, Name = "Ekru", CreatedDate = new DateTime(2022, 09, 08) };
          var color2 = new Color() { Id = 2, Name = "Kırmızı", CreatedDate = new DateTime(2022, 09, 08) };
          var color3 = new Color() { Id = 3, Name = "Lacivert", CreatedDate = new DateTime(2022, 09, 08) };
          var color4 = new Color() { Id = 4, Name = "Açık Kahverengi", CreatedDate = new DateTime(2022, 09, 08) };
          var color5 = new Color() { Id = 5, Name = "Mavi", CreatedDate = new DateTime(2022, 09, 08) };
          var color6 = new Color() { Id = 6, Name = "Antrasit", CreatedDate = new DateTime(2022, 09, 08) };
          var color7 = new Color() { Id = 7, Name = "Koyu Gri", CreatedDate = new DateTime(2022, 09, 08) };
          var color8 = new Color() { Id = 8, Name = "Canlı Turuncu", CreatedDate = new DateTime(2022, 09, 08) };
          var color9 = new Color() { Id = 9, Name = "Bej Çizgili", CreatedDate = new DateTime(2022, 09, 08) };
          var color10 = new Color() { Id = 10, Name = "Beyaz", CreatedDate = new DateTime(2022, 09, 08) };
          var color11 = new Color() { Id = 11, Name = "Gri", CreatedDate = new DateTime(2022, 09, 08) };
          var color12 = new Color() { Id = 12, Name = "İndigo Melanj", CreatedDate = new DateTime(2022, 09, 08) };
          var color13 = new Color() { Id = 13, Name = "Koyu Rodeo", CreatedDate = new DateTime(2022, 09, 08) };
          var color14 = new Color() { Id = 14, Name = "Optik Beyaz", CreatedDate = new DateTime(2022, 09, 08) };

          builder.HasData(color1, color2, color3, color4, color5, color6, color7, color8, color9, color10, color11,
               color12, color13, color14);

          #endregion
     }
}
