using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
   
        public interface IInvoiceService
        {
            List<Invoice> GetAll();
            Invoice GetById(int id);
            void Add(Invoice invoice);
            void Update(Invoice invoice);
            void Delete(int id);
        }
    
}

