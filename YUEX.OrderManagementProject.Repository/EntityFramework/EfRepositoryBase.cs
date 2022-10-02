using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using YUEX.OrderManagementProject.Entities.IEntities;
using YUEX.OrderManagementProject.Repository.IEntityRepository;
using YUEX.OrderManagementProject.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

namespace YUEX.OrderManagementProject.Repository.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityAsyncRepository<TEntity>, IEntityRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {

            IQueryable<TEntity> queryable = Query();
            
            if (predicate != null) queryable = queryable.Where(predicate);
           
            return await queryable.ToListAsync();

        }       

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> queryable = Query();
            
            if (predicate != null) queryable = queryable.Where(predicate);
            
            return queryable.ToList();
        }      

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }
    }
}
