using LicenseAssetManager.Controllers;
using LicenseAssetManager.Models;
using LicenseAssetManager.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLicenseAssetManager
{
    public class UnitTestViewModels
    {
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    new() {ProductID = 1, Name = "P1", Category = "Apples"},
                    new() {ProductID = 2, Name = "P2", Category = "Apples"},
                    new() {ProductID = 3, Name = "P3", Category = "Plums"},
                    new() {ProductID = 4, Name = "P4", Category = "Oranges"},
                    new(){ProductID = 5, Name = "P5", Category = "Oranges"}
                }).AsQueryable<Product>()
                );

            HomeController controller = new HomeController(mock.Object) { PageSize = 3 };

            // Act
            ProductsListViewModel result = controller.Index(null, 2)?.ViewData.Model as ProductsListViewModel ?? new();

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    new() {ProductID = 1, Name = "P1", Category = "Apples"},
                    new() {ProductID = 2, Name = "P2", Category = "Apples"}
                }).AsQueryable<Product>()
                );

            HomeController controller = new HomeController(mock.Object);

            // Act
            ProductsListViewModel result = controller.Index(null)?.ViewData.Model as ProductsListViewModel ?? new();

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2 );
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    new() {ProductID = 1, Name = "P1", Category = "Apples"},
                    new() {ProductID = 2, Name = "P2", Category = "Apples"},
                    new() {ProductID = 3, Name = "P3", Category = "Plums"},
                    new() {ProductID = 4, Name = "P4", Category = "Oranges"},
                    new() {ProductID = 5, Name = "P5", Category = "Oranges"}
                }).AsQueryable<Product>()
                );

            HomeController controller = new HomeController(mock.Object) { PageSize = 3 };

            // Act
            ProductsListViewModel result = controller.Index(null, 2)?.ViewData.Model as ProductsListViewModel ?? new();

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}
