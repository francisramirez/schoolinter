using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Infraestructure.Interfaces;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentDb departmentDb;

        public DepartmentController(IDepartmentDb departmentDb)
        {
            this.departmentDb = departmentDb;
        }

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments() 
        {
            var departments = this.departmentDb.GetAll();

            return Ok(departments);
        }
    }
}
