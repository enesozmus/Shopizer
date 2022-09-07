using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
     public CategoryWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
