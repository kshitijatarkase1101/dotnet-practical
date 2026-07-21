using System;

public class PaymentManager
{
    public string MakePayment(double amount)
    {
        Console.WriteLine("\n========== Payment ==========");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. Debit Card");
        Console.WriteLine("3. UPI");
        Console.WriteLine("4. Cash On Delivery");
        Console.Write("Choose Payment Method : ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Payment payment = null;

        switch (choice)
        {
            case 1:
                payment = new CreditPayment();
                break;

            case 2:
                payment = new DebitPayment();
                break;

            case 3:
                payment = new UpiPayment();
                break;

            case 4:
                payment = new CashDelivery();
                break;

            default:
                Console.WriteLine("Invalid Payment Method.");
                return "Failed";
        }

        string status = payment.ProcessPayment(amount);

        Console.WriteLine("Payment Status : " + status);

        return status;
    }
}