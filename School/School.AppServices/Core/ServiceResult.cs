

namespace School.AppServices.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public dynamic? Data { get; set; }
    }
}
