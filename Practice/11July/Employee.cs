using System;
using System.Collections.Specialized;
using System.Dynamic;

public class Employee
{
    public int Id ;
    public string EmpName ;
    public double MonthlySalary ;

    public Employee( int i , string e, double s)
    {
        Id =i;
        EmpName= e;
        MonthlySalary= s;
    }

    double CalculateAnnualSalary()
    {
        return MonthlySalary*12;
    }

    public void Display()
    {
        Console.WriteLine("Id : "+ Id);
         Console.WriteLine("Name : "+ EmpName);
          Console.WriteLine("Monthly Salary: "+ MonthlySalary);
           Console.WriteLine("Annual Salary : "+ CalculateAnnualSalary());
            Console.WriteLine("----------------");
    }
}