using System;
using System.Diagnostics.Contracts;
using System.Numerics;

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
        
        foreach(Product p in products)
        {
            Console.WriteLine("All products:");
           
            Console.WriteLine($"ID : {p.ProductId}");
           Console.WriteLine($"Name : {p.ProductName}");
           Console.WriteLine($"Price : {p.Price}");
           Console.WriteLine($"Stock : {p.Stock}");
           Console.WriteLine("-----------");
        }

        List<Product> Cart= new  List<Product>();
        decimal totalAmount = 0;
        string choice;

        do
        {
            Console.WriteLine("Enter Product ID");
            int cid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Quantity:");
            int qty = Convert.ToInt32(Console.ReadLine());

            bool pfound= false;

            foreach(var p in products){
                if (p.ProductId==cid)
                {
                    pfound=true;

                    if(p.Stock>=qty)
                    {
                         decimal amount = p.Price * qty;
                         totalAmount += amount;

                         Cart.Add(new Product
                         {
                             ProductId=p.ProductId,
                             ProductName=p.ProductName,
                             Price=p.Price,
                             Stock=qty,

                         });
                         Console.WriteLine("Product added to cart");
                    }
                    else
                    {
                        Console.WriteLine("Stock not available");
                    }
                    break;
                }
            }

            if(!found)
            {
                Console.WriteLine("Product not found");
            }

            Console.WriteLine("Do you want to add another product/(yes/no)");
            choice = Console.ReadLine();
        }while(choice.ToLower()=="yes");

        Console.WriteLine("\n------CART-------");
        
        foreach(var item in Cart)
        {
             Console.WriteLine($"{item.ProductName}*{item.Stock}");
        }
         
          Console.WriteLine("Total Amount ="+ totalAmount);

          int Discount=0;
          decimal FinalAmount=0;

        if (totalAmount < 1000)
        {
            Discount=10;
            
            
        }
        else if(totalAmount>=5000 && totalAmount<= 9999)
        {
            Discount= 20;
            FinalAmount=totalAmount*(20/100);
        
            

        }
        else 
        {
            Discount= 30;
        }
        FinalAmount=totalAmount-(totalAmount*Discount/100);
        Console.WriteLine("Total Amount="+ totalAmount);
        Console.WriteLine("Discount="+ Discount);
        Console.WriteLine("Final Amount="+ FinalAmount);

          while(true)
        {
            Console.WriteLine("---Payment Gateway--");
            Console.WriteLine("1. UPI");
            Console.WriteLine("2. Credit Card");
            Console.WriteLine("3. Debit Card");
            Console.WriteLine("4. Cash On Delivery");
            Console.WriteLine("Enter choice 1-4");

            try
            {
                int pchoice= Convert.ToInt32(Console.ReadLine());
                switch(pchoice)
                {
                    case 1:
                      Console.WriteLine("Payment Successful");
                      break;
                    case 2:
                      Console.WriteLine("Payment Successful");
                      break;
                    case 3:
                      Console.WriteLine("Payment Successful");
                      break;
                    case 4:
                      Console.WriteLine("Payment Successful");
                      break;

                    


                }
            } catch(FormatException Exception)
            {
                Console.WriteLine("Invalid Option");
            }
            catch( Exception e)
            {
                Console.WriteLine("Invalid Option");
            }

        } 
    }
}
        
