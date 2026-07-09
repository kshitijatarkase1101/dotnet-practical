using System;
using System.Diagnostics.CodeAnalysis;

class OOP
{
    static void Main()
    {
        Employee e = new Employee();

        e.EmpName = "Rekha";
        e.Salary = 1000;

        Console.WriteLine(e.EmpName+" "+e.Salary);

        
    CompiletimePoly c = new CompiletimePoly();
    c.Search(101);
    c.Search(76859038888);
    c.Search("mamta","ekta");


         //polymorphism

   RuntimePoly r = new RuntimePoly();
    r.checkout(new UpiPayment(), 500);
     r.checkout(new CreditPayment(), 55000);
      r.checkout(new NetBanking(), 25000);

      //

     FileStorage s = new abstracteg();
      s.upload("CV.pdf");
      s.validateFile(); 

    }




   
       

}