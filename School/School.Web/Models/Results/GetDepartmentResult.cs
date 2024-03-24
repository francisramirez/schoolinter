namespace School.Web.Models.Results
{
    public class GetDepartmentResult<TModel> : ServiceResult
    {
        public TModel data { get; set; }
    }

    
}
