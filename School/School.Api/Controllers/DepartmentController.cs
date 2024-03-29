﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using School.Api.Models.Department;
using School.Infraestructure.Interfaces;
using School.Api.Extentions;
using School.AppServices.Contracts;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {

            this.departmentService = departmentService;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await this.departmentService.GetDepartments();

            return Ok(departments);
        }

        [HttpPost("GetDepartmentByName")]
        public async Task<IActionResult> GetDepartments([FromBody] SearchDepartmentModel searchDepartment)
        {
            var result = await this.departmentService.GetDepartmentByName(searchDepartment.Name);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] DepartmentCreateModel createModel)
        {

            var deparment = createModel.ConvertFromDepartmentCreateToDeparmentDto();

            var result = await this.departmentService.AddDepartment(deparment);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateDepartmentModel updateDepartment)
        {
           
            //var result = this.departmentService.u
            //var result = this.departmtDb.Save(new Domain.Entities.Department()
            //{
            //    Administrator = updateDepartment.Administrator,
            //    Budget = updateDepartment.Budget,
            //    CreationDate = updateDepartment.ChangeDate,
            //    CreationUser = updateDepartment.UserId,
            //    StartDate = updateDepartment.StartDate,
            //    Name = updateDepartment.Name,
            //    DepartmentID = updateDepartment.DepartmentId
            //});

            return Ok();
        }
    }
}
