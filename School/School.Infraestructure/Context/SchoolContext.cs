

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infraestructure.Context
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

      
        #region "DbSet"
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Course>? Courses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingGeneratedProcedures(modelBuilder);
        }
    }
}
