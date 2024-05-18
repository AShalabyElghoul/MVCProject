using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;
using MVC.PL.Helpers;
using MVC.PL.ViewModels.Employee;

namespace MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork  ,IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;

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
            return View(new CreateEditViewModel());
        }
        [HttpPost]
        public IActionResult Create(CreateEditViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
               // DocumentSetting.UploadFile();
               var mappedEmp = _mapper.Map<Employee>(employeeVM);
                _unitOfWork.EmployeeRepo.Add(mappedEmp);
               var Count =  _unitOfWork.Complete();
                if(Count>0)
                    return RedirectToAction("Index");
            }
            return View(employeeVM);
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
               var count= _unitOfWork.Complete();
                if(count>0)
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
                _unitOfWork.Complete();
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
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
