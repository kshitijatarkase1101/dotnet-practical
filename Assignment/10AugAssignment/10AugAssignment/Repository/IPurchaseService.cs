using _10AugAssignment.Models;

namespace _10AugAssignment.Repository
{
    public interface IPurchaseService
    {
        Purchase CreatePurchase(Purchase purchase);
        List<Purchase> GetPurchases();
        Purchase GetPurchaseById(int purchaseId);
    }
}
