using QuikyMart.Data.Entites;
using QuikyMart.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores.Interfaces
{
    public interface IUnitOfWork 
    {
        IGenericRepositories<T,TKey> repositories<T , TKey>() where T : BaseEntity<TKey>;

        Task<int> CompleteAsync();
    }
}
