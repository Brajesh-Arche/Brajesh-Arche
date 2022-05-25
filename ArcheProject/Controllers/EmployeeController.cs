using Arche.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Arche.Domain;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using ArcheProject.Models;
using Newtonsoft.Json;

namespace ArcheProject.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private ApplicationDb _db;
        private readonly IDistributedCache _distributedCache;
        public EmployeeController(ApplicationDb db,IDistributedCache distributedCache)
        {
            _db = db;
            this._distributedCache= distributedCache;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var newemployees ="";
            //IEnumerable<Employee> obj = _db.employees.ToList();
            var employees=new List<EmployeeModel>();
            var employeecache = _distributedCache.GetString("Employees");
            if (employeecache != null)
            {
                var newemployees = JsonConvert.DeserializeObject<List<EmployeeModel>>(employeecache);
                //_distributedCache.Remove("Employees");

                if (employees !=newemployees || string.IsNullOrEmpty(_distributedCache.GetString("Employees")))
                {
                    employees = _db.employees.Select(x => new EmployeeModel {
                        EmployeeName = x.EmployeeName,
                        Designation = x.Designation,
                        DataRetriveon = System.DateTime.Now,
                        Email = x.Email,
                        gender = x.Gender,
                        Id = x.Id,
                        Salary = x.Salary
                    }).ToList();

                    var employeesInString = JsonConvert.SerializeObject(employees);
                    _distributedCache.SetString("Employees", employeesInString);
                }
            }
            else
            {
                var employeeFromCache = _distributedCache.GetString("Employees");
                if (employeeFromCache != null)
                {
                    employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(employeeFromCache);
                    _distributedCache.Remove("Employees");
                }

            }
            return View(employees);
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
