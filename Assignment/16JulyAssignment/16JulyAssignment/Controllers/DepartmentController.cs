using _16JulyAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16JulyAssignment.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>()
            {
                new Department{deptName="HR",deptHead="Mr.Keshav",headContact= 8888851511,headEmail="keshav11@gmail.com"},
                new Department{deptName="IT",deptHead="Ms.Trupti",headContact=9921000433 ,headEmail="trupti22@gmail.com"},
                new Department{deptName="Finance",deptHead="Ms.Divya",headContact= 9850273190,headEmail="divya33@gmail.com"},
                new Department{deptName="Sales",deptHead="Mr.Prakash",headContact=7721482910 ,headEmail="prakash44@gmail.com"},
                new Department{deptName="Marketing",deptHead="Mr.Satish",headContact=9921567109 ,headEmail="satish552gmail.com"},
                new Department{deptName="R&D",deptHead="Ms.Savita",headContact=9823564167 ,headEmail="savita66@gmail.com"},
            };
            return View(departments);
        }
    }
}
