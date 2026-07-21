using System;
using System.Collections.Generic;

public class OrderManager
{
    List<Order> orders = new List<Order>();

    private int nextOrderId = 1001;

    
    public void PlaceOrder(Customer customer)
    {
        Console.WriteLine("Current Address : " + customer.Address);

Console.WriteLine("1. Use Current Address");
Console.WriteLine("2. Enter New Address");

int choice = Convert.ToInt32(Console.ReadLine());

if(choice == 2)
{
    Console.Write("Enter New Address : ");
    customer.Address = Console.ReadLine();
}
        if (customer.Cart.Count == 0)
        {
            Console.WriteLine("Cart is Empty.");
            return;
        }

        Order order = new Order();

        order.OrderId = nextOrderId++;
        order.OrderDate = DateTime.Now;
        order.Customer = customer;
        order.Status = "Placed";

        double total = 0;

        foreach (CartItem item in customer.Cart)
        {
            order.Items.Add(item);

            total += item.TotalPrice();

            
            item.Product.Quantity -= item.Quantity;
        }

        order.Total = total;

        
        order.Discount = total * 0.05;

        
        order.GST = (total - order.Discount) * 0.18;

        order.GrandTotal = total - order.Discount + order.GST;

        orders.Add(order);

        customer.Orders.Add(order);

        customer.Cart.Clear();

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Order Placed Successfully.");
        Console.WriteLine("Order ID : " + order.OrderId);
        Console.WriteLine("Grand Total : ₹" + order.GrandTotal);
        Console.WriteLine("--------------------------------");
    }

    
    public void ViewOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No Orders Found.");
            return;
        }

        foreach (Order order in orders)
        {
            order.Display();
        }
    }


    public void ViewCustomerOrders(Customer customer)
    {
        if (customer.Orders.Count == 0)
        {
            Console.WriteLine("No Orders Found.");
            return;
        }

        foreach (Order order in customer.Orders)
        {
            order.Display();
        }
    }

    
    public Order SearchOrder(int orderId)
    {
        foreach (Order order in orders)
        {
            if (order.OrderId == orderId)
            {
                return order;
            }
        }

        return null;
    }

    
    public void CancelOrder()
    {
        Console.Write("Enter Order ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Order order = SearchOrder(id);

        if (order == null)
        {
            Console.WriteLine("Order Not Found.");
            return;
        }

        if (order.Status == "Cancelled")
        {
            Console.WriteLine("Order Already Cancelled.");
            return;
        }

        order.Status = "Cancelled";

        Console.WriteLine("Order Cancelled Successfully.");
    }

    
    public void DisplayOrder()
    {
        Console.Write("Enter Order ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Order order = SearchOrder(id);

        if (order != null)
        {
            order.Display();
        }
        else
        {
            Console.WriteLine("Order Not Found.");
        }
    }

    
    public double GetRevenue()
    {
        double revenue = 0;

        foreach (Order order in orders)
        {
            if (order.Status != "Cancelled")
            {
                revenue += order.GrandTotal;
            }
        }

        return revenue;
    }
    public int TotalOrders()
    {
        return orders.Count;
    }

    
    public List<Order> GetOrders()
    {
        return orders;
    }
    
}