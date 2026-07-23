using System.ComponentModel.DataAnnotations;

namespace _21JulyAssignment.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Enployee ID is mandatory")]public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enployee Name is mandatory")] public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Department is mandatory")] public string Department {  get; set; }
        [Required(ErrorMessage = "Salary is mandatory")] public int Salary {  get; set; }
        [Required(ErrorMessage = "Email is mandatory")] public string Email {  get; set; }
    }
}
