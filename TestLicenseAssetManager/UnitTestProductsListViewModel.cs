using LicenseAssetManager.Models;
using LicenseAssetManager.ViewModels;

namespace TestLicenseAssetManager;

public class UnitTestProductsListViewModel
{
    [Fact]
    public void TestProductListViewModelCreation()
    {
        // Arrange
        ProductsListViewModel viewModel = new ProductsListViewModel();
        viewModel.Products = new List<Product>();
        
        // Act

        // Assert
        Assert.NotNull(viewModel);
        Assert.NotNull(viewModel.Products);
    }
}