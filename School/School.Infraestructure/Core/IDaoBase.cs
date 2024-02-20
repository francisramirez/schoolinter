 

namespace School.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        DataResult Save(TEntity entity);

        DataResult Update(TEntity entity);
       
        List<TEntity> GetAll();

        List<TEntity> GetEntitiesWithFilters(Func<TEntity, bool> filter);

        TEntity GetById(int Id);

        bool Exists(Func<TEntity, bool> filter);

        int Commit();
    }
    
}
