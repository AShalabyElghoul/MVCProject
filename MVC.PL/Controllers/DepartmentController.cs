using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;

namespace MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public IActionResult Index()
        {
            var department = _unitOfWork.DepartmentRepo.GetAll();
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
               var count= _unitOfWork.DepartmentRepo.Add(department);
                _unitOfWork.Complete();
                if(count>0)
                  return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Details(int? Id , string viewName="Details")
        {
            if(Id is null)
                return BadRequest();
          
            var department = _unitOfWork.DepartmentRepo.GetById(Id.Value);
            if (department == null)
                return NotFound();
            return View(viewName, department);
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
           return Details(Id , "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id , Department department) {

            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
               var count = _unitOfWork.DepartmentRepo.Update(department);
                _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete (int? Id)
        {
            var department = _unitOfWork.DepartmentRepo.GetById(Id.Value);
          
            return View(department);
        }  
        
        [HttpPost]
        public IActionResult Delete (Department department)
        {
            _unitOfWork.DepartmentRepo.Delete(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index" , "Department");
        }


    }
}
