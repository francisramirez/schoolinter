namespace School.Web.Models
{
    public class DepartmentModel
    {
        public int DeparmentId { get; set; }

        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
