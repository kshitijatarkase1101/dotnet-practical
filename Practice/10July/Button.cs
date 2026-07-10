// Events - based on delegate and used to notify other classe when something happens

using System;

class Button
{
    public event Action Click;

    public void Press()
    {
       Console.WriteLine("Button is pressed");
    }
}
