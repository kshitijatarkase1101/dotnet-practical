using _12Aug.Models;
using _12Aug.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _12Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service= service;
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Student")]
        public IActionResult GetAll()
        {
            var students = service.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id) 
        {
            var student = service.GetStudentById(id);
            if (student == null)
                return NotFound("Student not found");
            return Ok(student);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(Student student)
        {
            var student1 = service.AddStudent( student);
            return Ok(student1);
        }
    }
}
