
namespace School.Infraestructure.Models
{
    public class ObtenerDepartamentos
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreationDate { get; set; }
        public string? StartDate { get; set; }
    }
}
