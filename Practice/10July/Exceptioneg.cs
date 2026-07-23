using System;


using System;

class Exceptioneg
{
    static void CheckAge(int age)
    {
        if (age < 20)
        {
            throw new Exception("Not eligible for placement drive");
        }
        Console.WriteLine("Can attend placement drive");
    }
   static void Main()
    {
        try
        {
         int a =50;
         int b =5;
         int c = a/b;
         Console.WriteLine(c);
        }

        catch(DivideByZeroException e)
        {
            Console.WriteLine(e);

        }

        try
        {
            CheckAge(25);
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
}