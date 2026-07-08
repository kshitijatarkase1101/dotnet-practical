//collections - group of objects that can grow or shrink dynamically
//more flexible than array
//List - dynamic array , automatically increase or decrease
// dictionary
using System;
using System.Collections.Generic;

class Collections
{
   public static void Main()
    {
        List<string> names = new List<string>();//create a list of string
        names.Add("Bhakti"); // add an item
        names.Add("Devyani");
        names.Add("Shreya");
        names.Add("Divya");
        names.Add("Manjiri");
        names.Add("Kirti");
        names.Add("Kanchan");

        foreach(string f in names ) // display all items
        {
            Console.WriteLine(f);
        }
    }
}