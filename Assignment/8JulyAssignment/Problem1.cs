using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

class Problem1
{
    public static void Main()
    {
      int totalsales = 0;
      int Min=4000000;
      int Max = 4000000;
      int[] Salary = {4000000,2000000,3000000,6000000,7000000,5000000};
      
      Console.WriteLine("Sales by 6 emplyees:");
      foreach(int s in Salary)
        {
            totalsales += s;
            Console.WriteLine(s);

            if(s<=Min)
            {
                Min = s;
            }
            else if( s> Max)
            {
                Max = s;
            }
        

            
            
        }  
        Console.WriteLine("Total sales by employees="+totalsales);
        Console.WriteLine("Average Sales = "+(totalsales/6));
        Console.WriteLine("Lowest Sales="+ Min);
        Console.WriteLine("Highest Sales="+Max);
    }
}
