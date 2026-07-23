using _22JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _22JulyAssignment.Controllers
{
    public class AutomobileController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                TempData["VehicleName"] = automobile.VehicleName;
                TempData["Brand"] = automobile.Brand;
                return RedirectToAction("Success");
               
            }
            return View(automobile);
        }
        public IActionResult Success()
        {
            ViewBag.VehicleName = TempData["VehicleName"];
            ViewBag.Brand = TempData["Brand"];

            return View();
        }
    }
}
