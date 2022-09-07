using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SizeReadRepository : ReadRepository<Size>, ISizeReadRepository
{
     public SizeReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
