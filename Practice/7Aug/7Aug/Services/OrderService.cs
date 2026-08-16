using _7Aug.Data;
using _7Aug.Models;
using _7Aug.Repository;
using Microsoft.EntityFrameworkCore;

namespace _7Aug.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

            public OrderService (AppDbContext context)
        {
            this.context = context;
        }

       
        public List<Orders> GetOrders()
        {
            //load orderitems for each order, load product details for each orderitem
            return context.Orders.Include(o => o.OrderItems!).ThenInclude(i => i.product).ToList(); } 
        }


    }
}
