//I - Interface Segretion Principle
// clients should not be forced to implement methods they do not 

using System.Security.Cryptography.X509Certificates;
interface Program
{
    void work();
    void walk();
}
interface Program1
{
    void eat();
}

class Human : Program, Program1
{
    public void work()
    {
        
    }
    public void walk()
    {
        
    }
    public void eat()
    {
        
    }
}

class Robots : Program
{
    public void work()
    {
        
    }
    public void walk()
    {
        
    }
    
}


     
            
    
    
