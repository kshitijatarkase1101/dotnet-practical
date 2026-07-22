using _16JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16JulyAssignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmployeeID = 101, EmployeeName = "Madhav", Department = "HR", Salary = 70000, Email = "madhav101@gmail.com" },
                new Employee { EmployeeID = 101, EmployeeName = "Radha", Department = "R&D", Salary = 65000, Email = "radha102@gmail.com" },
                new Employee { EmployeeID = 101, EmployeeName = "Subhadra", Department = "Finance", Salary = 60000, Email = "subhadra103@gmail.com" },
                new Employee { EmployeeID = 101, EmployeeName = "Krish", Department = "Sales", Salary = 56000, Email = "krish104@gmail.com" },
                new Employee { EmployeeID = 101, EmployeeName = "Rohini", Department = "R&D", Salary = 65000, Email = "rohini105@gmail.com" },
                new Employee { EmployeeID = 101, EmployeeName = "Keshav", Department = "Marketing", Salary = 55000, Email = "keshav106@gmail.com" },

            };
            return View(employees);
        }

       
    }
}
