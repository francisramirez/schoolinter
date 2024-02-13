

using School.Domain.Core;
using School.Infraestructure.Core;
using System.Linq;
using System.Linq.Expressions;

namespace School.Infraestructure.Dao
{
    public abstract class DaoBase<TEntity> : IDaoBase<TEntity> where TEntity : class
    {
        private List<TEntity> entities;

        public DaoBase()
        {
            this.entities = new List<TEntity>();
        }
        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetAll()
        {

            return this.entities;
        }

        public virtual TEntity GetById(Func<TEntity, bool> filter)
        {
            return this.entities.First(filter);
        }

        public virtual DataResult Save(TEntity entity)
        {
            DataResult result = new DataResult();

            this.entities.Add(entity);

            result.Success = true;

            return result;
        }
        public void GetData<TParam>(TParam param) 
        {

        }
    }
}
