

namespace School.AppServices.Dtos
{
    public record DepartmentAddDto
    {
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
        public int CreateUser { get; set; }

    }
}
