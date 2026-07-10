using System;
class program{
 static void Main()
{
    List<Employee> Emp = new List<Employee>();

    PermanentEmployee p1 = new PermanentEmployee()
    {
        EmployeeId= 101,
        Name="Anika",
        Department="Research",
    };
    p1.SetLeaveBalance();

    ContractEmployee p2 = new ContractEmployee()
    {
        EmployeeId= 102,
        Name="Manish",
        Department="Training",
    };
    p2.SetLeaveBalance();


    PermanentEmployee p3 = new PermanentEmployee()
    {
        EmployeeId= 103,
        Name="Sushmita",
        Department="HR",
    };
    p3.SetLeaveBalance();


    ContractEmployee p4 = new ContractEmployee()
    {
        EmployeeId= 104,
        Name="Preeta",
        Department="Finance",
    };
    p4.SetLeaveBalance();


    Emp.Add(p1);
    Emp.Add(p2);
    Emp.Add(p3);
    Emp.Add(p4);
    

    foreach( Employee Empl in Emp)
    {
        Empl.DisplayDetails();
    }

    List<LeaveRequest> LR = new List<LeaveRequest>();

    LR.Add(new LeaveRequest()
    {
        LeaveId= 11,
        EmployeeId= 101,
        NumberOfDays= 5,
        Reason="Medical",
    });

    LR.Add(new LeaveRequest()
    {
        LeaveId= 12,
        EmployeeId= 102,
        NumberOfDays= 2,
        Reason="Family",
    });

    LR.Add(new LeaveRequest()
    {
        LeaveId= 13,
        EmployeeId= 103,
        NumberOfDays= 1,
        Reason="Personal",
    });
     
     Console.WriteLine("Leave Requests:");
    foreach(LeaveRequest L in LR)
    {
        L.DisplayLeave();
    }

    Console.WriteLine("Permanent Employees:");
    foreach(Employee Empl in Emp)
    {
        if ( Empl is PermanentEmployee)
        {
            Empl.DisplayDetails();
        }
    }
  
  Console.WriteLine("Total Employees="+ Emp.Count);

  Console.WriteLine("Total Leave Requesta="+ LR.Count);
}
}