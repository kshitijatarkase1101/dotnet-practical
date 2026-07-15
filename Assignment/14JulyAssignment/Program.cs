using System;
using StationeryStoreManagement.Exceptions;

namespace StationeryStoreManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreManager manager = new StoreManager();
            
            try
{
    
            Login();

            while (true)
            {
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("Stationery Store Management System");
                Console.WriteLine("------------------------------------");

                Console.WriteLine("1. Add Stationery Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Search Item");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Purchase Item");
                Console.WriteLine("7. View Low Stock Items");
                Console.WriteLine("8. Sort Items");
                Console.WriteLine("9. Exit");

                Console.Write("\nEnter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddItem();
                        break;

                    case 2:
                        manager.DisplayItems();
                        break;

                    case 3:
                        manager.SearchItem();
                        break;

                    case 4:
                        manager.UpdateItem();
                        break;

                    case 5:
                        manager.DeleteItem();
                        break;

                    case 6:
                        manager.PurchaseItem();
                        break;

                    case 7:
                        manager.ViewLowStockItems();
                        break;

                    case 8:
                        manager.SortItems();
                        break;

                    case 9:
                        Console.WriteLine("\nThank You");
                        Console.WriteLine("Visit Again");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
        

catch (LoginFailedException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Application Closed.");
    return;
}

        static void Login()
        {
            int attempts = 3;

            while (attempts > 0)
            {
                Console.Write("Enter Username : ");
                string username = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                if (username == "admin" && password == "admin123")
                {
                    Console.WriteLine("\nLogin Successful.\n");
                    return;
                }

                attempts--;

                Console.WriteLine("\nInvalid Login");

                if (attempts > 0)
                {
                    Console.WriteLine("Attempts Left : " + attempts);
                }
            }

            throw new LoginFailedException();
        }
     }
     
    }
}