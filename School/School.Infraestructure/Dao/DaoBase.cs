

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

        public virtual List<TEntity> GetAll()
        {

            return this.entities.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this.entities.Find(id);
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }
      
        public List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public DataResult Update(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Update(entity);

            result.Success = true;

            return result;
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }
    }
}
