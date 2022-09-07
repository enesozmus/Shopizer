using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BaseFileReadRepository : ReadRepository<BaseFile>, IBaseFileReadRepository
{
     public BaseFileReadRepository(ECommerceDbContext context) : base(context)
     {
     }
}
