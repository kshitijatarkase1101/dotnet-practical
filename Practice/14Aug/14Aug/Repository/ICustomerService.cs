using _14Aug.Models;

namespace _14Aug.Repository
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer? GetCustomerById(int id);
        Customer Add(Customer customer);

    }
}
