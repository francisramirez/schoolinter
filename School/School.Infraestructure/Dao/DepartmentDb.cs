

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using School.Domain.Entities;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;
using School.Infraestructure.Models;
using School.Infraestructure.Extentions;
namespace School.Infraestructure.Dao
{
    public class DepartmentDb : DaoBase<Department>, IDepartmentDb
    {
        private readonly SchoolContext context;
        private readonly ILogger<DepartmentDb> logger;
        private readonly IConfiguration configuration;

        public DepartmentDb(SchoolContext context,
                            ILogger<DepartmentDb> logger,
                            IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

       
        public override List<Department> GetAll()
        {
            return base.GetEntitiesWithFilters(dep => !dep.Deleted);
        }
        public override DataResult Save(Department entity)
        {
            DataResult result = new DataResult();

            try
            {

                
                if (base.Exists(dep => dep.Name == entity.Name))
                    throw new DepartmentException(this.configuration["DepartmentMessage:NameDuplicate"]);

                base.Save(entity);
                base.Commit();

            }
            catch (Exception ex)
            {

                result.Message = this.configuration["DepartmentMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }
        public override DataResult Update(Department entity)
        {
            DataResult result = new DataResult();
            try
            {
              
                Department departmentToUpdate = base.GetById(entity.DepartmentID);

                departmentToUpdate.ModifyDate = entity.ModifyDate;
                departmentToUpdate.UserMod = entity.UserMod;
                departmentToUpdate.Name = entity.Name;
                departmentToUpdate.StartDate = entity.StartDate;
                departmentToUpdate.Budget = entity.Budget;
                departmentToUpdate.Administrator = entity.Administrator;


                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {

                result.Message = this.configuration["DepartmentMessage:ErrorUpdate"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        #region "Llamadas a los procedures"
        public async Task<int> AgregarDepartamentoAsync(string p_Name, 
                                                       decimal? p_Budget, 
                                                       DateTime? p_StartDate, 
                                                       int? p_Administrator, 
                                                       int? p_CreateUser, 
                                                       OutputParameter<string> p_result, 
                                                       OutputParameter<int> returnValue = null,
                                                       CancellationToken cancellationToken = default)
        {
           
            var parameterp_result = new SqlParameter
            {
                ParameterName = "p_result",
                Size = -1,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = p_result?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_Name",
                    Size = 100,
                    Value = p_Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Budget",
                    Precision = 19,
                    Scale = 4,
                    Value = p_Budget ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                new SqlParameter
                {
                    ParameterName = "p_StartDate",
                    Value = p_StartDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "p_Administrator",
                    Value = p_Administrator ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_CreateUser",
                    Value = p_CreateUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterp_result,
                parameterreturnValue,
            };
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AgregarDepartamento] @p_Name, @p_Budget, @p_StartDate, @p_Administrator, @p_CreateUser, @p_result OUTPUT", sqlParameters, cancellationToken);
                     
            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerDepartamentos>> ObtenerDepartamentosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await this.context.SqlQueryAsync<ObtenerDepartamentos>("EXEC @returnValue = [dbo].[ObtenerDepartamentos]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerDepartamentos>> ObtenerDepartamentosPorNombreAsync(string p_Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_Name",
                    Size = 50,
                    Value = p_Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };

           
            var data = await this.context.SqlQueryAsync<ObtenerDepartamentos>("EXEC @returnValue = [dbo].[ObtenerDepartamentosPorNombre] @p_Name", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return data;
        }

        public async Task<int> UpdateDepartamentoAsync(int? p_DepartmentId, string p_Name, decimal? p_Budget, DateTime? p_StartDate, int? p_Administrator, int? p_ModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterp_result = new SqlParameter
            {
                ParameterName = "p_result",
                Size = -1,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = p_result?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_DepartmentId",
                    Value = p_DepartmentId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_Name",
                    Size = 100,
                    Value = p_Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Budget",
                    Precision = 19,
                    Scale = 4,
                    Value = p_Budget ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                new SqlParameter
                {
                    ParameterName = "p_StartDate",
                    Value = p_StartDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "p_Administrator",
                    Value = p_Administrator ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_ModifyUser",
                    Value = p_ModifyUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterp_result,
                parameterreturnValue,
            };
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdateDepartamento] @p_DepartmentId, @p_Name, @p_Budget, @p_StartDate, @p_Administrator, @p_ModifyUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        #endregion

    }
}
