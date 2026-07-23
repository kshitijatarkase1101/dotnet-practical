using _23July.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23July.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Home");
            }

            List<Product> products = new List<Product>()
            {
                new Product{ ID = 1, Name="Laptop", Price=70000},
                 new Product{ ID = 2, Name="Bucket", Price=150},
                  new Product{ ID = 3, Name="Earphone", Price=1000},
                   new Product{ ID = 4, Name="Chair", Price=700},

            };

            return View(products);
        }
    }
}
