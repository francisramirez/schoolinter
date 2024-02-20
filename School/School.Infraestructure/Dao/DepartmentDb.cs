

using School.Domain.Entities;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using School.Infraestructure.Interfaces;

namespace School.Infraestructure.Dao
{
    public class DepartmentDb : DaoBase<Department>, IDepartmentDb
    {
        private readonly SchoolContext context;

        public DepartmentDb(SchoolContext context) :base(context)
        {
            this.context = context;
        }
        public override List<Department> GetAll()
        {
            return base.GetEntitiesWithFilters(dep => !dep.Deleted);
        }
        public override DataResult Save(Department entity)
        {
            return base.Save(entity);
        }
    }
}
