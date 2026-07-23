//O - open/ closed principle
// software should be open for extension but closed for modification

class OC
{
    public void Process(Payment p)
    {
        p.pay();
    }

    static void Main()
    {
        OC c= new OC ();
        c.Process(new CreditCard());
        c.Process(new UPI());
    }
}