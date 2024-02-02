using School.Infraestructure.Exceptions;
using System.Xml.Linq;

namespace School.AppServices
{
    public class CourseAppService
    {
        public Core.ServiceResult Save() 
        {
            Core.ServiceResult result = new Core.ServiceResult();

            try
            {

            }
            catch (CourseException cex)
            {

                result.Message = cex.Message;
                result.Success = false;
            }

            return result;
        }
    }
}