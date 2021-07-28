using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insurance.Application.Interfaces;
using Insurance.Application.Interfaces.Persistence;
using Insurance.Domain.Classes;
using Insurance.Domain.Common;
using Microsoft.EntityFrameworkCore;
namespace Insurance.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
  
        public Repository(DbContext context)
        {
            _context = context;
            
        }
        public DbSet<T> GetQuery()
        {
            return _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            var newEntity = await _context.AddAsync(entity);

            return newEntity.Entity;

        }

        public T Delete(T entity)
        {
            return _context.Remove(entity).Entity;
        }
        public T Delete(int id)
        {
            var entityToDelete = _context.Set<T>().Find(id);

            return _context.Remove(entityToDelete).Entity;
        }
        public void RemoveRange(IEnumerable<object> entities)
        {
            _context.RemoveRange(entities);
        }

        public virtual async Task<GetResult<T>> GetAsync(CancellationToken cancellationToken)
        {
            var records = await _context.Set<T>().ToListAsync(cancellationToken);

            return new GetResult<T>()
            {
                data = records,
                total = records.Count(),
                success = true
            };
        }

        public T Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).LastModified = DateTime.UtcNow;
            }

            return _context.Update(entity).Entity;
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.FindAsync<T>(id);

        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

    }
}
