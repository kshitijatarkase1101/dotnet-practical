//delegate - type that holds a reference to a method
//similar to function pointer
//func
using System;
using System.ComponentModel.DataAnnotations;
//Func< int, int, int> add = (T1,T2) => T1 + T2;
//Console.WriteLine(add(588,768));

delegate void MessageDelegate( string msg);

class Delegateeg
{
    static MessageDelegate m;
    static void Display( string message)
    {
        Console.WriteLine("Method1 : "+message);

    }
    static void Display1( string message)
    {
        Console.WriteLine("Method2 : "+message);

    }
    static void Display2( string message)
    {
        Console.WriteLine("Method3 : "+message);

    }

    static void Main()
    {
       
        
        m +=Display;
        m +=Display1;
        m +=Display2;

        m("Hello , I am learning dotnet c#");

        Button bt = new Button();
        bt.Click +=()  => Console.WriteLine("Click event");
        bt.Press();
    }
}
