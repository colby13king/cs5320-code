using LicenseAssetManager.Models;

namespace TestLicenseAssetManager
{
    public class UnitTestModels
    {
        [Fact]
        public void TestErrorViewModel()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            Assert.NotNull(errorViewModel);
        }

        [Fact]
        public void TestProduct()
        {
            // Arrange
            Product product = new Product()
            {
                ProductID = 1,
                Category = "Cat1",
                Price = 1,
                Name = "P1",
                Description = "Product Description"
            };

            // Assert
            Assert.NotNull(product);
            Assert.Equal(1, product.ProductID);
            Assert.Equal("Cat1", product.Category);
            Assert.Equal(1, product.Price);
            Assert.Equal("P1", product.Name);
            Assert.Equal("Product Description", product.Description);
        }
    }
}