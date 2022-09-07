using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.IRepositories;

public interface IRepository<T> where T : BaseEntity
{
     DbSet<T> Table { get; }
     IQueryable<T> TableNoTracking { get; }
}
