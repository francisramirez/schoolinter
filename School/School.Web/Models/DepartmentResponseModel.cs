namespace School.Web.Models
{
    public class DepartmentResponseModel
    {
        public int departmentId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public double budget { get; set; }
        public DateTime creationDate { get; set; }
        public string startDate { get; set; }


    }
}
