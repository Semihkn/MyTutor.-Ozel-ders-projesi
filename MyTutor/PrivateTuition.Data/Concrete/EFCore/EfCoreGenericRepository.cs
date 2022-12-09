using Microsoft.EntityFrameworkCore;
using PrivateTuition.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public EfCoreGenericRepository(PrivateTuitionContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected PrivateTuitionContext context
        {
            get
            {
                return _dbContext as PrivateTuitionContext;
            }
        }

        public async Task CreateAsync(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await context
                .Set<TEntity>()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context
                 .Set<TEntity>()
                 .FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
