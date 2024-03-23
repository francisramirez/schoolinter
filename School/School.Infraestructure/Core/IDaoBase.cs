 

namespace School.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        Task<DataResult> Save(TEntity entity);

        Task<DataResult> Update(TEntity entity);
       
       Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetEntitiesWithFilters(Func<TEntity, bool> filter);

        Task<TEntity> GetById(int Id);

        bool Exists(Func<TEntity, bool> filter);

        Task<int> Commit();
    }
    
}
