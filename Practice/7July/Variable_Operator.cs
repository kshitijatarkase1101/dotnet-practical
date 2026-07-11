using System;

class Variable_Operator
{
    
int a = 10;
int b = 3;
 public void display()
    {
Console.WriteLine("  ");
Console.WriteLine("Operations on variables: ");

//arithmetic operations
Console.WriteLine(a+b);
Console.WriteLine(a-b);
Console.WriteLine(a*b);
Console.WriteLine(a/b);
// Increment & Decrement
                    // a is now 11 (Post-increment                // b is now 2  (Post-decrement)
Console.WriteLine(a++);
Console.WriteLine(--b);

//comparison operations
int x= 5, y = 7;
Console.WriteLine(x==y);
Console.WriteLine(x<=y);

//assignment operations
int p=4;
Console.WriteLine(p +=5);
Console.WriteLine(p -=5);

//logical operators
bool m= true, n= false;
Console.WriteLine(m&&n);
Console.WriteLine(m||n);
}
}





