

using School.AppServices.Core;
using School.AppServices.Dtos;

namespace School.AppServices.Contracts
{
    public interface IDepartmentService
    {
        public Task<ServiceResult> GetDepartments();
        public Task<ServiceResult> GetDepartmentByName(string name);
        public Task<ServiceResult> AddDepartment(DepartmentAddDto departmentAddDto);

    }
}
