using School.AppServices.Core;


namespace School.AppServices.Contracts
{
    public interface ICourseService
    {
        ServiceResult GetCoursesByDepartment(int departmentId);
        ServiceResult GetCoursesByDates(DateTime startDate, DateTime endDate);
        ServiceResult GetCourseCount();
    }
}
