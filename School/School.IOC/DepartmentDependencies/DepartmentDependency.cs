using Microsoft.Extensions.DependencyInjection;
using School.AppServices.Service;
using School.AppServices.Contracts;
using School.Infraestructure.Dao;
using School.Infraestructure.Interfaces;
namespace School.IOC.DepartmentDependencies
{
    public static class DepartmentDependency
    {
        public static void AddDepartmentDependency(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentDb, DepartmentDb>();
            services.AddTransient<IDepartmentService, DepartmentService>();
        }
    }
}
