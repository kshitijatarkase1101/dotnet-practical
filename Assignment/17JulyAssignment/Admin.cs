using System;

class Admin
{
    public string Username{ get; set;}
    public int Password{ get; set;}

    public bool Login(string username, int password)
    {
        return Username == username && Password == password;
    }
}