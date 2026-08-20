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
            Customer existingCustomer =
                context.Customers.Find(customer.CustomerId);

            if (existingCustomer == null)
            {
                throw new Exception("Customer not found");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Email = customer.Email;
            existingCustomer.Address = customer.Address;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer customer = context.Customers.Find(id);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            bool hasVehicles =
                context.Vehicles.Any(v => v.CustomerId == id);

            if (hasVehicles)
            {
                throw new Exception(
                    "Cannot delete customer because vehicles are associated with this customer.");
            }

            context.Customers.Remove(customer);

            context.SaveChanges();
        }
    }
    
}