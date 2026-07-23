// L - Liskov Substitution Principle
//  a derive class should be able to replace 
// without changing program's correctness
class Bird
{
    public void Fly()
    {
        Console.WriteLine("Fliying");
    }

    class Penguin : Bird
    {
        public override void Fly()
        {
            throw new Exception("Can't Fly");
        }
    }
}