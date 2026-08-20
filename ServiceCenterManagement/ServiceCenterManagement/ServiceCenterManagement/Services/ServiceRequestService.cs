using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
      
            private readonly AppDbContext context;

            public ServiceRequestService(AppDbContext context)
            {
                this.context = context;
            }

            public List<ServiceRequest> GetAll()
            {
                return context.ServiceRequests.ToList();
            }

            public ServiceRequest GetById(int id)
            {
                return context.ServiceRequests.Find(id);
            }

            public void Add(ServiceRequest serviceRequest)
            {
                context.ServiceRequests.Add(serviceRequest);
                context.SaveChanges();
            }

            public void Update(ServiceRequest serviceRequest)
            {
                context.ServiceRequests.Update(serviceRequest);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                ServiceRequest serviceRequest =
                    context.ServiceRequests.Find(id);

                if (serviceRequest != null)
                {
                    context.ServiceRequests.Remove(serviceRequest);
                    context.SaveChanges();
                }
            }
        
    }
}

