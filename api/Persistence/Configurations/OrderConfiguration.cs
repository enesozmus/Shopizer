using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
     public void Configure(EntityTypeBuilder<Order> builder)
     {
          builder.Property(x => x.Address).HasMaxLength(120).IsRequired();
          builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
     }
}
