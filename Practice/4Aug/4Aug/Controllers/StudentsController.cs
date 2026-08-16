using _4Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _4Aug.Services;
using _4Aug.Models;


namespace _4Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
              return Ok(_service.GetAll()); 
        }

        [HttpGet("{id}")]
        public IActionResult GetIdq(int id)
        {
            var student = _service.GetStudent(id);
            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
                
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
           _service.AddStudent(student);
            return Ok(student);
        }
       
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            var existing = _service.GetStudent (id);

            if (existing == null)
                return NotFound();

            _service.UpdateStudent(student);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
                return NotFound();
            _service.DeleteStudent(id);

            return Ok(student);
        }

    }
}
