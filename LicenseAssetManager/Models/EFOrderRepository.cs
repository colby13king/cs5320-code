
using Microsoft.EntityFrameworkCore;

namespace LicenseAssetManager.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        public EFOrderRepository(StoreDbContext ctx) 
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        private StoreDbContext context;

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0 )
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
