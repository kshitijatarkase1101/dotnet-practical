using System;

public class Coupon
{
    public string Code { get; set; }
    public double DiscountPercentage { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Code} - {DiscountPercentage}% OFF");
    }
}