using System;

using System.Collections.Generic;

Genericeg<int> n = new Genericeg<int>();
n.Print(100);

Genericeg<string> n1 = new Genericeg<string>();
n1.Print("Meena");

Genericeg<double> n2 = new Genericeg<double>();
n2.Print(100.25);

string empName ="RAHUL";
Console.WriteLine(empName.ProperCase());

string empName1 ="mamta";
Console.WriteLine(empName1.ProperCase());






    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        List<Manager> managers = new List<Manager>();


        while (true)
        {
            Console.WriteLine("Welcome to Emp System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager" );
            Console.WriteLine("3. View Employee ");
            Console.WriteLine("4. View Managers");
            Console.WriteLine("5. Search Employee  by id");
            Console.WriteLine("6. exit");

            Console.WriteLine("Enter choice 1-6");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Id :");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bool exists = false;
                        foreach ( Employee emp in employees)
                        {
                            if (emp.Id == id)
                            {
                                exists = true;
                                break;
                            }
                        }if (exists)
                        {
                            Console.WriteLine("Employee already exists");
                            break;
                        }

                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        double salary= Convert.ToDouble(Console.ReadLine());
                        Employee employee= new Employee( id, name, salary);


                        // add in collections
                        employees.Add(employee);
                        Console.WriteLine("Employee added successfully");
                        break;
                    case 2:
                         Console.WriteLine("Enter Manager ID");
                         int mid = Convert.ToInt32(Console.ReadLine());
                         Console.WriteLine("Enter name:");
                         string mname = Console.ReadLine();
                        Console.WriteLine("Enter salary:");
                         string msalary = Console.ReadLine();
                         Console.WriteLine("Enter dept:");
                         double mdept = Convert.ToDouble(Console.ReadLine());
                         Manager manager = new Manager( mid , mname, mdept, msalary);
                         managers.Add(manager);
                         Console.WriteLine("Manager added successfully");
                         break;
                         


                    case 3:
                        if(employees.Count == 0)
                        {
                            Console.WriteLine("No Employees in System");

                        }
                        else
                        {
                            foreach(Employee emp in employees)
                            {
                                emp.Display();
                            }
                        }
                        break;


                    case 4:
                        if(managers.Count == 0)
                        {
                            Console.WriteLine("No Managers in System");

                        }
                        else
                        {
                            foreach(Manager mag in managers)
                            {
                                mag.DisplayManager();
                            }
                        }
                        break;

                    case 5:
                            Console.WriteLine("Enter Employee Id");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            bool found = false;
                            foreach(Employee emp in employees)
                        {
                            if(emp.Id == searchId)
                            {
                                emp.Display();
                                found = true;
                                break;
                            }
                        }

                            if(!found)
                            {
                                Console.WriteLine("Employee not found");
                            }
                            break;
                        
                    case 6:
                    return;
                    
                    default:
                      Console.WriteLine("Invalid Choice");
                      break;

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only");
            }
            catch (Exception e)
            {
                Console.WriteLine("e.Message");
            }
            
        }
    }

