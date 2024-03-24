
using School.Web.Models;
using School.Web.Models.Results;
using System.Text;
using System.Text.Json;


namespace School.Web.Services
{
    public class DepartmentApiService : IDepartmentApiService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<DepartmentApiService> logger;
        private readonly IHttpClientFactory clientFactory;
        private string baseUrl;
        public DepartmentApiService(IConfiguration configuration,
                                    ILogger<DepartmentApiService> logger,
                                    IHttpClientFactory clientFactory)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.clientFactory = clientFactory;
            this.baseUrl = this.configuration["apiConfig:baseUrl"];
        }
        public async Task<GetDepartmentResult<List<DepartmentResponseModel>>> GetDepartments()
        {
            GetDepartmentResult<List<DepartmentResponseModel>> result = new GetDepartmentResult<List<DepartmentResponseModel>>();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Department/GetDepartments";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetDepartmentResult<List<DepartmentResponseModel>>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetDepartments.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los departmanetos.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }
        public async Task<GetDepartmentResult<DepartmentResponseModel>> GetDepartmentByName(DepartmentSearch departmentSearch)
        {
            GetDepartmentResult<DepartmentResponseModel> result = new GetDepartmentResult<DepartmentResponseModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Department/GetDepartmentByName";

                    StringContent content = new StringContent(JsonSerializer.Serialize(departmentSearch), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<GetDepartmentResult<DepartmentResponseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error conectandose al end point de GetDepartmentByName.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los departmanetos.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }
        public async Task<ServiceResult> SaveDepartment(DepartmentModel createModel)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    var url = $"{this.baseUrl}/Department/Save";

                    StringContent content = new StringContent(JsonSerializer.Serialize(createModel), Encoding.UTF8, "application/json");
                    string resp = string.Empty;
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result = JsonSerializer.Deserialize<ServiceResult>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result = JsonSerializer.Deserialize<ServiceResult>(resp);
                                return result;
                            }
                            else
                            {
                                result.success = false;
                                result.message = "Error conectandose al end point de Save Departments.";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = "Error guardando el departamento.";
                this.logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }

        public Task<ServiceResult> UpdateDepartment(DepartmentModel UpateModel)
        {
            throw new NotImplementedException();
        }
    }
}
