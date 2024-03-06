using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.AppServices.Contracts;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost("GetCourseByDeparment")]
        public IActionResult GetCourseByDeparment(int departmentId) 
        {
            var result = this.courseService.GetCoursesByDepartment(departmentId);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
        [HttpPost("GetCourseByDates")]
        public IActionResult GetCourseByDates(DateTime startDate, DateTime endDate)
        {
            var result = this.courseService.GetCoursesByDates(startDate, endDate);

            if (!result.Success)
                return BadRequest(result);
            

            return Ok(result);
        }
        [HttpPost("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var result = this.courseService.GetCourseCount();

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
