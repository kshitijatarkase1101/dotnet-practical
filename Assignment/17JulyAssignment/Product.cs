using System;
using System.Collections.Generic;

public class Product
{
  public int ProductId{ get; set;}
  public string ProductName{ get; set;}
  public string Category{get; set;}
  public string Description{ get; set;}
  public int Price{get; set;}
  public int Quantity{ get; set;}
  public string Brand{ get; set;}
  public double Discount{ get; set;}
  public int Rating{ get; set;}

  public void Display()
    {
        Console.WriteLine("Product Id:"+ProductId);
        Console.WriteLine("Product Name:"+ProductName);
        Console.WriteLine("Product Category:"+ Category);
        Console.WriteLine("Product Description:"+ Description);
        Console.WriteLine("Product Price:"+ Price);
        Console.WriteLine("Product Quantity:"+ Quantity);
        Console.WriteLine("Product Brand:"+ Brand);
        Console.WriteLine("Product Discount :"+ Discount);
    }

    public void Update()
    {
       
    Console.Write("Enter Product Name : ");
    ProductName = Console.ReadLine();

    Console.Write("Enter Category : ");
    Category = Console.ReadLine();

    Console.Write("Enter Description : ");
    Description = Console.ReadLine();

    Console.Write("Enter Brand : ");
    Brand = Console.ReadLine();

    Console.Write("Enter Price : ");
    Price = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Quantity : ");
    Quantity = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Discount : ");
    Discount = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter Rating : ");
    Rating = Convert.ToInt32(Console.ReadLine());
}

    public double GetDiscountPrice()
    {
        return Price - (Price * Discount / 100);
    }

}