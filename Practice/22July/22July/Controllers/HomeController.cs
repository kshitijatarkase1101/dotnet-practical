using _22July.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _22July.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Stationary()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Stationary(Stationary stationary)
        {
            if (ModelState.IsValid)
            {
                return Content($"Stationary ID : {stationary.Id} , " + $"Stationary Name: {stationary.Name} , " + $"Price : {stationary.Price}," + $"Quantity: {stationary.Quantity}," );
            }
            return View(stationary);
        }

    }
}
