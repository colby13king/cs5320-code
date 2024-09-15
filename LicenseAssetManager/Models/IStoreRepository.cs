namespace LicenseAssetManager.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
