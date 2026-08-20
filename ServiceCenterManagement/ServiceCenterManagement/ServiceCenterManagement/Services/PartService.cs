using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class PartService : IPartService
    {
       
            private readonly AppDbContext context;

            public PartService(AppDbContext context)
            {
                this.context = context;
            }

            public List<Part> GetAll()
            {
                return context.Parts.ToList();
            }

            public Part GetById(int id)
            {
                return context.Parts.Find(id);
            }

            public void Add(Part part)
            {
                context.Parts.Add(part);
                context.SaveChanges();
            }

            public void Update(Part part)
            {
                context.Parts.Update(part);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                Part part = context.Parts.Find(id);

                if (part != null)
                {
                    context.Parts.Remove(part);
                    context.SaveChanges();
                }
            }
        
    }
}

