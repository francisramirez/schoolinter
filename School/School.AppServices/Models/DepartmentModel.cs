
namespace School.AppServices.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }

        public string StartDate { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
