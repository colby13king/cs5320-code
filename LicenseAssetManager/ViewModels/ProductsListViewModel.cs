using LicenseAssetManager.Models;

namespace LicenseAssetManager.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        public PagingInfo PagingInfo { get; set; } = new();

        // 8.1.1
        public string? CurrentCategory { get; set; }
    }
}
