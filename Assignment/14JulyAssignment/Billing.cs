using System;

namespace StationeryStoreManagement
{
    public class Billing : IBill
    {
        public void GenerateBill(StationeryItem item, int quantity)
        {
            double amount = item.Price * quantity;

            double discount = item.CalculateDiscount(amount);

            double taxableAmount = amount - discount;

            double gst = taxableAmount * 0.18;

            double total = taxableAmount + gst;

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("              BILL");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Item       : {item.ItemName}");
            Console.WriteLine($"Brand      : {item.Brand}");
            Console.WriteLine($"Price      : {item.Price}");
            Console.WriteLine($"Quantity   : {quantity}");
            Console.WriteLine($"Amount     : {amount}");
            Console.WriteLine($"Discount   : {discount}");
            Console.WriteLine($"GST (18%)  : {gst}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Total Bill : {total}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}