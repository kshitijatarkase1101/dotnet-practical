using _23JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _23JulyAssignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "kshitija" && password == "kshitija111")
            {
                HttpContext.Session.SetString("User", username);

                return RedirectToAction("Index", "Stationary");
            }

            ViewBag.Message = "Invalid username or password";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();      // Remove session
            return RedirectToAction("Login");
        }
    }
}
