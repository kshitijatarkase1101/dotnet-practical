using System;

class data_types
{
    static void Main(string[]args)
    {
int Roll_no=16;      
float CGPA=8.9f;
double pi= 3.14;

char Gender='F';
Console.WriteLine("  ");

Console.WriteLine("Printing variables of different data types");
Console.WriteLine("Roll_no="+Roll_no);
Console.WriteLine(pi);
Console.WriteLine(CGPA);
Console.WriteLine(Gender);

Variable_Operator v = new Variable_Operator();
v.display();

    }
}
