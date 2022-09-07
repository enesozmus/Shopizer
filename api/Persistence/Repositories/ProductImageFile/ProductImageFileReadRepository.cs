using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
{
     public ProductImageFileReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
