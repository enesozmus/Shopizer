using System.Linq.Expressions;

namespace Application.Specifications;

public class Specification<T> : ISpecification<T>
{
     public Specification()
     {
     }

     #region Where

     public Expression<Func<T, bool>> Criteria { get; }
     public Specification(Expression<Func<T, bool>> criteria)
     {
          Criteria = criteria;
     }

     #endregion


     #region Includes

     public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
     protected void AddInclude(Expression<Func<T, object>> includeExpression)
     {
          Includes.Add(includeExpression);
     }

     #endregion


     #region OrderBy & OrderByDescending

     public Expression<Func<T, object>> OrderBy { get; private set; }
     protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
     {
          OrderBy = orderByExpression;
     }


     public Expression<Func<T, object>> OrderByDescending { get; private set; }
     protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
     {
          OrderByDescending = orderByDescExpression;
     }

     #endregion


     #region Pagination

     public int Take { get; private set; }

     public int Skip { get; private set; }

     public bool IsPagingEnabled { get; private set; }

     protected void ApplyPaging(int skip, int take)
     {
          Skip = skip;
          Take = take;
          IsPagingEnabled = true;
     }

     #endregion
}
