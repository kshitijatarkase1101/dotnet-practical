using System;
using System.Collections.Generic;
using System.Linq;
using StationeryStoreManagement.Exceptions;

namespace StationeryStoreManagement
{
    public class StoreManager
    {
        private List<StationeryItem> items = new List<StationeryItem>();

        // -----------------------------
        // Add Item
        // -----------------------------
        public void AddItem()
        {
            try
            {
                Console.Write("Enter Item ID : ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (items.Any(i => i.ItemId == id))
                    throw new DuplicateItemException();

                Console.Write("Enter Item Name : ");
                string name = Console.ReadLine();

                Console.Write("Enter Category : ");
                string category = Console.ReadLine();

                Console.Write("Enter Brand : ");
                string brand = Console.ReadLine();

                Console.Write("Enter Price : ");
                double price = Convert.ToDouble(Console.ReadLine());

                if (price <= 0)
                    throw new InvalidPriceException();

                Console.Write("Enter Quantity : ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity <= 0)
                    throw new InvalidQuantityException();

                Console.WriteLine("\nSelect Item Type");
                Console.WriteLine("1. Notebook");
                Console.WriteLine("2. Pen");
                Console.WriteLine("3. Marker");

                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                StationeryItem item = null;

                switch (choice)
                {
                    case 1:

                        Notebook notebook = new Notebook();

                        notebook.ItemId = id;
                        notebook.ItemName = name;
                        notebook.Category = category;
                        notebook.Brand = brand;
                        notebook.Price = price;
                        notebook.Quantity = quantity;

                        Console.Write("Enter Pages : ");
                        notebook.Pages = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Paper Type : ");
                        notebook.PaperType = Console.ReadLine();

                        item = notebook;

                        break;

                    case 2:

                        Pen pen = new Pen();

                        pen.ItemId = id;
                        pen.ItemName = name;
                        pen.Category = category;
                        pen.Brand = brand;
                        pen.Price = price;
                        pen.Quantity = quantity;

                        Console.Write("Enter Ink Color : ");
                        pen.InkColor = Console.ReadLine();

                        Console.Write("Enter Pen Type : ");
                        pen.PenType = Console.ReadLine();

                        item = pen;

                        break;

                    case 3:

                        Marker marker = new Marker();

                        marker.ItemId = id;
                        marker.ItemName = name;
                        marker.Category = category;
                        marker.Brand = brand;
                        marker.Price = price;
                        marker.Quantity = quantity;

                        Console.Write("Permanent (true/false) : ");
                        marker.Permanent = Convert.ToBoolean(Console.ReadLine());

                        item = marker;

                        break;

                    default:

                        Console.WriteLine("Invalid Choice.");
                        return;
                }

                items.Add(item);

                Console.WriteLine("\nItem Added Successfully.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // -----------------------------
        // Display All Items
        // -----------------------------
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("\nNo Items Available.");
                return;
            }

            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("ID\tName\tCategory\tBrand\tPrice\tQuantity");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (StationeryItem item in items)
            {
                Console.WriteLine($"{item.ItemId}\t{item.ItemName}\t{item.Category}\t\t{item.Brand}\t{item.Price}\t{item.Quantity}");
            }

            Console.WriteLine("---------------------------------------------------------------");
        }

        // -----------------------------
        // Get Item List
        // -----------------------------
        public List<StationeryItem> GetItems()
        {
            return items;
        }
        // Search Item
public void SearchItem()
{
    try
    {
        if (items.Count == 0)
            throw new ItemNotFoundException("No items available.");

        Console.WriteLine("\nSearch By");
        Console.WriteLine("1. Item ID");
        Console.WriteLine("2. Item Name");

        Console.Write("Enter Choice : ");
        int choice = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = null;

        switch (choice)
        {
            case 1:

                Console.Write("Enter Item ID : ");
                int id = Convert.ToInt32(Console.ReadLine());

                item = items.FirstOrDefault(i => i.ItemId == id);

                break;

            case 2:

                Console.Write("Enter Item Name : ");
                string name = Console.ReadLine();

                item = items.FirstOrDefault(i =>i.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase));

                break;

            default:
                Console.WriteLine("Invalid Choice.");
                return;
        }

        if (item == null)
            throw new ItemNotFoundException();

        Console.WriteLine("\nItem Found");
        Console.WriteLine("---------------------------");
        item.DisplayDetails();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
     // Update Item
public void UpdateItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Enter New Brand : ");
        item.Brand = Console.ReadLine();

        Console.Write("Enter New Price : ");
        double price = Convert.ToDouble(Console.ReadLine());

        if (price <= 0)
            throw new InvalidPriceException();

        item.Price = price;

        Console.Write("Enter New Quantity : ");
        int qty = Convert.ToInt32(Console.ReadLine());

        if (qty <= 0)
            throw new InvalidQuantityException();

        item.Quantity = qty;

        Console.WriteLine("\nItem Updated Successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
      // Delete Item
public void DeleteItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Delete this item? (Y/N): ");
        char ch = Convert.ToChar(Console.ReadLine());

        if (ch == 'Y' || ch == 'y')
        {
            items.Remove(item);
            Console.WriteLine("Item Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("Delete Cancelled.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
public void PurchaseItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Enter Quantity : ");
        int purchaseQty = Convert.ToInt32(Console.ReadLine());

        if (purchaseQty <= 0)
            throw new InvalidQuantityException();

        if (purchaseQty > item.Quantity)
            throw new InsufficientStockException();

        item.Quantity -= purchaseQty;

        Billing bill = new Billing();
        bill.GenerateBill(item, purchaseQty);

        Console.WriteLine();
        Console.WriteLine("Purchase Successful.");
        Console.WriteLine("Remaining Stock : " + item.Quantity);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
public void ViewLowStockItems()
{
    var lowStock = items.Where(i => i.Quantity < 5).ToList();

    if (lowStock.Count == 0)
    {
        Console.WriteLine("\nNo Low Stock Items.");
        return;
    }

    Console.WriteLine("\n----------- LOW STOCK ITEMS -----------");
    Console.WriteLine("ID\tName\t\tQuantity");

    foreach (var item in lowStock)
    {
        Console.WriteLine($"{item.ItemId}\t{item.ItemName}\t\t{item.Quantity}");
    }
}
public void SortItems()
{
    if (items.Count == 0)
    {
        Console.WriteLine("No Items Available.");
        return;
    }

    Console.WriteLine("\nSort By");
    Console.WriteLine("1. Price (Ascending)");
    Console.WriteLine("2. Name (Ascending)");
    Console.WriteLine("3. Quantity (Descending)");

    Console.Write("Enter Choice : ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            items = items.OrderBy(i => i.Price).ToList();

            Console.WriteLine("\nSorted By Price.");

            break;

        case 2:

            items = items.OrderBy(i => i.ItemName).ToList();

            Console.WriteLine("\nSorted By Name.");

            break;

        case 3:

            items = items.OrderByDescending(i => i.Quantity).ToList();

            Console.WriteLine("\nSorted By Quantity.");

            break;

        default:

            Console.WriteLine("Invalid Choice.");
            return;
    }

    DisplayItems();
}
    }
}