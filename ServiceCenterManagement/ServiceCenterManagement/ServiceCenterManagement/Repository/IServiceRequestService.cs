using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface IServiceRequestService
    {
       
            List<ServiceRequest> GetAll();
            ServiceRequest GetById(int id);
            void Add(ServiceRequest serviceRequest);
            void Update(ServiceRequest serviceRequest);
            void Delete(int id);
        
    }
}

