using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class ServicePartService : IServicePartService
    {
        private readonly AppDbContext context;

        public ServicePartService(AppDbContext context)
        {
            this.context = context;
        }

        public List<ServicePart> GetAll()
        {
            return context.ServiceParts.ToList();
        }

        public ServicePart GetById(int id)
        {
            return context.ServiceParts.Find(id);
        }

        public void Add(ServicePart servicePart)
        {
            context.ServiceParts.Add(servicePart);
            context.SaveChanges();
        }

        public void Update(ServicePart servicePart)
        {
            ServicePart existingServicePart =
                context.ServiceParts.Find(servicePart.ServicePartId);

            if (existingServicePart == null)
            {
                throw new Exception("Service part not found");
            }

            existingServicePart.ServiceRequestId =
                servicePart.ServiceRequestId;

            existingServicePart.PartId =
                servicePart.PartId;

            existingServicePart.QuantityUsed =
                servicePart.QuantityUsed;

            existingServicePart.Price =
                servicePart.Price;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ServicePart servicePart = context.ServiceParts.Find(id);

            if (servicePart != null)
            {
                context.ServiceParts.Remove(servicePart);
                context.SaveChanges();
            }
        }
    }
}