using School.AppServices.Core;
using School.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.AppServices.Contracts
{
    public interface ICourseService
    {
        ServiceResult GetCoursesByDepartment(int departmentId);
        ServiceResult GetCoursesByDates(DateTime startDate, DateTime endDate);

        ServiceResult GetCourseCount();
    }
}
