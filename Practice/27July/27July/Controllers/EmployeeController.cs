using _27July.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _27July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){ id=10 , Name="Mamta", LastName="B",Dept="IT", PhoneNum=5555521233 , Profile="System Engineer", Location="Mumbai"},
             new Employee(){ id=20 , Name="Rekha", LastName="M",Dept="CSE", PhoneNum=77777721233 , Profile="Software Develpoer", Location="Delhi"},
              new Employee(){ id=30 , Name="Sushmita", LastName="P",Dept="IT", PhoneNum=9999921233 , Profile="System Engineer", Location="Banglore"},
              new Employee(){ id=40 , Name="Ram", LastName="s",Dept="IT", PhoneNum=9888921233 , Profile="System Engineer", Location="Mumbai"},
              new Employee(){ id=50 , Name="Jayant", LastName="J",Dept="CSE", PhoneNum=9999921277 , Profile="Cloud Engineer", Location="Banglore"},
              new Employee(){ id=60 , Name="Ravi", LastName="C",Dept="IT", PhoneNum=888889921233 , Profile="Product Manager", Location="Chennai"},
        };

        //get all employee List
        [HttpGet]
        public IActionResult getEmployee()
        {
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x => x.id == id);
            if (employee1 == null)
            {
                return NotFound();
            }
            employee1.LastName = employee.LastName;
            return Ok(employee1);
        }





        [HttpGet("Dept/{dept}")]

        public IActionResult GetEmployeeByDept(string dept)
        {
            var result = employees.Where(s => s.Dept.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound("No Employee found under this dept ");
            }
            return Ok(result);
        }
        [HttpGet("Profile/{profile}")]

        public IActionResult GetEmployeeByProfile(string profile)
        {
            var result = employees.Where(s => s.Profile.Equals(profile, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound("No Employee found under this profile ");
            }
            return Ok(result);
        }
        [HttpGet("Location/{location}")]

        public IActionResult GetEmployeeByLocation(string location)
        {
            var result = employees.Where(s => s.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound("No Employee found under this location ");
            }
            return Ok(result);
        }
    }
}
