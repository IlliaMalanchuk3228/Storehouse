using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();
        // Task<TEntity> GetById(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}   