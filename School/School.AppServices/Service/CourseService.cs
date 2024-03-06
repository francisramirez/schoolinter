using Microsoft.Extensions.Logging;
using School.AppServices.Contracts;
using School.AppServices.Core;
using School.Infraestructure.Interfaces;


namespace School.AppServices.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseDb courseDb;
        private readonly ILogger<CourseService> logger;

        public CourseService(ICourseDb courseDb, ILogger<CourseService> logger)
        {
            this.courseDb = courseDb;
            this.logger = logger;
        }

        public ServiceResult GetCourseCount()
        {
            ServiceResult result = new ServiceResult();
            try
            {


                result.Data = this.courseDb.GetCourseCount();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los cursos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetCoursesByDates(DateTime startDate, DateTime endDate)
        {
            ServiceResult result = new ServiceResult();
            try
            {

               
                result.Data = this.courseDb.GetCoursesByDates(startDate, endDate);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los cursos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetCoursesByDepartment(int departmentId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.courseDb.GetCoursesByDepartmentId(departmentId);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los cursos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
