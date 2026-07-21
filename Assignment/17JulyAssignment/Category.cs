using System;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public void Display()
    {
        Console.WriteLine("Category ID   : " + CategoryId);
        Console.WriteLine("Category Name : " + CategoryName);
        Console.WriteLine("--------------------------------");
    }
}