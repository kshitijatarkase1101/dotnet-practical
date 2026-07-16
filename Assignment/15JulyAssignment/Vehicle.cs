using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Vehicle
{

    List<Vehicle> vehicles= new List<Vehicle>();
    public int VehicleID{get; set ;}
    public string VehicleName{get; set;}
    public string Type{get; set;}
    public string Brand {get; set;}
    public int Price {get; set;}
    public int Year{ get; set;}
    
    double Discount=0;
    double FinalPrice=0;

    
     
     
     public void Add()
    {
        Vehicle v= new Vehicle();
        Console.WriteLine("Enter Vehicle ID:");
        v.VehicleID =Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Vehicle Name:");
        v.VehicleName =Console.ReadLine();
        Console.WriteLine("Enter Vehicle Type:");
         v.Type=Console.ReadLine();
        Console.WriteLine("Enter Vehicle Brand:");
         v.Brand=Console.ReadLine();
        Console.WriteLine("Enter Vehicle Price:");
        v.Price=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Year:");
        v.Year=Convert.ToInt32(Console.ReadLine());

        vehicles.Add(v);
    }

    public void View()
    {
        Console.WriteLine("-----------------------------");
        foreach(Vehicle v in vehicles){
        Console.WriteLine($"{v.VehicleID}\t{v.VehicleName}\t{v.Type}\t{v.Brand}\t{v.Price}\t{v.Year}");
        Console.WriteLine("-----------------------------");
        }
    }
    public void Search()
    {
        Console.WriteLine("Enter Vehicle ID:");
        int sid=Convert.ToInt32(Console.ReadLine());
        
        bool found = false;
        foreach(Vehicle v in vehicles){
        if( v.VehicleID==sid)
        {
            found = true;
            Console.WriteLine("Vehicle ID:"+v.VehicleID);
            Console.WriteLine("Vehicle Name:"+v.VehicleName);
            Console.WriteLine("Vehicle Type:"+v.Type);
            Console.WriteLine("Vehicle Brand:"+v.Brand);
            Console.WriteLine("Vehicle Price:"+v.Price);
            Console.WriteLine("Year of Manufacture:"+v.Year);
            break;
            
        }
        if(!found)
        {
            Console.WriteLine("Vehicle not found");
        }
        }
     }
     public void Update()
    {
        Console.WriteLine("Enter Vehicle ID:");
        int uid=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter New Price:");
        int price=Convert.ToInt32(Console.ReadLine());
       
        bool found = false;
        foreach(Vehicle v in vehicles){
        if(v.VehicleID==uid)
        {
            found = true;
            v.Price=price;
            break;
        }
        if(!found)
        {
           Console.WriteLine("Vehicle ID does not exists"); 
        }
        }
    }
    public void Delete()
    {
        Console.WriteLine("Enter Vehicle ID:");
        int did=Convert.ToInt32(Console.ReadLine());
        Vehicle found=null;

foreach(Vehicle v in vehicles)
{
    if(v.VehicleID==did)
    {
        found=v;
        break;
    }
}

if(found!=null)
{
    vehicles.Remove(found);
     Console.WriteLine("Vehicle deleted successfully");
}
        else
        {
            Console.WriteLine("Vehicle not available");
        
        }
    }
    public void CalculateDiscount()
    {
        Console.WriteLine("Enter Vehicle ID:");
        int id = Convert.ToInt32(Console.ReadLine());
        foreach(Vehicle v in vehicles)
        {
            
        
        if (v.Type == "Car")
        {
            Discount= v.Price*0.10;
        }
        else if (v.Type == "Bike")
        {
            Discount= v.Price*0.05;
        }
        else if (v.Type == "Truck")
        {
            Discount= v.Price*0.12;
        }

        FinalPrice =v.Price-Discount;
       Console.WriteLine($"Vehicle Price:{v.Price}");
       Console.WriteLine($"Discount:{Discount}");
       Console.WriteLine($"Final Price:{FinalPrice}");

        
        }   
    }



        public void Exit()
        {
             
             Console.WriteLine("Thank you for using ABC Motors System.");
        }

        
 }
    
        
    
    


    
