
using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Models;

namespace School.Infraestructure.Interfaces
{
    public interface ICourseDb  : IDaoBase<Course>
    {
        List<CourseModel> GetCoursesByDepartmentId(int departmentId);
        List<CourseModel> GetCoursesByDates(DateTime startDate, DateTime endDate);

        List<CourseCount> GetCourseCount();
    }
}
