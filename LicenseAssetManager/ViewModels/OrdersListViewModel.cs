using LicenseAssetManager.Models;

namespace LicenseAssetManager.ViewModels
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = Enumerable.Empty<Order>();

        public IEnumerable<CartLine> CartLines { get; set; } = Enumerable.Empty<CartLine>();

        public Product? Product { get; set; }
    }
}
