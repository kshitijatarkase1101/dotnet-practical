using System;
using System.Collections.Generic;

public class CartManager
{
    // Add Product to Cart
    public void AddToCart(Customer customer, Product product)
    {
        foreach (CartItem item in customer.Cart)
        {
            if (item.Product.ProductId == product.ProductId)
            {
                Console.Write("Enter Quantity : ");
                int qty = Convert.ToInt32(Console.ReadLine());

                if (qty <= product.Quantity)
                {
                    item.Quantity += qty;
                    Console.WriteLine("Quantity Updated.");
                }
                else
                {
                    Console.WriteLine("Not Enough Stock.");
                }
                return;
            }
        }

        CartItem cartItem = new CartItem();

        cartItem.Product = product;

        Console.Write("Enter Quantity : ");
        cartItem.Quantity = Convert.ToInt32(Console.ReadLine());

        if (cartItem.Quantity > product.Quantity)
        {
            Console.WriteLine("Not Enough Stock.");
            return;
        }

        customer.Cart.Add(cartItem);

        Console.WriteLine("Product Added To Cart.");
    }

    // View Cart
    public void ViewCart(Customer customer)
    {
        if (customer.Cart.Count == 0)
        {
            Console.WriteLine("Cart is Empty.");
            return;
        }

        Console.WriteLine("\n===== SHOPPING CART =====");

        foreach (CartItem item in customer.Cart)
        {
            item.Display();
        }

        Console.WriteLine("----------------------------");
        Console.WriteLine("Total : ₹" + GetTotal(customer));
    }

    // Remove Item
    public void RemoveItem(Customer customer)
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        CartItem removeItem = null;

        foreach (CartItem item in customer.Cart)
        {
            if (item.Product.ProductId == id)
            {
                removeItem = item;
                break;
            }
        }

        if (removeItem != null)
        {
            customer.Cart.Remove(removeItem);
            Console.WriteLine("Item Removed.");
        }
        else
        {
            Console.WriteLine("Product Not Found.");
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
                int qty = Convert.ToInt32(Console.ReadLine());

                if (qty <= item.Product.Quantity)
                {
                    item.Quantity = qty;
                    Console.WriteLine("Quantity Updated.");
                }
                else
                {
                    Console.WriteLine("Stock Not Available.");
                }

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
    public double GetTotal(Customer customer)
    {
        double total = 0;

        foreach (CartItem item in customer.Cart)
        {
            total += item.TotalPrice();
        }

        return total;
    }

    // Checkout Summary
    public void ViewTotal(Customer customer)
    {
        double total = GetTotal(customer);

        double discount = total * 0.05;

        double gst = (total - discount) * 0.18;

        double grandTotal = total - discount + gst;

        Console.WriteLine();
        Console.WriteLine("========== BILL ==========");
        Console.WriteLine("Total        : ₹" + total);
        Console.WriteLine("Discount (5%): ₹" + discount);
        Console.WriteLine("GST (18%)    : ₹" + gst);
        Console.WriteLine("Grand Total  : ₹" + grandTotal);
    }

    // Apply Coupon
    public void ApplyCoupon(Customer customer)
    {
        Console.Write("Enter Coupon Code : ");
        string coupon = Console.ReadLine();

        double total = GetTotal(customer);

        if (coupon == "SAVE10")
        {
            total = total - (total * 10 / 100);
            Console.WriteLine("Coupon Applied Successfully.");
            Console.WriteLine("Amount After Discount : ₹" + total);
        }
        else if (coupon == "SAVE20")
        {
            total = total - (total * 20 / 100);
            Console.WriteLine("Coupon Applied Successfully.");
            Console.WriteLine("Amount After Discount : ₹" + total);
        }
        else
        {
            Console.WriteLine("Invalid Coupon Code.");
        }
    }
}