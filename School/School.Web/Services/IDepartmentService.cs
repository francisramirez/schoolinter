using School.Web.Models;
using School.Web.Models.Results;

namespace School.Web.Services
{
    public interface IDepartmentApiService
    {
        Task<GetDepartmentResult<List<DepartmentResponseModel>>> GetDepartments();
        Task<GetDepartmentResult<DepartmentResponseModel>> GetDepartmentByName(DepartmentSearch departmentSearch);
        Task<ServiceResult> SaveDepartment(DepartmentModel createModel);
        Task<ServiceResult> UpdateDepartment(DepartmentModel UpateModel);
    }
}
