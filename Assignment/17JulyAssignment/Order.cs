using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }

    public List<CartItem> Items { get; set; }

    public double Total { get; set; }
    public double Discount { get; set; }
    public double GST { get; set; }
    public double GrandTotal { get; set; }

    public string Status { get; set; }

    public Order()
    {
        Items = new List<CartItem>();
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Order ID : {OrderId}");
        Console.WriteLine($"Date     : {OrderDate}");
        Console.WriteLine($"Customer : {Customer.CustomerName}");

        Console.WriteLine("\nItems:");

        foreach (CartItem item in Items)
        {
            item.Display();
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total       : ₹{Total}");
        Console.WriteLine($"Discount    : ₹{Discount}");
        Console.WriteLine($"GST         : ₹{GST}");
        Console.WriteLine($"Grand Total : ₹{GrandTotal}");
        Console.WriteLine($"Status      : {Status}");
        Console.WriteLine("--------------------------------");
    }
}