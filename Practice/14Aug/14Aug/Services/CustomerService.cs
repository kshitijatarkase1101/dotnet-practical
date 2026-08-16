using _14Aug.Data;
using _14Aug.Models;
using _14Aug.Repository;

namespace _14Aug.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;

        public CustomerService(AppDbContext context)
        {
            this.context = context;
        }

        public Customer Add(Customer customer)
        {
            context.Customers.Add(customer);
             context.SaveChanges();
            return customer;
            
        }

        public Customer? GetCustomerById(int id)
        {
            
            return context.Customers.Find(id);
        }

        public List<Customer> GetCustomers()
        {
           return context.Customers.ToList();
        }
    }
}
