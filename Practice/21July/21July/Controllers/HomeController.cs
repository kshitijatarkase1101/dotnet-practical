using _21July.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller { 
//display form
public ActionResult Register()
  {
        return View();
  } 
  //handle form submission
  [HttpPost] 
    public ActionResult Register(Student student)
    { if (ModelState.IsValid) { TempData["StudentName"] = student.Name;
            return RedirectToAction("Schedule"); 
        } 
        return View(student);
    }
    //course schedule pageuvz
      public ActionResult Schedule() 
    {
        List<Course> course = new List<Course>()
        { 
            new Course { courseName ="asp.net", sem ="sem 3", sessionTime="9.30am - 12.00pm", days="Mon - tue"}, 
            new Course { courseName ="java", sem ="sem 3", sessionTime="9.30am - 11.00am", days="tue - wed"}, 
            new Course { courseName ="html", sem ="sem 3", sessionTime="9.30am - 11.00am", days="fri - sat"}, 
        }; 
        return View(course);
    }
}