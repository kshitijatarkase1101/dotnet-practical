using System;
using System.Diagnostics.Contracts;

class Program
{
    
    public static void Main()
    {
        Console.WriteLine("Enter CustomerID:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Name:");
        string cname =Console.ReadLine();
        Console.WriteLine("Enter Email:");
        string email =Console.ReadLine();
        Console.WriteLine("Enter Password:");
        int pass = Convert.ToInt32(Console.ReadLine());
        Register r = new Register();
        r.Display();

        int attempts=3;
        while(attempts>0){
        Console.WriteLine("---Login---");
        Console.WriteLine("Enter your email:");
        string lemail= Console.ReadLine();
        
        
        if(lemail==email)
        {
            Console.WriteLine("Enter Password:");
            int lpass= Convert.ToInt32(Console.ReadLine());
            if (lpass == pass)
            {
                Console.WriteLine("Welcome"+" "+cname);
                return;
            }
            else
            {
                attempts--;
                 Console.WriteLine("ReEnter Password");
            }
        }
        else
        {
            attempts--;
            
             Console.WriteLine("REEnter  Email");
        }
        }
        Console.WriteLine("Account Locked");

        List<Product> products= new List<Product>();
       Console.WriteLine("How many products do you want to add ");
       int n = Convert.ToInt32(Console.ReadLine());
 
       for(int i=1 ; i<=n ; i++)
        {
            Console.WriteLine($"Enter details of produt{i} :");
            Product p =new Product();
            Console.WriteLine("Enter Product ID: ");
            p.ProductId= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Name: ");
            p.ProductName= Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            p.Price= Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Stock Available: ");
            p.Stock= Convert.ToInt32(Console.ReadLine()); 

            products.Add(p);  
        }

       

        foreach(Product p in products)
        {
            Console.WriteLine("All products:");
           
            Console.WriteLine($"ID : {p.ProductId}");
           Console.WriteLine($"Name : {p.ProductName}");
           Console.WriteLine($"Price : {p.Price}");
           Console.WriteLine($"Stock : {p.Stock}");
           Console.WriteLine("-----------");
           
           
        }

        Console.WriteLine("---Search---");
        Console.WriteLine("Enter Product Name to Search");
        string pname= Console.ReadLine();
        bool found = false;

        foreach(var p in products)
        {
        if(pname==p.ProductName)
        {
           Console.WriteLine("Product Found");
           Console.WriteLine("Product Name:"+p.ProductName);
           Console.WriteLine("Product ID:"+p.ProductId);
           Console.WriteLine("Product Price:"+p.Price);
            Console.WriteLine(" Stock Available:"+p.Stock); 

            found= true;
            break; 
        }
        }
        if(!found)
        {
            Console.WriteLine("Product Not Found");
        }
        
       
    }
}
        
