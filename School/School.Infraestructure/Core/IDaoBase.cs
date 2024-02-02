

using School.Domain.Core;


namespace School.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : BaseEntity
    {
        DataResult Save(TEntity entity);
       
        List<TEntity> GetAll();

        TEntity GetById(int deptoId);

        bool Exists(string name);
    }
    
}
