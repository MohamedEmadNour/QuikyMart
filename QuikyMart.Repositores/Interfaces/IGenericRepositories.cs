using QuikyMart.Data.Entites;
using QuikyMart.Repositores.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositories.Interfaces
{
    public interface IGenericRepositories<T, TKey> where T : BaseEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<T> GetByIdWithSpecificatioAsync(ISpecification<T> specs);
        Task<IReadOnlyList<T>> GetAllWithSpecificatioAsync(ISpecification<T> specs);
        Task<int> GetCountSpecificatio(ISpecification<T> specs);
    }
}
