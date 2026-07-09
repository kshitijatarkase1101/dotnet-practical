using System;

public abstract class FileStorage
{
    public abstract void upload(string filename);
    
    public void validateFile()
    {
        Console.WriteLine("Validating file.....");
    }
}