namespace School.Api.Models.Department
{
    public class DepartmentBaseModel : BaseModel
    {
        public string? Name { get; set; }

        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }

    }
}
