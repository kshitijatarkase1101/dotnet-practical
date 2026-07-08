using System;
using System.Diagnostics.CodeAnalysis;

class Problem1
{
    
    static void Main(string[] args)
    {
        int sum1=0,sum2=0,sum3=0;
        int num=20;
        for(int id = 1001; id<=1020; id++)
        {
            if (id % 4 == 0)
            {
                sum1 = sum1+1;
            }
            else if (id % 5 == 0)
            {
                sum2 = sum2+1;
            }
            else
            {
                sum3= sum3+1;
            }
            
            }

            Console.WriteLine("Total packages processed="+num);
            Console.WriteLine("Number of packages requiring quality check="+ sum1);
            Console.WriteLine("Number of priority shipments="+ sum2);
            Console.WriteLine("Number of normal packages="+sum3);
        
        Problem2 p= new Problem2();
        p.display();
        
        }
    }

