using _5AugAssignment.Models;

namespace _5AugAssignment.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void AddOrder(Order order)  ;
        Order GetOrder(int id); 
        void DeleteOrder(int id);
        void UpdateOrder(Order order) ;
    }
}
