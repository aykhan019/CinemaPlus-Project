using Cinema.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter=null!);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null!);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);  
    }
}
