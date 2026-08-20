using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface IPaymentService
    {
      
            List<Payment> GetAll();
            Payment GetById(int id);
            void Add(Payment payment);
            void Update(Payment payment);
            void Delete(int id);
        
    }
}

