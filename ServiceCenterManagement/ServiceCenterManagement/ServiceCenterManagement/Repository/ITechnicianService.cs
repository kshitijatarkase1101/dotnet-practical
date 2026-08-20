using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface ITechnicianService
    {
        
            List<Technician> GetAll();
            Technician GetById(int id);
            void Add(Technician technician);
            void Update(Technician technician);
            void Delete(int id);
        
    }
}

