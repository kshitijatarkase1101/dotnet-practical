using System;

public class DebitPayment : Payment
{
    public override string ProcessPayment(double amount)
    {
        Console.WriteLine($"Debit Card Payment of ₹{amount} Successful.");
        return "Success";
    }
}