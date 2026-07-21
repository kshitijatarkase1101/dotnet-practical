using System;

public class Invoice
{
    public int InvoiceId { get; set; }
    public Order Order { get; set; }

    public void PrintInvoice()
    {
        Console.WriteLine("\n=========== SHOPEASE ===========");
        Console.WriteLine($"Invoice ID : {InvoiceId}");
        Console.WriteLine($"Order ID   : {Order.OrderId}");
        Console.WriteLine($"Customer   : {Order.Customer.Name}");
        Console.WriteLine($"Date       : {Order.OrderDate}");

        Console.WriteLine("\nItems");

        foreach (CartItem item in Order.Items)
        {
            item.Display();
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total       : ₹{Order.Total}");
        Console.WriteLine($"Discount    : ₹{Order.Discount}");
        Console.WriteLine($"GST         : ₹{Order.GST}");
        Console.WriteLine($"Grand Total : ₹{Order.GrandTotal}");
        Console.WriteLine("================================");
        Console.WriteLine("Thank You For Shopping!");
    }
}