using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
     public void Configure(EntityTypeBuilder<Basket> builder)
     {
          #region ForeingKey

          builder.HasMany(x => x.BasketItems)
                    .WithOne(x => x.Basket)
                    .HasForeignKey(x => x.BasketId)
                    // => Sepet silinirken silinmek istenen sepet içeriği de silinmeli.
                    .OnDelete(DeleteBehavior.Cascade);

          #endregion
     }
}
