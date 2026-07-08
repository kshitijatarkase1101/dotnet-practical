using System;

class Problem2
{
    static void Main(string[] args)
    {
        
    
    
    
        double totalpower=0;
        int sum1=0, sum2=0 , sum3=0;
        int slnum=1;
        while (slnum <= 30)
        {
            double Power= 80+( slnum*5);
            totalpower =+ Power;
            if (Power > 180)
            {
                Console.WriteLine("Maintenantce Required");
                sum1 = sum1+1;
            }
            else if(Power>=140 && Power<= 180)
            {
                Console.WriteLine("Normal Operation");
                sum2= sum2+1;
            }
            else
            {
                 Console.WriteLine("Energy Efficient");
                 sum3= sum3+1;
            }
            slnum++;
        }
        Console.WriteLine("Total power consumed by all streets="+totalpower+"W");
        Console.WriteLine("Average power consumptionm="+(totalpower/30)+"W");
        Console.WriteLine("No. of lights which required maintenance="+sum1);
        Console.WriteLine("No. of lights having normal operation="+sum2);
        Console.WriteLine("No. of lights which are energy efficient="+sum3);
    
    
    


 }
}
