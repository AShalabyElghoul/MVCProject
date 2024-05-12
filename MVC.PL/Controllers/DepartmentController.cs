using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;

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
        [HttpGet]
        public IActionResult Create() {
            return View();
        
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
               var count= _departmentsRepo.Add(department);
                if(count>0)
                  return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Details(int? Id)
        {
            if(Id is null)
                return BadRequest();
          
            var department = _departmentsRepo.GetById(Id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }
    }
}
