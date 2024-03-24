using Microsoft.AspNetCore.Mvc;
using School.Web.Models;
using School.Web.Services;

namespace School.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentApiService departmentApi;

        public DepartmentController(IDepartmentApiService departmentApi)
        {
            this.departmentApi = departmentApi;
        }
        public async Task<IActionResult> Index()
        {
            var result = await this.departmentApi.GetDepartments();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var deparments = result.data;

            return View(deparments);
        }
        public async Task<IActionResult> Edit(DepartmentSearch search)
        {

            var result = await this.departmentApi.GetDepartmentByName(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var deparments = result.data;

            return View(deparments);
        }
        public async Task<IActionResult> Details(DepartmentSearch search)
        {
            var result = await this.departmentApi.GetDepartmentByName(search);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            var deparments = result.data;

            return View(deparments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentModel departmentModel) 
        {
            departmentModel.ChangeDate = DateTime.Now;
            departmentModel.UserId = 1;
            var result = await this.departmentApi.SaveDepartment(departmentModel);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
