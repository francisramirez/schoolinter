

namespace School.Domain.Entities
{
    public class Department : Core.BaseEntity
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }

        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }

    }
}
