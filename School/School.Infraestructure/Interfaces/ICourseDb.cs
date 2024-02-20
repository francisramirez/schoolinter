
using School.Domain.Entities;
using School.Infraestructure.Core;

namespace School.Infraestructure.Interfaces
{
    public interface ICourseDb  : IDaoBase<Course>
    {
        List<Course> GetCoursesByDepartmentId(int departmentId);
    }
}
