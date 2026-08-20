using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface IServicePartService
    {
       
            List<ServicePart> GetAll();
            ServicePart GetById(int id);
            void Add(ServicePart servicePart);
            void Update(ServicePart servicePart);
            void Delete(int id);
        
    }
}

