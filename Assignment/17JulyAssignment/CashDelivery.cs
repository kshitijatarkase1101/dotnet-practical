using System;

public class CashDelivery : Payment
{
    public override string ProcessPayment(double amount)
    {
        Console.WriteLine("Cash On Delivery Selected.");
        return "Pending";
    }
}