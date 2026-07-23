using _16july.Models;
using _16July.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16july.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student { Id =1, Name = "Priya", Age=20, Course="C#", Qualification="BE CSE", Gender='F'},
                new Student { Id =2, Name = "Shweta", Age=22, Course="ASP.NET",Qualification="BE IT", Gender='F'},
                new Student { Id =3, Name = "Rakesh", Age=21, Course="Java", Qualification="BE CSE", Gender='M'},
                new Student { Id =4, Name = "Hemant", Age=20, Course="Python", Qualification="BE IT", Gender='M'},
                new Student { Id =5, Name = "Sam", Age=24, Course="F#", Qualification="BE IT", Gender='F'},

            };
            return View(students);
        }

        
    }
}
