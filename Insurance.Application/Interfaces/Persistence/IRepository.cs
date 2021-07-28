using Insurance.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> GetQuery();
        Task<GetResult<T>> GetAsync(CancellationToken cancellationToken);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> predicate);
        Task<T> FindAsync(int id);
        T Update(T entity);
        T Delete(T entity);
        T Delete(int id);
        void RemoveRange(IEnumerable<object> entities);
      //  Task SaveAsync();

    }
}
