using System;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the Employee Name:");
        string name = Console.ReadLine();
         Console.WriteLine("Enter the Employee ID:");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Welcome "+name);
        Console.WriteLine("--------------------");
        Console.WriteLine("--------------------");
        Console.WriteLine("ABC MOTORS");
        Console.WriteLine("Vehicle Management System");
        Console.WriteLine("--------------------");
        Console.WriteLine("--------------------");

        Vehicle v= new Vehicle();

        while (true)
        {
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. View All Vehicles");
            Console.WriteLine("3. Search Vehicles");
            Console.WriteLine("4. update Vehicle Price");
            Console.WriteLine("5. Delete Vehicle");
            Console.WriteLine("6. Calculate Discount");
            Console.WriteLine("7.Show Vehicle Details");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Enter your choice:");

            try{
                int choice = Convert.ToInt32(Console.ReadLine());
                 

                switch(choice){
                case 1:
                    
                    v.Add();
                    break;
                case 2:
                    v.View();   
                    break;
                case 3:
                     v.Search();
                     break;
                case 4:
                    v.Update();
                    break;
                case 5:
                    v.Delete();
                    break;
                case 6:
                    v.CalculateDiscount();
                    break;
                case 7:
                      Console.WriteLine("-----------Show Details of---------");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Bike");

        Console.WriteLine("3. Truck");

        Console.WriteLine("Enter the choice");
        int choice1=Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
            Console.WriteLine("Car is four wheeler.");
            Console.WriteLine("Suitable for family.");
            break;

            case 2:
            Console.WriteLine("Bike is fuel efficient");
            Console.WriteLine("Suitable for city rides");
            break;

            case 3:
            Console.WriteLine("Truck is used for transportation");
            Console.WriteLine("Heavy load vehicle");
            break;


        }
                     break;
                case 8:
                     v.Exit();
                     return;
                default:
                Console.WriteLine("Invalid Choice");
                 break;
                                      
                 }
        }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        
    }
}
}
