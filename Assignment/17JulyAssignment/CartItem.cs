using System;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public double TotalPrice()
    {
        return Product.GetDiscountPrice() * Quantity;
    }

    public void Display()
    {
        Console.WriteLine($"{Product.ProductName} x {Quantity} = ₹{TotalPrice()}");
    }
}