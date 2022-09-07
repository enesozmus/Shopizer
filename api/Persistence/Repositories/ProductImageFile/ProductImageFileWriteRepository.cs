using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
{
     public ProductImageFileWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
