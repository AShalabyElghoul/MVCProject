using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;

namespace MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo _departmentsRepo;

        public DepartmentController(IDepartmentRepo repo)
        {
            _departmentsRepo = repo;
        }

        public IActionResult Index()
        {
            var department = _departmentsRepo.GetAll();
            return View(department);
        }
    }
}
