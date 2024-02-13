

using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Interfaces;

namespace School.Infraestructure.Dao
{
    public class DepartmentDb : DaoBase<Department>, IDepartmentDb
    {
        public override DataResult Save(Department entity)
        {
            DataResult result = new DataResult();

            // logica para almacenar el departamento //

            return result;
        }
    }
}
