using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SizeWriteRepository : WriteRepository<Size>, ISizeWriteRepository
{
     public SizeWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
