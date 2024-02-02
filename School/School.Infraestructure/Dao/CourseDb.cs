using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace School.Infraestructure.Dao
{
    public class CourseDb : ICourseDb
    {

        public bool Exists(string name)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll()
        {
             
            throw new NotImplementedException();
        }

        public Course GetById(int deptoId)
        {
            throw new NotImplementedException();
        }

        public DataResult Save(Course entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(entity.Title))
                    throw new CourseException("El curso se encuentra registrado.");

            }

            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";

            }
            return result;
        }
    }
}
