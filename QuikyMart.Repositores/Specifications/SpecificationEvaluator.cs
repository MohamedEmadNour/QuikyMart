using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Specifications
{
    public class SpecificationEvaluator<T , TKey> where T : BaseEntity<TKey> 
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery , ISpecification<T> Specs)
        {
            var Query = InputQuery;

            if (Specs.Criteria != null)
                Query = Query.Where(Specs.Criteria);

            if (Specs.OrderBy != null)
                Query = Query.OrderBy(Specs.OrderBy);

            if (Specs.OrderByDesc != null)
                Query = Query.OrderByDescending(Specs.OrderByDesc);
            if(Specs.IsPagination)
                Query = Query.Skip(Specs.Skip).Take(Specs.Take);

          

            Query = Specs.Includes.Aggregate(Query, (Current, input) => Current.Include(input));

            return Query;

        }
    }
}
