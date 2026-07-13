using System;
using System.Collections.Generic;

class CourseManager
{
    
    List<Course> courses = new List<Course>();

    public void AddCourse(Course course)
    {
        foreach (Course c in courses)
        {
            if(c.courseId == course.courseId)
            {
                Console.WriteLine("Course already added");
                return;
            }
        }
        
        courses.Add(course);
        Console.WriteLine("course added successfully");
    }
    public void viewCourse()
    {
        if(courses.Count == 0)
                        {
                            Console.WriteLine("No course aaded ");

                        }
                        else
                        {
                            foreach(Course c in courses)
                            {
                                c.DisplayCourse();
                            }
                        }
    }

    public Course SearchCourse(int courseId)
    {
                            
                            
                            
                            foreach(Course c in courses)
                        {
                            if(c.courseId == courseId)
                            {
                                return c;
                                
                
                            }
                        }
                        return null;
                               
    }

    
    
    
    
    
    
   
}

