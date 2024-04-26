using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Specifications;
using QuikyMart.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Repositories
{
    public class GenericRepositories<T , TKey> : IGenericRepositories<T , TKey> where T : BaseEntity<TKey>
    {
        private readonly QuikyMartDBContext _context;

        public GenericRepositories(QuikyMartDBContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IReadOnlyList<T>) await _context.Set<Product>().Include(P=> P.Brand)
                                                      .Include(P=>P.Type).ToListAsync();
            }
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(TKey id)
        {
            if (typeof(T) == typeof(Product))
            {
                return (T)(object)await _context.Set<Product>()
                    .Include(p => p.Brand)
                    .Include(p => p.Type)
                    .FirstOrDefaultAsync(e => e.Id.Equals(id));
            }
            return await _context.Set<T>().FindAsync(id);
        }



        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);


        public void Update(T entity)
            => _context.Set<T>().Update(entity);
        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<T> GetByIdWithSpecificatioAsync(ISpecification<T> specs)
        {
            return await SpecificationEvaluator<T , TKey>.GetQuery(_context.Set<T>(), specs).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecificatioAsync(ISpecification<T> specs)
        {
            return await SpecificationEvaluator<T, TKey>.GetQuery(_context.Set<T>(), specs).ToListAsync();
        }

        public async Task<int> GetCountSpecificatio(ISpecification<T> specs)
        {
            return SpecificationEvaluator<T, TKey>.GetQuery(_context.Set<T>(), specs).Count();
        }

    }
}
