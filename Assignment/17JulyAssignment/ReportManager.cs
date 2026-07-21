using System;
using System.Collections.Generic;

public class ReportManager
{
    CustomerManager customerManager;
    ProductManager productManager;
    OrderManager orderManager;

    public ReportManager(CustomerManager cm,
                         ProductManager pm,
                         OrderManager om)
    {
        customerManager = cm;
        productManager = pm;
        orderManager = om;
    }

    // Customer Report
    public void CustomerReport()
    {
        Console.WriteLine("\n===== CUSTOMER REPORT =====");

        List<Customer> customers = customerManager.GetCustomers();

        Console.WriteLine("Total Customers : " + customers.Count);

        foreach (Customer c in customers)
        {
            c.Display();
        }
    }

    // Product Report
    public void ProductReport()
    {
        Console.WriteLine("\n===== PRODUCT REPORT =====");

        List<Product> products = productManager.GetProducts();

        Console.WriteLine("Total Products : " + products.Count);

        foreach (Product p in products)
        {
            p.Display();
            Console.WriteLine();
        }
    }

    // Order Report
    public void OrderReport()
    {
        Console.WriteLine("\n===== ORDER REPORT =====");

        Console.WriteLine("Total Orders : " + orderManager.TotalOrders());

        orderManager.ViewOrders();
    }

    // Revenue Report
    public void RevenueReport()
    {
        Console.WriteLine("\n===== REVENUE REPORT =====");

        Console.WriteLine("Total Revenue : ₹" + orderManager.GetRevenue());
    }

    // Low Stock Report
    public void LowStockReport()
    {
        Console.WriteLine("\n===== LOW STOCK REPORT =====");

        bool found = false;

        foreach (Product p in productManager.GetProducts())
        {
            if (p.Quantity > 0 && p.Quantity < 5)
            {
                p.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No Low Stock Products.");
        }
    }

    // Out Of Stock Report
    public void OutOfStockReport()
    {
        Console.WriteLine("\n===== OUT OF STOCK REPORT =====");

        bool found = false;

        foreach (Product p in productManager.GetProducts())
        {
            if (p.Quantity == 0)
            {
                p.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No Out Of Stock Products.");
        }
    }

    // Show All Reports
    public void ShowAllReports()
    {
        CustomerReport();
        ProductReport();
        OrderReport();
        RevenueReport();
        LowStockReport();
        OutOfStockReport();
    }
}