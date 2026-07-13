
using System;

class Program
{

    static void StudentManagementMenu(StudentManager studentManager)
{
    bool back = false;

    while (!back)
    {
        Console.WriteLine("\n--- Student Management ---");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. Search Student");
        Console.WriteLine("4. Back");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                

                 Console.Write("Enter Student ID: ");
                 int id = Convert.ToInt32(Console.ReadLine());

                 Console.Write("Enter Student Name: ");
                 string name = Console.ReadLine();

                 Console.Write("Enter Department: ");
                string department = Console.ReadLine();

                 Console.Write("Enter Student Type: ");
                string type = Console.ReadLine();

                  Student newstudent = new Student(id, name, department, type);

                 studentManager.AddStudent(newstudent);

    
                break;

            case 2:
                studentManager.viewStudent();
                break;

            case 3:
                Console.WriteLine("Enter student ID:");
                int sid=Convert.ToInt32(Console.ReadLine());

                Student foundstudent = studentManager.SearchStudent(sid);
                                 if (foundstudent != null)
                {
                      foundstudent.DisplayStudent();
                }
                else
                 {
                         Console.WriteLine("Student not found.");
                 }
                break;

            case 4:
                back = true;
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}
static void CourseManagementMenu(CourseManager courseManager)
{
    bool back = false;

    while (!back)
    {
        Console.WriteLine("\n--- Course Management ---");
        Console.WriteLine("1. Add Course");
        Console.WriteLine("2. View Course");
        Console.WriteLine("3. Search Course");
        Console.WriteLine("4. Back");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                

                 Console.Write("Enter Course ID: ");
                 int cid = Convert.ToInt32(Console.ReadLine());

                 Console.Write("Enter Course Name: ");
                 string name = Console.ReadLine();

                 Console.Write("Enter course credits ");
                  int credits = Convert.ToInt32(Console.ReadLine());

                  Course newcourse = new Course(cid, name, credits);

                 courseManager.AddCourse(newcourse);

    
                break;

            case 2:
                courseManager.viewCourse();
                break;

            case 3:
                Console.WriteLine("Enter course ID:");
                int Id=Convert.ToInt32(Console.ReadLine());

                Course foundcourse = courseManager.SearchCourse(Id);
                                 if (foundcourse != null)
                {
                      foundcourse.DisplayCourse();
                }
                else
                 {
                         Console.WriteLine("Course not found.");
                 }
                break;

            case 4:
                back = true;
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}




    static void Main(string[] args)
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Course Management");
            Console.WriteLine("3. Register Course");
            Console.WriteLine("4. View Student Details");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentManagementMenu(studentManager);
                
                    break;

                case "2":
                    CourseManagementMenu(courseManager);
                    break;

                case "3": 
                    

    Console.Write("Enter Student ID: ");
    int studentId = Convert.ToInt32(Console.ReadLine());

    Student student = studentManager.SearchStudent(studentId);

    if (student == null)
    {
        Console.WriteLine("Student not found.");
        break;
    }

    Console.Write("Enter Course ID: ");
    int courseId = Convert.ToInt32(Console.ReadLine());

    Course course = courseManager.SearchCourse(courseId);

    if (course == null)
    {
        Console.WriteLine("Course not found.");
        break;
    }

    student.RegisterCourse(course);

    break;
    
                    

                case "4":
                    

    Console.Write("Enter Student ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    studentManager.DisplayStudentDetails(id);

    break;
                    

                case "5":
                    exit = true;
                    Console.WriteLine("Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
    


