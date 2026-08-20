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
            Part existingPart =
                context.Parts.Find(part.PartId);

            if (existingPart == null)
            {
                throw new Exception("Part not found");
            }

            existingPart.PartName = part.PartName;
            existingPart.PartNumber = part.PartNumber;
            existingPart.Price = part.Price;
            existingPart.Quantity = part.Quantity;
            existingPart.Supplier = part.Supplier;

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

