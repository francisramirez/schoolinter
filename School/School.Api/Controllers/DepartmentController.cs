using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using School.Api.Models.Department;
using School.Infraestructure.Exceptions;
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
        [HttpPost("Save")]
        public IActionResult Save(DepartmentCreateModel createModel)
        {
            var result = this.departmentDb.Save(new Domain.Entities.Department()
            {
                Administrator = createModel.Administrator,
                Budget = createModel.Budget,
                CreationDate = createModel.ChangeDate,
                CreationUser = createModel.UserId,
                StartDate = createModel.StartDate,
                Name = createModel.Name
            });

            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(UpdateDepartmentModel updateDepartment)
        {
            var result = this.departmentDb.Save(new Domain.Entities.Department()
            {
                Administrator = updateDepartment.Administrator,
                Budget = updateDepartment.Budget,
                CreationDate = updateDepartment.ChangeDate,
                CreationUser = updateDepartment.UserId,
                StartDate = updateDepartment.StartDate,
                Name = updateDepartment.Name,
                DepartmentID = updateDepartment.DepartmentId
            });

            return Ok(result);
        }
    }
}
