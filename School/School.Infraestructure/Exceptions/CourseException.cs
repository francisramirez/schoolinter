

using School.Infraestructure.Dao;

namespace School.Infraestructure.Exceptions
{
    public class CourseException : Exception
    {
        public CourseException(string message) :base(message)
        {
            SaveError(message);
        }
        void SaveError(string message) 
        {
            // X logica para guardar el erro ocurrido //

           
           
        }
    }
}
