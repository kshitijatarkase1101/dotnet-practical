using System;

public class Pen : StationeryItem
{
    public string InkColor { get; set; }
    public string PenType { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();

        Console.WriteLine($"Ink Color : {InkColor}");
        Console.WriteLine($"Pen Type  : {PenType}");
        Console.WriteLine("--------------------------------");
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.05; // 5%
    }
}