using System;
using System.Collections.Generic;


class Problem2
{
    public  void Display()
    {
        
        List<string> booknames = new List<string>();
        booknames.Add("Wings of Fire");
        booknames.Add("Ikigai");
        booknames.Add("Atomic Habits");
        booknames.Add("The Thousand Splendid Suns");
        booknames.Add("Little Life");
        
        Console.WriteLine("          ");
        Console.WriteLine("Books available in library:");

        foreach(string f in booknames)
        {
             Console.WriteLine(f);
        }
        
         booknames.Add("Works Of SwamiVivekanand");
         booknames.Remove("Atomic Habits");
          Console.WriteLine("              ");
          Console.WriteLine("Updated List:");

         foreach(string f in booknames)
        {
            Console.WriteLine(f);
        }
            Console.WriteLine("       ");
             Console.WriteLine("Total no. of Books="+ booknames.Count);


    }

}