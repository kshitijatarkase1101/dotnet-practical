using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface ICustomerService
    {
       
            List<Customer> GetAll();
            Customer GetById(int id);
            void Add(Customer customer);
            void Update(Customer customer);
            void Delete(int id);
        
    }
}

