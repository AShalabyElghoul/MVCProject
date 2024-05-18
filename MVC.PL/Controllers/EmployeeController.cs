using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;

namespace MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;

        }


        public IActionResult Index(string SearchInp)
        {
            var employee = Enumerable.Empty<Employee>();
            if (String.IsNullOrEmpty(SearchInp))
                 employee = _unitOfWork.EmployeeRepo.GetAll();

            else
                 employee = _unitOfWork.EmployeeRepo.GetByName(SearchInp);

            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department = _unitOfWork.EmployeeRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepo.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Details(int? Id,string ActionName="Details")
        {
            if(Id is not null)
            {
                var employee = _unitOfWork.EmployeeRepo.GetById(Id.Value);
                if (employee is null)
                    return NotFound();
                return View(ActionName,employee);
            }
            return BadRequest();

        }
        public IActionResult Edit(int? Id)
        {
            ViewBag.Department = _unitOfWork.EmployeeRepo.GetAll();
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit (Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepo.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int? Id)
        {
            return Details(Id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete (Employee employee)
        {
                _unitOfWork.EmployeeRepo.Delete(employee);
                return RedirectToAction("Index");
        }

        public IActionResult SoftDelete(int? Id)
        {
            return Details(Id, "SoftDelete");
        }

        [HttpPost]
        public IActionResult SoftDelete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepo.Update(employee);
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
