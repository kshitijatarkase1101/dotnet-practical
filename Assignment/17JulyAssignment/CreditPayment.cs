
using System;

public class CreditPayment : Payment
{
    public override string ProcessPayment(double amount)
    {
        Console.WriteLine($"Credit Card Payment of ₹{amount} Successful.");
        return "Success";
    }
}