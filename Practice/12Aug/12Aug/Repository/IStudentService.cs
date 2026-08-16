using _12Aug.Models;

namespace _12Aug.Repository
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudentById(int id);
        Student AddStudent(Student student) ;

    }
}
