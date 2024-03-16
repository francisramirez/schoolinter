using Microsoft.EntityFrameworkCore;
using School.Infraestructure.Models;

namespace School.Infraestructure.Context
{
    public partial class SchoolContext
    {
        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObtenerDepartamentos>().HasNoKey().ToView(null);
           
         
        }
    }
}

