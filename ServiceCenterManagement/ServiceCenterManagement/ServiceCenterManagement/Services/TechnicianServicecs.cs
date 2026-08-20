using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly AppDbContext context;

        public TechnicianService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Technician> GetAll()
        {
            return context.Technicians.ToList();
        }

        public Technician GetById(int id)
        {
            return context.Technicians.Find(id);
        }

        public void Add(Technician technician)
        {
            context.Technicians.Add(technician);
            context.SaveChanges();
        }

        public void Update(Technician technician)
        {
            context.Technicians.Update(technician);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Technician technician = context.Technicians.Find(id);

            if (technician != null)
            {
                context.Technicians.Remove(technician);
                context.SaveChanges();
            }
        }
    }
}