using System;
using System.Collections.Generic;

class StudentManager
{
    List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        
        foreach (Student stu in students)
        {
            if(stu.studentId == student.studentId)
            {
                Console.WriteLine("Student already exists");
                return;
            }
        }
        
        students.Add(student);
        Console.WriteLine("Student added successfully");
    }

    public void viewStudent()
    {
        if(students.Count == 0)
                        {
                            Console.WriteLine("No student in System");

                        }
                        else
                        {
                            foreach(Student c in students)
                            {
                                c.DisplayStudent();
                            }
                        }
    }

    public Student SearchStudent(int studentId)
    {
                            
                            
                            
                            foreach(Student stu in students)
                        {
                            if(stu.studentId == studentId)
                            {
                                return stu;
                                
                
                            }
                        }
                        return null;
                               
    }


    public void DisplayStudentDetails(int studentId)
{
    Student student = SearchStudent(studentId);

    if (student == null)
    {
        Console.WriteLine("Student not found.");
        return;
    }

    student.DisplayStudentDetails();
}
    
    
    
    
   
}
