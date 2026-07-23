using _23July.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _23July.Controllers
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
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("User", username);

                return RedirectToAction("Index", "Product");
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
