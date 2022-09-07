using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class InvoiceFile : BaseFile
{
     [Precision(14, 2)]
     public decimal Price { get; set; }
}
