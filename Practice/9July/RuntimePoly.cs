using System;

public class RuntimePoly
{
    public void checkout(PaymentGateway payment, decimal amount)
    {
        payment.ProcessPayment(amount);
    }
    
}