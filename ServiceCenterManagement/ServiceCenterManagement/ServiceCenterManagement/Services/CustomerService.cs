using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class CustomerService : ICustomerService
    {
       
            private readonly AppDbContext context;

            public CustomerService(AppDbContext context)
            {
                this.context = context;
            }

            public List<Customer> GetAll()
            {
                return context.Customers.ToList();
            }

            public Customer GetById(int id)
            {
                return context.Customers.Find(id);
            }

            public void Add(Customer customer)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }

            public void Update(Customer customer)
            {
                context.Customers.Update(customer);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                Customer customer = context.Customers.Find(id);

                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        
    }
}

