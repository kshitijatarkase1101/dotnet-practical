using System;

public class Student
{
  public int rollno;
  public String name;
  public String institute;
  public long dob;
  public String branch;
  public char gender;
  public float height;
 public Student(int r, String n, String i, String b, long d, char g, float h)
    {
      rollno = r;
      name = n;
      institute = i;
      branch = b;
      dob = d;
      gender = g;
      height = h;
    }
  public void Display()
    {
        Console.WriteLine("Rollno:"+rollno);
        Console.WriteLine("Name:"+name);
        Console.WriteLine("Institute:"+ institute);
        Console.WriteLine("Branch:"+ branch);
        Console.WriteLine("D.O.B:"+ dob);
        Console.WriteLine("Gender:"+ gender);
        Console.WriteLine("Height:"+ height);
        
        

    }
}