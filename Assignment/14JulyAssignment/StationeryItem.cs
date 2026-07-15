using System;

public class StationeryItem : Product
{
    private int itemId;
    private string itemName;
    private string category;
    private double price;
    private int quantity;
    private string brand;

    public int ItemId
    {
        get { return itemId; }
        set { itemId = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                throw new InvalidPriceException("Price must be greater than 0.");

            price = value;
        }
    }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value < 0)
                throw new InvalidQuantityException("Quantity cannot be negative.");

            quantity = value;
        }
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Item ID   : {ItemId}");
        Console.WriteLine($"Name      : {ItemName}");
        Console.WriteLine($"Category  : {Category}");
        Console.WriteLine($"Brand     : {Brand}");
        Console.WriteLine($"Price     : {Price}");
        Console.WriteLine($"Quantity  : {Quantity}");
    }

    public void UpdateQuantity(int qty)
    {
        Quantity = qty;
    }

    public override double CalculateDiscount(double amount)
    {
        return amount * 0.02; // Base discount
    }
}