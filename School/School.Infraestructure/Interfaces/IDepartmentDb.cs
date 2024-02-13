using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Dao;

namespace School.Infraestructure.Interfaces
{
    public interface IDepartmentDb : IDaoBase<Department>
    {
        // va a definir los metodos exclusivo del departamento.
    }
}
