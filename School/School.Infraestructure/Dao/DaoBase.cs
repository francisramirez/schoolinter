

using Microsoft.EntityFrameworkCore;
using School.Domain.Core;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using System.Linq;
using System.Linq.Expressions;

namespace School.Infraestructure.Dao
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {

        private readonly SchoolContext context;
        private DbSet<TEntity> entities;

        public DaoBase(SchoolContext context)
        {

            this.context = context;
            this.entities = context.Set<TEntity>();
        }
        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public async virtual Task<List<TEntity>> GetAll() => await this.entities.ToListAsync();

        public async virtual Task<TEntity> GetById(int id)
        => await this.entities.FindAsync(id);

        public virtual async Task<DataResult> Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            await this.Commit();

            result.Success = true;

            return result;
        }

        public async virtual Task<List<TEntity>> GetEntitiesWithFilters(Func<TEntity, bool> filter) => this.entities.Where(filter).ToList();

        public virtual async Task<DataResult> Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Update(entity);

            await this.Commit();

            result.Success = true;

            return result;
        }

        public async virtual Task<int> Commit() => await this.context.SaveChangesAsync();

         
    }
}
