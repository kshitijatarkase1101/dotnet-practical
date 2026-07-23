using _23JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23JulyAssignment.Controllers
{
    public class StationaryController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Home");
            }

            List<Stationary> stationaries = new List<Stationary>()
            {
                new Stationary{ ID = 1, Name="Notebook", Price=60 , Quantity=2},
                 new Stationary{ ID = 2, Name="ExamBoard", Price=90 , Quantity=1},
                  new Stationary{ ID = 3, Name="Pen", Price=10 , Quantity=5},
                   new Stationary{ ID = 4, Name="Geometry Box", Price=100 , Quantity=1},

            };

            return View(stationaries);
        }
    }
}
