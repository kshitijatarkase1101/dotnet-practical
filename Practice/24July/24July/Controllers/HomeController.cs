using _24July.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _24July.Controllers
{
    public class HomeController : Controller
    {
        //Get : login
        public IActionResult Index()
        {
            return View();
        }

        //Post : Login
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Username == "admin" && student.Password == "12345")
                {
                    HttpContext.Session.SetString("User", student.Username);
                    return RedirectToAction("Dashboard");
                }
                ViewBag.Error = "Invalid username or password";
            }
            return View(student);
        }
        public ActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index");
            }

            ViewBag.User = user;
            return View();
        }

        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        
    }
}
