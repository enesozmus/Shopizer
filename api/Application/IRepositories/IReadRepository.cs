using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
     #region Select

     #region IReadOnlyList

     Task<IReadOnlyList<T>> GetAllAsync();
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
     Task<IReadOnlyList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     string includeString = null,
                                     bool disableTracking = true);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    List<Expression<Func<T, object>>> includes = null,
                                    bool disableTracking = true);

     #endregion

     #region IEnumerable & IQueryable

     IQueryable<T> GetAllAsIQueryable();
     IQueryable<T> GetWhereAsIQueryable(Expression<Func<T, bool>> predicate);
     Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);

     #endregion

     #region Single

     Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
     Task<T> GetByIdAsync(int id);
     Task<T> GetForMultipleKeys(params object[] keyValues);

     #endregion

     #region Count

     Task<int> CountAsync();
     Task<int> CountAsync(Expression<Func<T, bool>> predicate);

     #endregion

     #endregion
}
