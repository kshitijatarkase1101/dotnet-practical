using _12Aug.Data;
using _12Aug.Models;
using _12Aug.Repository;

namespace _12Aug.Services
{
    public class StudentService: IStudentService
    {
        private readonly AppDbContext context;
            public StudentService(AppDbContext context)
        {
            this.context = context;
        }
        
        public List<Student> GetStudents()
        {
            return context.Students12.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return context.Students12.Find(id);
        }

        public Student AddStudent(Student student)
        {
            context.Students12.Add(student);
            context.SaveChanges();
            return student;


        }

        
    }
}
