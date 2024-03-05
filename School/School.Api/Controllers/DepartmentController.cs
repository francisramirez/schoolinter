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
        public IActionResult GetDepartments()
        {
            var departments = this.departmentService.GetDepartments();

            return Ok(departments);
        }
        [HttpPost("Save")]
        public IActionResult Save(DepartmentCreateModel createModel)
        {

            //var deparment = createModel.ConvertFromDepartmentCreateToDeparment();

            //var result = this.departmentDb.Save(deparment);

            return Ok();
        }
        [HttpPost("Update")]
        public IActionResult Update(UpdateDepartmentModel updateDepartment)
        {
            //var result = this.departmentDb.Save(new Domain.Entities.Department()
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
