using System;

class Program
{
    static void Main()
    {
        CustomerManager customerManager = new CustomerManager();
        ProductManager productManager = new ProductManager();
        CategoryManager categoryManager = new CategoryManager();
        OrderManager orderManager = new OrderManager();
        PaymentManager paymentManager = new PaymentManager();
        ReportManager reportManager = new ReportManager(customerManager, productManager, orderManager);

        Console.WriteLine("=================================");
        Console.WriteLine("       Welcome To ShopEase");
        Console.WriteLine("=================================");
        Console.WriteLine("1. Admin Login");
        Console.WriteLine("2. Customer Register");
        Console.WriteLine("3. Customer Login");
        Console.WriteLine("4. Exit");
        Console.Write("Enter Choice : ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:

                Console.Write("Enter Username : ");
                string uname = Console.ReadLine();

                Console.Write("Enter Password : ");
                int pass = Convert.ToInt32(Console.ReadLine());

                if (uname == "admin" && pass == 123)
                {
                    Console.WriteLine("\nAdmin Login Successful");

                    Console.WriteLine("\n===== ADMIN MENU =====");
                    Console.WriteLine("1. Product Management");
                    Console.WriteLine("2. Category Management");
                    Console.WriteLine("3. Reports");
                    Console.WriteLine("4. Logout");

                    int adminChoice = Convert.ToInt32(Console.ReadLine());

                    switch (adminChoice)
                    {
                        case 1:

                            Console.WriteLine("\nPRODUCT MANAGEMENT");
                            Console.WriteLine("1. Add Product");
                            Console.WriteLine("2. Update Product");
                            Console.WriteLine("3. Delete Product");
                            Console.WriteLine("4. Search Product");
                            Console.WriteLine("5. View Products");

                            int pchoice = Convert.ToInt32(Console.ReadLine());

                            switch (pchoice)
                            {
                                case 1:
                                    productManager.AddProduct();
                                    break;

                                case 2:
                                    productManager.UpdateProduct();
                                    break;

                                case 3:
                                    productManager.DeleteProduct();
                                    break;

                                case 4:
                                    productManager.SearchProduct();
                                    break;

                                case 5:
                                    productManager.ViewProducts();
                                    break;
                            }

                            break;

                        case 2:

                            Console.WriteLine("\nCATEGORY MANAGEMENT");
                            Console.WriteLine("1. Add Category");
                            Console.WriteLine("2. Update Category");
                            Console.WriteLine("3. Delete Category");
                            Console.WriteLine("4. View Categories");

                            int cchoice = Convert.ToInt32(Console.ReadLine());

                            switch (cchoice)
                            {
                                case 1:
                                    categoryManager.AddCategory();
                                    break;

                                case 2:
                                    categoryManager.UpdateCategory();
                                    break;

                                case 3:
                                    categoryManager.DeleteCategory();
                                    break;

                                case 4:
                                    categoryManager.ViewCategories();
                                    break;
                            }

                            break;

                        case 3:

                            Console.WriteLine("\nREPORTS");
                            Console.WriteLine("1. Customer Report");
                            Console.WriteLine("2. Product Report");
                            Console.WriteLine("3. Order Report");
                            Console.WriteLine("4. Revenue Report");

                            int rchoice = Convert.ToInt32(Console.ReadLine());

                            switch (rchoice)
                            {
                                case 1:
                                    reportManager.CustomerReport();
                                    break;

                                case 2:
                                    reportManager.ProductReport();
                                    break;

                                case 3:
                                    reportManager.OrderReport();
                                    break;

                                case 4:
                                    reportManager.RevenueReport();
                                    break;
                            }

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Admin Login");
                }

                break;

            case 2:

                customerManager.RegisterCustomer();

                break;

            case 3:

                Customer customer = customerManager.LoginCustomer();

                if (customer != null)
                {
                    Console.WriteLine("\nCustomer Login Successful");

                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. View Cart");
                    Console.WriteLine("3. Place Order");
                    Console.WriteLine("4. View Orders");
                    Console.WriteLine("5. Logout");

                    int customerChoice = Convert.ToInt32(Console.ReadLine());

                    switch (customerChoice)
                    {
                        case 1:
                            productManager.ViewProducts();
                            break;

                        case 2:
                            Console.WriteLine("Cart Module");
                            break;

                        case 3:
                            orderManager.PlaceOrder(customer);
                            break;

                        case 4:
                            orderManager.ViewCustomerOrders(customer);
                            break;
                    }
                }

                break;

            case 4:

                Console.WriteLine("Thank You For Using ShopEase");
                break;

            default:

                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}