using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
     public CategoryReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
