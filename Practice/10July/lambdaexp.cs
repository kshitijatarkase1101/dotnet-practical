//Lambda expression = shorter way too write anonymous function 
//parameters  => expression

using System.Security.Cryptography.X509Certificates;

Func<int,int> square = x => x*x ;
Console.WriteLine(square(6));

Func<int,int,int> subb = (a,b) => a-b;
Console.WriteLine(subb(10,50));

void Psubb(int a, int b)
{
    int res = a-b ;
    Console.WriteLine(res);
}
Psubb(50,20);