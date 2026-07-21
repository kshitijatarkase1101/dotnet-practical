using System;

public class Customer
{
    public int CustomerId{ get; set;}
    public string CustomerName{ get; set;}
    public string Email{ get; set;}
    public long Phone{ get; set;}
    public string Address{ get; set;}
    public string Username{ get; set;}
    public int Password{ get; set;}

    public List<CartItem> Cart { get; set; }
    public List<Order> Orders { get; set; }

    public Customer()
    {
        Cart = new List<CartItem>();
        Orders = new List<Order>();
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"ID       : {CustomerId}");
        Console.WriteLine($"Name     : {CustomerName}");
        Console.WriteLine($"Email    : {Email}");
        Console.WriteLine($"Phone    : {Phone}");
        Console.WriteLine($"Address  : {Address}");
        Console.WriteLine($"Username : {Username}");
        Console.WriteLine("--------------------------------");
    }
   
}


