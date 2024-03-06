


namespace School.Infraestructure.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credit { get; set; }
        public int DepartmentId { get; set; }
        public string? DeparmentName { get; set; }

        public string? CreationDate { get; set; }

    }
}
