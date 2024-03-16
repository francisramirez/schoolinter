﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using School.Modeling.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace School.Modeling.Models
{
    public partial class SchoolDbContext
    {
        private ISchoolDbContextProcedures _procedures;

        public virtual ISchoolDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new SchoolDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ISchoolDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObtenerDepartamentosResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<ObtenerDepartamentosPorNombreResult>().HasNoKey().ToView(null);
        }
    }

    public partial class SchoolDbContextProcedures : ISchoolDbContextProcedures
    {
        private readonly SchoolDbContext _context;

        public SchoolDbContextProcedures(SchoolDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> AgregarDepartamentoAsync(string p_Name, decimal? p_Budget, DateTime? p_StartDate, int? p_Administrator, int? p_CreateUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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

            var sqlParameters = new []
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
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AgregarDepartamento] @p_Name, @p_Budget, @p_StartDate, @p_Administrator, @p_CreateUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<ObtenerDepartamentosResult>> ObtenerDepartamentosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<ObtenerDepartamentosResult>("EXEC @returnValue = [dbo].[ObtenerDepartamentos]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<ObtenerDepartamentosPorNombreResult>> ObtenerDepartamentosPorNombreAsync(string p_Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
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
            var _ = await _context.SqlQueryAsync<ObtenerDepartamentosPorNombreResult>("EXEC @returnValue = [dbo].[ObtenerDepartamentosPorNombre] @p_Name", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> UpdateDepartamentoAsync(int? p_DepartmentId, string p_Name, decimal? p_Budget, DateTime? p_StartDate, int? p_Administrator, int? p_ModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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

            var sqlParameters = new []
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
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdateDepartamento] @p_DepartmentId, @p_Name, @p_Budget, @p_StartDate, @p_Administrator, @p_ModifyUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
