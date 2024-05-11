using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;

namespace MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepo _departmentsRepo;

        public DepartmentController(DepartmentRepo repo)
        {
            _departmentsRepo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
