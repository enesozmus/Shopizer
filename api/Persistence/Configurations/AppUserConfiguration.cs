using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
     public void Configure(EntityTypeBuilder<AppUser> builder)
     {
          builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
          builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
          builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

          #region ForeingKey

          builder.HasMany(x => x.Offers)
                    .WithOne(x => x.AppUser)
                    .HasForeignKey(x => x.AppUserId)
                    // => Kullanıcı silinirken silinmek istenen kullanıcıyla ilişkili teklifler de silinmeli.
                    .OnDelete(DeleteBehavior.Cascade);

          builder.HasMany(x => x.Products)
                    .WithOne(x => x.AppUser)
                    .HasForeignKey(x => x.AppUserId)
                    // => Kısıtlandı.
                    // => Kullanıcı silinirken silinmek istenen kullanıcıyla ilişkili ürünler de silinmeli.
                    .OnDelete(DeleteBehavior.Restrict);

          #endregion
     }
}
