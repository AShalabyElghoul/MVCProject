using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;

namespace MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo=employeeRepo;
        }
        public IActionResult Index()
        {
           var employee= _employeeRepo.GetAll();
            return View(employee);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Add(employee);
                return View("Index");
            }
            return BadRequest();
        }

    }
}
