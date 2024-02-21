

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infraestructure.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) :base (options)
        {

        }

        #region "DbSet"
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Course>? Courses { get; set; }
        #endregion
    }
}
