

using Microsoft.Extensions.DependencyInjection;
using School.AppServices.Contracts;
using School.AppServices.Service;
using School.Infraestructure.Dao;
using School.Infraestructure.Interfaces;

namespace School.IOC.CourseDependencies
{
    public static class CourseDependency
    {
        public static void AddCourseDependency(this IServiceCollection services)
        {
            services.AddScoped<ICourseDb, CourseDb>();
            services.AddTransient<ICourseService, CourseService>();
        }
    }
}
