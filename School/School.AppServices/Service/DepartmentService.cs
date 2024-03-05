using School.AppServices.Contracts;
using School.AppServices.Core;
using School.Infraestructure.Interfaces;

namespace School.AppServices.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDb departmentDb;

        public DepartmentService(IDepartmentDb departmentDb)
        {
            this.departmentDb = departmentDb;
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
