using Microsoft.AspNetCore.Mvc;
using Arche.Repository.Data;
using Arche.Domain;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ArcheProject.Controllers
{
    //[AllowAnonymous]
    public class UserController : Controller
    {
        private ApplicationDb _db;
        public UserController(ApplicationDb db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            using (var con = _db)
            {
                bool isvalid = con.users.Any(x => x.UserName == model.UserName && x.UserPassword == model.UserPassword);
                if(isvalid==true)
                {
                    HttpContext.Response.Cookies.Append("UserName", model.UserName);
                    return RedirectToAction("Index", "Employee");
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                _db.users.Add(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Login");
           
        }
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("UserName");
            return RedirectToAction("Login");
        }
    }
}
