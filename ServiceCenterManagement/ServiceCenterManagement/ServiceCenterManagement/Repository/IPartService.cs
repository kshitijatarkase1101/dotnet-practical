using ServiceCenterManagement.Models;

namespace ServiceCenterManagement.Repository
{
    public interface IPartService
    {
        
        
            List<Part> GetAll();
            Part GetById(int id);
            void Add(Part part);
            void Update(Part part);
            void Delete(int id);
        
    }
}

