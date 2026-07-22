using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Student
{
    public int studentId ;
    public string studentName ;
    public string Department ;
    public string Stype;
    
    public List<Course> EnrolledCourses = new List<Course>();

    

    public Student( int i , string e, string d , string t)
    {
        studentId =i;
        studentName= e;
        Department= d;
        Stype=t;
    }

        public void DisplayStudent()
    {
        Console.WriteLine("Id : "+ studentId);
         Console.WriteLine("Name : "+ studentName);
          Console.WriteLine("Department: "+ Department);
          Console.WriteLine("Student type: "+ Stype);
           
            Console.WriteLine("----------------");
    }

    public void RegisterCourse(Course course)
{
    // Check for duplicate course
    foreach (Course c in EnrolledCourses)
    {
        if (c.courseId == course.courseId)
        {
            Console.WriteLine("Course already registered.");
            return;
        }
    }

    // Maximum 5 courses
    if (EnrolledCourses.Count >= 5)
    {
        Console.WriteLine("Maximum course limit reached.");
        return;
    }

    EnrolledCourses.Add(course);
    Console.WriteLine("Course registered successfully.");
}
public void DisplayCourses()
{
    if (EnrolledCourses.Count == 0)
    {
        Console.WriteLine("No courses enrolled.");
        return;
    }

    Console.WriteLine("\nEnrolled Courses");

    foreach (Course c in EnrolledCourses)
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Course ID : " + c.courseId);
        Console.WriteLine("Course Name : " + c.courseName);
        Console.WriteLine("Credits : " + c.credits);
    }
}
public int TotalCredits()
{
    int total = 0;

    foreach (Course c in EnrolledCourses)
    {
        total += c.credits;
    }

    return total;
}
public double CalculateFee()
{
    int totalCredits = TotalCredits();

    if (Stype == "Regular")
    {
        return totalCredits * 5000;
    }
    else if (Stype == "Scholarship")
    {
        return totalCredits * 2500;
    }
    else if (Stype == "Part-Time")
    {
        return totalCredits * 4000;
    }

    return 0;
}
public void DisplayStudentDetails()
{
    
      DisplayStudent();
     DisplayCourses();

      Console.WriteLine("Total Credits : " + TotalCredits());
      Console.WriteLine("Total Fee : " + CalculateFee());

    
}
}

