using _10AugAssignment.Data;
using _10AugAssignment.Models;
using _10AugAssignment.Repository;

namespace _10AugAssignment.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext context;

        public Purchase CreatePurchase(Purchase purchase)
        {
            if (purchase.PurchaseDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Purchase cannot happen");

            var automobile = context.Automobiles.FirstOrDefault(b => b.Id == purchase.AutomobileId);

            if (automobile == null)
                throw new ArgumentException("Invalid automobile");

           

            var company = context.Companies.FirstOrDefault(s => s.Id == purchase.Id);
            if (company== null)
                throw new ArgumentException("Invalid Company name");
            var vehicleAlreadyPurchased = context.Purchases.Any(b => b.Id == purchase.Id && b.PurchaseDate == purchase.PurchaseDate);

            if (vehicleAlreadyPurchased)
                throw new ArgumentException("This vehicle is already booked");

            var customer = new Customer();
            context.Customer.Add(customer);
            var purchase1 = new Purchase();
            context.Purchases.Add(purchase1);
            context.SaveChanges();

            return purchase;
        }

         public  List<Purchase> GetPurchases()
        {
            return context.Purchases.ToList();
        }

        public Purchase? GetPurchaseById(int id)
        {
            return context.Purchases.Find(id);
        }
    }
}
