using _4Aug.Models;

namespace _4Aug.Repository
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);

    }
}
