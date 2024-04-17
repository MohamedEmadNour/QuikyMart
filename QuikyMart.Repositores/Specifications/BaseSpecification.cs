using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public BaseSpecification( Expression<Func<TEntity, bool>> criteria ) 
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; protected set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; protected set; }

        protected void AddIncludes(Expression<Func<TEntity, object>> includeExpression)
            => Includes.Add(includeExpression);

        protected void Ordering(Expression<Func<TEntity, object>> orderBy)
            => OrderBy = orderBy;

        protected void OrderingDesc(Expression<Func<TEntity, object>> orderByDesc)
            => OrderByDesc = orderByDesc;
    }
}
