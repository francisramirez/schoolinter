

using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Interfaces;

namespace School.Infraestructure.Dao
{
    public class DepartmentDb : IDepartmentDb
    {
        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
