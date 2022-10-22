using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DataAccess
{
    public class EfEntityBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }


        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            using (var context = new TContext())
            {
                var quaryable = context.Set<TEntity>().AsQueryable();
                if (include != null)
                {
                    quaryable = include(quaryable);
                }
                return filter == null
                    ? await quaryable.ToListAsync()
                    : await quaryable.Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            using (var context = new TContext())
            {
                var quaryable = context.Set<TEntity>().AsQueryable();
                if (include != null)
                {
                    quaryable = include(quaryable);
                }
                return await quaryable.FirstOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
