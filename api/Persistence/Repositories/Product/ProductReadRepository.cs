using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
     public ProductReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
