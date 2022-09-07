using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
     public void Configure(EntityTypeBuilder<Customer> builder)
     {
          builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

          #region ForeingKey

          builder.HasMany(x => x.Orders)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId)
                    // => Müşteri silinirken silinmek istenen müşteriyle ilişkili siparişler de silinmeli.
                    .OnDelete(DeleteBehavior.Cascade);

          #endregion
     }
}
