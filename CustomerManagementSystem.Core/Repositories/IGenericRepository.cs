using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T t);
        T Update(T t);
        void Delete(T t);
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);//linQ
    }
}
