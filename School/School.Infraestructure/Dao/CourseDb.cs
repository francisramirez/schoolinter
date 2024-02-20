using School.Domain.Entities;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;

namespace School.Infraestructure.Dao
{
    public class CourseDb : DaoBase<Course>, ICourseDb
    {
        private readonly SchoolContext context;

        public CourseDb(SchoolContext context) : base(context)
        {
            this.context = context;
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            return this.context.Courses
                               .Where(co => co.DepartmentID == departmentId)
                               .ToList();
        }

        public override DataResult Save(Course entity)
        {
            return base.Save(entity);
        }

    }
}
