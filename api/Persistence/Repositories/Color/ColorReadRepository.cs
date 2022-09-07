using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
{
     public ColorReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
