

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using School.Domain.Entities;
using School.Infraestructure.Context;
using School.Infraestructure.Core;
using School.Infraestructure.Exceptions;
using School.Infraestructure.Interfaces;

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
    }
}
