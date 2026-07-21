using System;
using System.Collections.Generic;

public class CartManager
{
    double couponDiscount = 0;
    public void AddToCart(Customer customer, Product product, int quantity)
    {
        if (product == null)
        {
            Console.WriteLine("Product Not Found.");
            return;
        }

        if (quantity > product.Quantity)
        {
            Console.WriteLine("Insufficient Stock.");
            return;
        }

        foreach (CartItem item in customer.Cart)
        {
            if (item.Product.ProductId == product.ProductId)
            {
                item.Quantity += quantity;

                Console.WriteLine("Cart Updated Successfully.");
                return;
            }
        }

        CartItem cartItem = new CartItem();
        cartItem.Product = product;
        cartItem.Quantity = quantity;

        customer.Cart.Add(cartItem);

        Console.WriteLine("Product Added To Cart.");
    }

    // View Cart
    public void ViewCart(Customer customer)
    {
        if (customer.Cart.Count == 0)
        {
            Console.WriteLine("Cart Is Empty.");
            return;
        }

        Console.WriteLine("\n--------- CART ---------");

        foreach (CartItem item in customer.Cart)
        {
            item.Display();
        }

        Console.WriteLine("------------------------");
        Console.WriteLine("Total : ₹" + CalculateTotal(customer));
    }

    // Remove Item
    public void RemoveItem(Customer customer)
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        CartItem itemToRemove = null;

        foreach (CartItem item in customer.Cart)
        {
            if (item.Product.ProductId == id)
            {
                itemToRemove = item;
                break;
            }
        }

        if (itemToRemove != null)
        {
            customer.Cart.Remove(itemToRemove);

            Console.WriteLine("Item Removed.");
        }
        else
        {
            Console.WriteLine("Product Not Found In Cart.");
        }
    }

    // Update Quantity
    public void UpdateQuantity(Customer customer)
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (CartItem item in customer.Cart)
        {
            if (item.Product.ProductId == id)
            {
                Console.Write("Enter New Quantity : ");
                item.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Quantity Updated.");
                return;
            }
        }

        Console.WriteLine("Product Not Found.");
    }

    // Clear Cart
    public void ClearCart(Customer customer)
    {
        customer.Cart.Clear();

        Console.WriteLine("Cart Cleared Successfully.");
    }

    // Calculate Total
    public double CalculateTotal(Customer customer)
    {
        double total = 0;

        foreach (CartItem item in customer.Cart)
        {
            total += item.TotalPrice();
        }

        return total;
    }

    // Apply Coupon
    public double ApplyCoupon(Customer customer, string couponCode)
    {
        double total = CalculateTotal(customer);

        switch (couponCode.ToUpper())
        {
            case "SAVE10":
                Console.WriteLine("10% Discount Applied.");
                return total * 0.10;

            case "SAVE20":
                Console.WriteLine("20% Discount Applied.");
                return total * 0.20;

            default:
                Console.WriteLine("Invalid Coupon.");
                return 0;
        }
    }

    // GST Calculation
    public double CalculateGST(Customer customer)
    {
        return CalculateTotal(customer) * 0.18;
    }

    // Grand Total
    public double CalculateGrandTotal(Customer customer, double discount)
    {
        
        double total = GetTotal();

        double discount = total * couponDiscount / 100;

double gst = (total - discount) * 0.18;

double grandTotal = total - discount + gst;
    }
    public void ApplyCoupon()
{
    Console.Write("Enter Coupon Code : ");
    string code = Console.ReadLine();

    if(code == "SAVE10")
    {
        couponDiscount = 10;
        Console.WriteLine("10% Discount Applied.");
    }
    else if(code == "SAVE20")
    {
        couponDiscount = 20;
        Console.WriteLine("20% Discount Applied.");
    }
    else
    {
        couponDiscount = 0;
        Console.WriteLine("Invalid Coupon.");
    }
}
}