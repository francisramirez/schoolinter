

namespace School.AppServices.Core
{
    public class ServiceResult
    {
       
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public dynamic? Data { get; set; }
    }
}
