using System;

public class UpiPayment : Payment
{
    public override string ProcessPayment(double amount)
    {
        Console.WriteLine($"UPI Payment of ₹{amount} Successful.");
        return "Success";
    }
}