using System;
using System.Collections.Generic;

public class CustomerManager
{
    List<Customer> customers = new List<Customer>();

    
    public void RegisterCustomer()
    {
        Customer customer = new Customer();

        Console.Write("Enter Customer ID : ");
        int cid = Convert.ToInt32(Console.ReadLine());

        foreach (Customer c in customers)
        {
            if (c.CustomerId == cid)
            {
                Console.WriteLine("Customer ID already exists.");
                return;
            }
        }

        customer.CustomerId = cid;

        Console.Write("Enter Name : ");
        customer.CustomerName = Console.ReadLine();

        Console.Write("Enter Email : ");
        customer.Email = Console.ReadLine();

        Console.Write("Enter Phone : ");
        customer.Phone = Convert.ToInt64(Console.ReadLine());

        Console.Write("Enter Address : ");
        customer.Address = Console.ReadLine();

        Console.Write("Enter Username : ");
        customer.Username = Console.ReadLine();

        Console.Write("Enter Password : ");
        customer.Password = Convert.ToInt32(Console.ReadLine());

        customers.Add(customer);

        Console.WriteLine("Customer Registered Successfully.");
    }

    // Login
    public Customer LoginCustomer()
    {
        Console.Write("Enter Username : ");
        string uname = Console.ReadLine();

        Console.Write("Enter Password : ");
        int pass = Convert.ToInt32(Console.ReadLine());

        foreach (Customer c in customers)
        {
            if (c.Username == uname && c.Password == pass)
            {
                Console.WriteLine("Login Successful.");
                return c;
            }
        }

        Console.WriteLine("Incorrect Credentials.");
        return null;
    }

    // View Customers
    public void ViewCustomers()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No Customers Found.");
            return;
        }

        foreach (Customer c in customers)
        {
            c.Display();
        }
    }

    // Search Customer
    public Customer SearchCustomer(int id)
    {
        foreach (Customer c in customers)
        {
            if (c.CustomerId == id)
            {
                return c;
            }
        }

        return null;
    }

    // Update Customer
    public void UpdateCustomer()
    {
        Console.Write("Enter Customer ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Customer customer = SearchCustomer(id);

        if (customer == null)
        {
            Console.WriteLine("Customer Not Found.");
            return;
        }

        Console.Write("Enter New Name : ");
        customer.CustomerName = Console.ReadLine();

        Console.Write("Enter New Email : ");
        customer.Email = Console.ReadLine();

        Console.Write("Enter New Phone : ");
        customer.Phone = Convert.ToInt64(Console.ReadLine());

        Console.Write("Enter New Address : ");
        customer.Address = Console.ReadLine();

        Console.WriteLine("Customer Updated Successfully.");
    }

    // Delete Customer
    public void DeleteCustomer()
    {
        Console.Write("Enter Customer ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Customer customer = SearchCustomer(id);

        if (customer != null)
        {
            customers.Remove(customer);
            Console.WriteLine("Customer Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("Customer Not Found.");
        }
    }

    // Return Customer List
    public List<Customer> GetCustomers()
    {
        return customers;
    }
    public void UpdateProfile()
{
    Console.Write("Enter Customer ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Customer customer = SearchCustomer(id);

    if(customer == null)
    {
        Console.WriteLine("Customer Not Found.");
        return;
    }

    Console.Write("Enter New Name : ");
    customer.CustomerName = Console.ReadLine();

    Console.Write("Enter New Email : ");
    customer.Email = Console.ReadLine();

    Console.Write("Enter New Phone : ");
    customer.Phone = Convert.ToInt64(Console.ReadLine());

    Console.Write("Enter New Address : ");
    customer.Address = Console.ReadLine();

    Console.WriteLine("Profile Updated Successfully.");
}
public void ChangePassword()
{
    Console.Write("Enter Username : ");
    string uname = Console.ReadLine();

    Console.Write("Enter Old Password : ");
    int oldPass = Convert.ToInt32(Console.ReadLine());

    foreach(Customer c in customers)
    {
        if(c.Username == uname && c.Password == oldPass)
        {
            Console.Write("Enter New Password : ");
            c.Password = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Password Changed Successfully.");
            return;
        }
    }

    Console.WriteLine("Invalid Username or Password.");
}
}