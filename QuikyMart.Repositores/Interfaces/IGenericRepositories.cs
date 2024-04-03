using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositories.Interfaces
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int? id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
