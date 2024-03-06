using Microsoft.Extensions.Logging;
using School.Domain.Entities;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;
using School.Infraestructure.Models;
using System.Collections.Generic;

namespace School.Infraestructure.Dao
{
    public class CourseDb : DaoBase<Course>, ICourseDb
    {
        private readonly SchoolContext context;
        private readonly ILogger<CourseDb> logger;

        public CourseDb(SchoolContext context, ILogger<CourseDb> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<CourseCount> GetCourseCount()
        {
            List<CourseCount> courses = new List<CourseCount>();

            try
            {
                courses = (from co in context.Courses
                           join depto in context.Departments on co.DepartmentID equals depto.DepartmentID
                           where co.Deleted == false 
                           && depto.Deleted == false
                           group new { depto.Name } by depto.Name
                          into myGroup
                           orderby myGroup.Count() descending
                           select new CourseCount()
                           {
                               DepartmentName = myGroup.Key,
                               Count = myGroup.Count()
                           }).ToList();

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error cargando los cursos.", ex.ToString());
            }

            return courses;
        }

        public List<CourseModel> GetCoursesByDates(DateTime startDate, DateTime endDate)
        {
            List<CourseModel> courses = new List<CourseModel>();



            try
            {
                courses = (from co in this.context.Courses
                           join depto in this.context.Departments on co.DepartmentID equals depto.DepartmentID
                           where co.Deleted == false && depto.Deleted == false
                            && co.CreationDate.Date >= startDate && co.CreationDate.Date <= endDate
                           orderby co.CreationDate descending
                           select new CourseModel()
                           {
                               CourseId = co.CourseID,
                               CreationDate = co.CreationDate.ToString("dd-MM-yyyy"),
                               Credit = co.Credits,
                               DeparmentName = depto.Name,
                               DepartmentId = depto.DepartmentID,
                               Title = co.Title
                           }).ToList();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los cursos", ex.ToString());
            }
            return courses;
        }

        public List<CourseModel> GetCoursesByDepartmentId(int departmentId)
        {
            List<CourseModel> courses = new List<CourseModel>();

            try
            {
                courses = (from co in this.context.Courses
                           join depto in this.context.Departments on co.DepartmentID equals depto.DepartmentID
                           where co.Deleted == false && depto.Deleted == false
                            && co.DepartmentID == departmentId
                           orderby co.CreationDate descending
                           select new CourseModel()
                           {
                               CourseId = co.CourseID,
                               CreationDate = co.CreationDate.ToString("dd-MM-yyyy"),
                               Credit = co.Credits,
                               DeparmentName = depto.Name,
                               DepartmentId = depto.DepartmentID,
                               Title = co.Title
                           }).ToList();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los cursos", ex.ToString());
            }

            return courses;
        }

        public override DataResult Save(Course entity)
        {
            return base.Save(entity);
        }

    }
}
