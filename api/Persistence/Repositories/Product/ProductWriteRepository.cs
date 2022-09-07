using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
     public ProductWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
