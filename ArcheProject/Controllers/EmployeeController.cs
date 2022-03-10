using Arche.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Arche.Domain;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ArcheProject.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private ApplicationDb _db;
        public EmployeeController(ApplicationDb db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Arche.Domain.Employee> obj = _db.employees.ToList();
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db.employees.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var Emp = _db.employees.Find(Id);
            if (Emp == null)
            {
                return BadRequest();
            }
            return View(Emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db.employees.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var Emp = _db.employees.Find(Id);
            if (Emp == null)
            {
                return BadRequest();
            }
            return View(Emp);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int? Id)
        {
            var emp = _db.employees.Find(Id);
            if (ModelState.IsValid)
            {
                _db.employees.Remove(emp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
