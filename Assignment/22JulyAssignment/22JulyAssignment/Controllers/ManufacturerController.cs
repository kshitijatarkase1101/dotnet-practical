using _22JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22JulyAssignment.Controllers
{
    public class ManufacturerController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                return View("Display", manufacturer);
            }

            return View(manufacturer);
        }

        public IActionResult Display(Manufacturer manufacturer)
        {
            return View(manufacturer);
        }
    }
}
