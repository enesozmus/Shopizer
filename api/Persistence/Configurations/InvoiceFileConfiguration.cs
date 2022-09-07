using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class InvoiceFileConfiguration : IEntityTypeConfiguration<InvoiceFile>
{
     public void Configure(EntityTypeBuilder<InvoiceFile> builder)
     {
          builder.Property(x => x.Price).IsRequired().HasPrecision(14, 2);
     }
}
