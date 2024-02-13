using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;

namespace School.Infraestructure.Dao
{
    public class CourseDb : DaoBase<Course>, ICourseDb
    {
        public override DataResult Save(Course entity)
        {
            return base.Save(entity);
        }

    }
}
