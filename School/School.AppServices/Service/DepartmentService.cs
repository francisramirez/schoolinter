using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using School.AppServices.Contracts;
using School.AppServices.Core;
using School.AppServices.Dtos;
using School.Infraestructure.Core;
using School.Infraestructure.Interfaces;


namespace School.AppServices.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDb departmentDb;
        private readonly ILogger<DepartmentService> logger;

        public DepartmentService(IDepartmentDb departmentDb, ILogger<DepartmentService> logger)
        {
            this.departmentDb = departmentDb;
            this.logger = logger;
        }

        public async Task<ServiceResult> AddDepartment(DepartmentAddDto departmentAddDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                OutputParameter<string> resp = new OutputParameter<string>();

                await this.departmentDb.AgregarDepartamentoAsync(
                    departmentAddDto.Name,
                    departmentAddDto.Budget,
                    departmentAddDto.StartDate,
                    departmentAddDto.Administrator,
                    departmentAddDto.CreateUser, resp);

                  
                if (resp.Value.Equals("Ok"))
                    result.Message = "Departamento creado correctamente.";
                else
                {
                    result.Message = resp.Value;
                    result.Success = false;
                }
            
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error agregando el departamento {ex.Message}.";
            }
            return result;
        }

        public async Task<ServiceResult> GetDepartmentByName(string name)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result.Data = (await this.departmentDb.ObtenerDepartamentosPorNombreAsync(name))
                                                      .Select(cd => new Models.DepartmentModel()
                                                      {
                                                          DepartmentId = cd.DepartmentID,
                                                          Budget = cd.Budget,
                                                          Name = cd.Name,
                                                          StartDate = cd.StartDate,
                                                          CreationDate = cd.CreationDate
                                                      }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo el departamento. {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult> GetDepartments()
        {
            ServiceResult result = new ServiceResult();

            try
            {

                //LINQ
                var query = (from depto in await this.departmentDb.GetAll()
                             where depto.Deleted == false
                             orderby depto.CreationDate descending
                             select new Models.DepartmentModel()
                             {
                                 Budget = depto.Budget,
                                 CreationDate = depto.CreationDate,
                                 DepartmentId = depto.DepartmentID,
                                 Name = depto.Name

                             }).ToList();


                result.Data = query;

            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error: {ex.Message}", ex.ToString());
            }

            return result;
        }
    }
}
