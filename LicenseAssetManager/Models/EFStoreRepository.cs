
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

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }

        public IQueryable<Order> Orders => context.Orders;

        public IQueryable<CartLine> CartLines => context.CartLines;
    }
}
