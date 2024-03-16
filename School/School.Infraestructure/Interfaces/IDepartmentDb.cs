using School.Domain.Entities;
using School.Infraestructure.Core;
using School.Infraestructure.Dao;
using School.Infraestructure.Models;

namespace School.Infraestructure.Interfaces
{
    public interface IDepartmentDb : IDaoBase<Department>
    {
        Task<int> AgregarDepartamentoAsync(string p_Name, decimal? p_Budget, DateTime? p_StartDate, int? p_Administrator, int? p_CreateUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerDepartamentos>> ObtenerDepartamentosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ObtenerDepartamentos>> ObtenerDepartamentosPorNombreAsync(string p_Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateDepartamentoAsync(int? p_DepartmentId, string p_Name, decimal? p_Budget, DateTime? p_StartDate, int? p_Administrator, int? p_ModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);

    }
}
