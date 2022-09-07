using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
{
     public ColorWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
