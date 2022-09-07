using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
{
     public InvoiceFileWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
