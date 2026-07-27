using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _25_July.Models;

namespace _25_July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student
            {
                id=1 ,
                Name="Kshitija",
                Age=20,
                Department="IT",
            },
            new Student
            {
                id=2 ,
                Name="Rekha",
                Age=21,
                Department="CSE",
            },
            new Student
            {
                id=3 ,
                Name="Mansi",
                Age=19,
                Department="IT",
            },
            new Student
            {
                id=4 ,
                Name="Pooja",
                Age=22,
                Department="CSE",
            },

        };
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students); //200
        }

        [HttpGet("id")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);

            if (student == null)

                return NotFound();

                    return Ok(students);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent),  //created201
                new { id = student.id }, student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent( int id , Student updateStudent)
        {
            var student = students.FirstOrDefault(s=> s.id == id);
            if (student == null)
                return NotFound();

            student.Age = updateStudent.Age;

            return NoContent();
                
         }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);

            return NoContent();

        }


    }
}
