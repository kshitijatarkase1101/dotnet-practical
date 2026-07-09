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
       /* List<string> names = new List<string>();//create a list of string
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
        }*/

        ///////////////////////////////
        /// 
        /// 
        /// 
        List<Stud> st = new List<Stud>
        {
            new Stud{id = 1 , sname= "riya"},
            new Stud{id = 2 , sname= "meena"},
            new Stud{id = 3 , sname= "rekha"},
            new Stud{id = 4 , sname= "maya"},
        };

        List<Teacher> th = new List<Teacher>
        {
            new Teacher{tid = 101 , Tname= "Kavita"},
            new Teacher{tid = 102 , Tname= "Pooja"},
        };


        foreach(var stu in st)
        {
            Console.WriteLine($"Students : {stu.sname}");
        }
       Console.WriteLine("     ");
       foreach(var thu in th)
        {
            Console.WriteLine($"Teachers : {thu.Tname}");
        }
    }
}