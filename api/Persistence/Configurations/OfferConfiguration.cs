using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
     public void Configure(EntityTypeBuilder<Offer> builder)
     {
          builder.Property(x => x.OfferPrice).IsRequired().HasPrecision(14, 2);
     }
}
