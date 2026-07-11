using System;

public class LeaveRequest
{
    public int LeaveId{get; set;}
    public int EmployeeId{get; set;}
    public int NumberOfDays{get; set;}
    public string Reason{get; set;}
     public void DisplayLeave()
    {
        Console.WriteLine("Leave Id :"+ LeaveId);
        Console.WriteLine("Employee Id :"+ EmployeeId);
        Console.WriteLine("NumberOfDays :"+ NumberOfDays);
        Console.WriteLine("Reason :"+ Reason);
    }
    
}