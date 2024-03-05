
using School.Api.Models.Department;
using School.Domain.Entities;


namespace School.Api.Extentions
{
    public static class DepartmentExtentions
    {
        public static Department ConvertFromDepartmentCreateToDeparment(this DepartmentCreateModel model) 
        {
            return new Department() 
            {
                Administrator = model.Administrator,
                Budget = model.Budget,
                CreationDate = model.ChangeDate,
                CreationUser = model.UserId,
                StartDate = model.StartDate,
                Name = model.Name
            };
        }
    }
}
