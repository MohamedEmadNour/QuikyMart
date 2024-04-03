using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites;
using QuikyMart.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Repositories
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly QuikyMartDBContext _context;

        public GenericRepositories(QuikyMartDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int? id)
            => await _context.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);


        public void Update(T entity)
            => _context.Set<T>().Update(entity);
        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

    }
}
