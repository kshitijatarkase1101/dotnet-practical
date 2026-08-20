using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class VehicleService : IVehicleService
    {
        
        
            private readonly AppDbContext context;

            public VehicleService(AppDbContext context)
            {
                this.context = context;
            }

            public List<Vehicle> GetAll()
            {
                return context.Vehicles.ToList();
            }

            public Vehicle GetById(int id)
            {
                return context.Vehicles.Find(id);
            }

            public void Add(Vehicle vehicle)
            {
                context.Vehicles.Add(vehicle);
                context.SaveChanges();
            }

        public void Update(Vehicle vehicle)
        {
            Vehicle existingVehicle =
                context.Vehicles.Find(vehicle.VehicleId);

            if (existingVehicle == null)
            {
                throw new Exception("Vehicle not found");
            }

            existingVehicle.CustomerId = vehicle.CustomerId;
            existingVehicle.VehicleNumber = vehicle.VehicleNumber;
            existingVehicle.Brand = vehicle.Brand;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Year = vehicle.Year;
            existingVehicle.VehicleType = vehicle.VehicleType;

            context.SaveChanges();
        }

        public void Delete(int id)
            {
                Vehicle vehicle = context.Vehicles.Find(id);

                if (vehicle != null)
                {
                    context.Vehicles.Remove(vehicle);
                    context.SaveChanges();
                }
            }
        
    }
}

