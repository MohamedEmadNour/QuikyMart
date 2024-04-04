using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuikyMartDBContext _context;
        private Hashtable _Repositorie;

        public UnitOfWork(QuikyMartDBContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();


        public IGenericRepositories<T, TKey> repositories<T, TKey>() where T : BaseEntity<TKey>
        {
            if (_Repositorie == null)
                _Repositorie = new Hashtable();

            var EntityName = typeof(T).Name;

            if (!_Repositorie.ContainsKey(EntityName))
            {
                var RepositoriesType = typeof(GenericRepositories<,>);
                var RepositoriesInstance = Activator.CreateInstance(RepositoriesType.MakeGenericType(typeof(T), typeof(TKey)), _context);
                _Repositorie.Add(EntityName, RepositoriesInstance);
            }
            return (IGenericRepositories<T, TKey>)_Repositorie[EntityName];
        }



    }
}
