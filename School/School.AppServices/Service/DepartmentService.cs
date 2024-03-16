using School.AppServices.Contracts;
using School.AppServices.Core;
using School.AppServices.Dtos;
using School.Infraestructure.Core;
using School.Infraestructure.Interfaces;
using System.Diagnostics;

namespace School.AppServices.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDb departmentDb;

        public DepartmentService(IDepartmentDb departmentDb)
        {
            this.departmentDb = departmentDb;
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

                result.Message = resp.Value.Equals("OK") ? "Departamento creado correctamente." : resp.Value;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error agregando el departamento { ex.Message }.";
            }
            return result;
        }

        public async Task<ServiceResult> GetDepartmentByName(string name)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.departmentDb.ObtenerDepartamentosPorNombreAsync(name);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo el departamento. { ex.Message }";
            }

            return result;
        }

        public ServiceResult GetDepartments()
        {
            ServiceResult result = new ServiceResult();

            try
            {

                //LINQ
                var query = (from depto in this.departmentDb.GetAll()
                             where depto.Deleted == false
                             orderby depto.CreationDate descending
                             select new Models.DepartmentModel()
                             {
                                 Budget = depto.Budget,
                                 CreationDate = depto.CreationDate,
                                 DepartmentId = depto.DepartmentID,
                                 Name = depto.Name

                             }).ToList();


                //Expresiones lambda //

                //var query2 = this.departmentDb.GetEntitiesWithFilters(cd => cd.Deleted == false)
                //                              .Select(cd => new Models.DepartmentModel() 
                //                              {
                //                                  Budget = cd.Budget,
                //                                  CreationDate = cd.CreationDate,
                //                                  DepartmentId = cd.DepartmentID,
                //                                  Name = cd.Name
                //                              }).ToList();



                


                result.Data = query;

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
