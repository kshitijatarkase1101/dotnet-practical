using _21JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace _21JulyAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)

            {

                TempData["EmployeeName"] = employee.EmployeeName;
                TempData["Department"] = employee.Department;
                return RedirectToAction("Department");
            }

                return View(employee);
        }

        public ActionResult Department(){
            List<Department> department = new List<Department>()
            {
                new Department{DepartmentName="HR",DepartmentHead="Mr.Keshav",HeadContact= 8888851511,HeadEmail="keshav11@gmail.com"},
                new Department{DepartmentName="IT",DepartmentHead="Ms.Trupti",HeadContact=9921000433 ,HeadEmail="trupti22@gmail.com"},
                new Department{DepartmentName="Finance",DepartmentHead="Ms.Divya",HeadContact= 9850273190,HeadEmail="divya33@gmail.com"},
                new Department{DepartmentName="Sales",DepartmentHead="Mr.Prakash",HeadContact=7721482910 ,HeadEmail="prakash44@gmail.com"},
                new Department{DepartmentName="Marketing",DepartmentHead="Mr.Satish",HeadContact=9921567109 ,HeadEmail="satish552gmail.com"},
                new Department{DepartmentName="R&D",DepartmentHead="Ms.Savita",HeadContact=9823564167 ,HeadEmail="savita66@gmail.com"},
            };
            return View(department);

            }
    }
}
