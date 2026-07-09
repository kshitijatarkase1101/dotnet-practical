using System;

public class abstracteg : FileStorage
{

    public override void upload(string filename)
    {
        Console.WriteLine("Uploadung file to google cloud");
    }
}