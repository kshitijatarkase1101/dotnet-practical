using System;

public class Course
{
    public int courseId;
    public string courseName;
    public int credits;

    public Course(int i , string n , int c)
    {
        courseId=i;
        courseName=n;
        credits=c;
    }

     public void DisplayCourse()
    {
        Console.WriteLine($"Course ID : {courseId}");
        Console.WriteLine($"Course Name : {courseName}");
        Console.WriteLine($"Credits : {credits}");
    }

}
    