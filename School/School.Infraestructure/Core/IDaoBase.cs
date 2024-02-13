

using School.Domain.Core;
using System.Linq.Expressions;

namespace School.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        DataResult Save(TEntity entity);
       
        List<TEntity> GetAll();

        TEntity GetById(Func<TEntity, bool> filter);

        bool Exists(Func<TEntity, bool> filter);
    }
    
}
