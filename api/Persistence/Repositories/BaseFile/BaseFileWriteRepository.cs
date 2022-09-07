using Application.IRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BaseFileWriteRepository : WriteRepository<BaseFile>, IBaseFileWriteRepository
{
     public BaseFileWriteRepository(ECommerceDbContext context) : base(context)
     {
     }
}
