class Genericeg{
void Printt(int number)
{
    Console.WriteLine(number);

}
void Printt1(int namee)
{
    Console.WriteLine(namee);
    
}
}

//generics -  write one class or method that works with diff data type

public class Genericeg<T>
{
    public void Print(T value)
    {
        Console.WriteLine(value);
    }
}