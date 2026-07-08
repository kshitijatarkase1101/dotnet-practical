// Array - same data type, size is fixed after ceated
// datatype[] = new datatype[size]

using System;

class ArrayEx
{
    public static void Main()
    {
    int[] rollno = {1,2,3,4,5,6,7,8,9,10};
    
    foreach(int r in rollno)
    {
        Console.WriteLine(r);
    }
}
}
