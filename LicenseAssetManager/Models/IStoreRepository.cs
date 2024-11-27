namespace LicenseAssetManager.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }

        IQueryable<Order> Orders { get; }

        IQueryable<CartLine> CartLines { get; }
    }
}
