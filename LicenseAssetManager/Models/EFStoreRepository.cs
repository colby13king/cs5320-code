
namespace LicenseAssetManager.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        public EFStoreRepository(StoreDbContext _context) 
        {
            context = _context;
        }

        private StoreDbContext context;

        public IQueryable<Product> Products => context.Products;

        public IQueryable<Order> Orders => context.Orders;

        public IQueryable<CartLine> CartLines => context.CartLines;
    }
}
