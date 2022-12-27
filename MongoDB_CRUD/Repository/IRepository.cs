using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDB_CRUD.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<List<T>> GetAll(string table);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}
