﻿using Microsoft.AspNetCore.Mvc;
using MVC.BL.Interfaces;
using MVC.BL.Repos;
using MVC.DAL.Models;

namespace MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IDepartmentRepo _DeptRepo;
        public EmployeeController(IEmployeeRepo employeeRepo , IDepartmentRepo deptRepo)
        {
            _employeeRepo = employeeRepo;
            _DeptRepo = deptRepo;

        }
        public IActionResult Index()
        {
           var employee= _employeeRepo.GetAll();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department = _DeptRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Details(int? Id,string ActionName="Details")
        {
            if(Id is not null)
            {
                var employee = _employeeRepo.GetById(Id.Value);
                if (employee is null)
                    return NotFound();
                return View(ActionName,employee);
            }
            return BadRequest();

        }
        public IActionResult Edit(int? Id)
        {
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit (Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Update(employee);
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
                _employeeRepo.Delete(employee);
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
                _employeeRepo.Update(employee);
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
