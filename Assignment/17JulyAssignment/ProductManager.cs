using System;
using System.Collections.Generic;

public class ProductManager
{
    List<Product> products = new List<Product>();

    // Add Product
    public void AddProduct()
    {
        Product product = new Product();

        Console.Write("Enter Product ID : ");
        product.ProductId = Convert.ToInt32(Console.ReadLine());

        foreach (Product p in products)
        {
            if (p.ProductId == product.ProductId)
            {
                Console.WriteLine("Product already exists.");
                return;
            }
        }

        Console.Write("Enter Product Name : ");
        product.ProductName = Console.ReadLine();

        Console.Write("Enter Category : ");
        product.Category = Console.ReadLine();

        Console.Write("Enter Description : ");
        product.Description = Console.ReadLine();

        Console.Write("Enter Price : ");
        product.Price = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Quantity : ");
        product.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Brand : ");
        product.Brand = Console.ReadLine();

        Console.Write("Enter Discount : ");
        product.Discount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rating : ");
        product.Rating = Convert.ToInt32(Console.ReadLine());

        products.Add(product);

        Console.WriteLine("Product Added Successfully.");
    }

    // Update Product
    public void UpdateProduct()
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Product product = null;

        foreach (Product p in products)
        {
            if (p.ProductId == id)
            {
                product = p;
                break;
            }
        }

        if (product == null)
        {
            Console.WriteLine("Product Not Found.");
            return;
        }

        product.Update();
        Console.WriteLine("Product Updated Successfully.");
    }

    // Delete Product
    public void DeleteProduct()
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Product product = null;

        foreach (Product p in products)
        {
            if (p.ProductId == id)
            {
                product = p;
                break;
            }
        }

        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Product Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("Product Not Found.");
        }
    }

    // Search Product
    public void SearchProduct()
    {
        Console.Write("Enter Product ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Product p in products)
        {
            if (p.ProductId == id)
            {
                p.Display();
                return;
            }
        }

        Console.WriteLine("Product Not Found.");
    }

    // View All Products
    public void ViewProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No Products Available.");
            return;
        }

        foreach (Product p in products)
        {
            p.Display();
            Console.WriteLine();
        }
    }

    // Return Product List
    public List<Product> GetProducts()
    {
        return products;
    }
    
}