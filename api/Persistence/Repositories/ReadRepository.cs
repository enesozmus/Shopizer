﻿using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
     private readonly ECommerceDbContext _context;

     public ReadRepository(ECommerceDbContext context)
     {
          _context = context ?? throw new ArgumentNullException(nameof(context));
     }

     #region IRepository(Tables)

     public DbSet<T> Table => _context.Set<T>();

     public IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

     #endregion

     #region Select

     #region IReadOnlyList

     // track etmeden Liste olarak getir
     public async Task<IReadOnlyList<T>> GetAllAsync()
          => await TableNoTracking.ToListAsync();

     // track etmeden bir şarta bağlı Liste olarak getir
     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
          => await TableNoTracking.Where(predicate).ToListAsync();

     // track etmeden bir şarta bağlı ve include'larıyla birlikte Liste olarak getir
     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
     {
          IQueryable<T> query = TableNoTracking;

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          return await query.AsNoTracking().ToListAsync();
     }

     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
     {
          IQueryable<T> query = TableNoTracking;
          if (disableTracking) query = query.AsNoTracking();

          if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

          if (predicate != null) query = query.Where(predicate);

          if (orderBy != null)
               return await orderBy(query).ToListAsync();
          return await query.ToListAsync();
     }

     public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
     {
          IQueryable<T> query = TableNoTracking;
          if (disableTracking) query = query.AsNoTracking();

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          if (orderBy != null)
               return await orderBy(query).ToListAsync();
          return await query.ToListAsync();
     }

     #endregion

     #region IEnumerable & IQueryable

     public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids)
           => await _context.Set<IEnumerable<T>>().FindAsync(ids);

     // track ederek IQueryable olarak getir
     public IQueryable<T> GetAllAsIQueryable()
          => TableNoTracking;

     // track ederek bir şarta bağlı IQueryable olarak getir
     public IQueryable<T> GetWhereAsIQueryable(Expression<Func<T, bool>> predicate)
          => TableNoTracking.Where(predicate);

     #endregion

     #region Single

     public async Task<T> GetByIdAsync(int id)
          => await _context.Set<T>().FindAsync(id);

     public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
     {
          IQueryable<T> query = Table;

          if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

          if (predicate != null) query = query.Where(predicate);

          return await query.AsNoTracking().FirstOrDefaultAsync();
     }

     public async Task<T> GetForMultipleKeys(params object[] keyValues)
          => await _context.Set<T>().FindAsync(keyValues);

     #endregion

     #region Count

     public async Task<int> CountAsync()
          => await _context.Set<T>().CountAsync();

     public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
           => await _context.Set<T>().CountAsync(predicate);

     #endregion

     #endregion
}
