using LicenseAssetManager.Models;
using LicenseAssetManager.Pages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLicenseAssetManager
{
    public class UnitTestCart
    {
        [Fact]
        public void Can_Load_Cart()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1"};
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // create a mock repository
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    p1, p2
                }).AsQueryable<Product>()
                );

            // create a cart
            Cart testCart = new Cart();
            testCart.AddItem(p1, 2);
            testCart.AddItem(p2, 1);
            testCart.RemoveLine(p1);

            // Action
            CartModel cartModel = new CartModel(mock.Object, testCart);
            cartModel.OnGet("myUrl");

            // Assert
            Assert.Equal(1, cartModel.Cart.Lines.Count);
            Assert.Equal("myUrl", cartModel.ReturnUrl);
        }

        [Fact]
        public void Can_Update_Cart()
        {
            // Arrange
            // create a mock repository
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                    new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                    new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                    new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                    new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
                }).AsQueryable<Product>()
                );

            Cart testCart = new Cart();

            // Action
            CartModel cartModel = new CartModel(mock.Object, testCart);
            cartModel.OnPost(2, "myUrl");

            // Assert
            Assert.Single(cartModel.Cart.Lines);
            Assert.Equal("P2", cartModel.Cart.Lines.First().Product.Name);
            Assert.Equal(1, cartModel.Cart.Lines.First().Quantity);
            Assert.Equal("/", cartModel.ReturnUrl);

        }

        [Fact]
        public void Can_RemoveFrom_Cart()
        {
            // Arrange
            // create a mock repository
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns(
                (new Product[]
                {
                    new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                    new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                    new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                    new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                    new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
                }).AsQueryable<Product>()
                );

            Cart testCart = new Cart();

            // Action
            CartModel cartModel = new CartModel(mock.Object, testCart);
            cartModel.OnPost(1, "myUrl");
            cartModel.OnPostRemove(1, "myUrl");

            // Assert
            Assert.Empty(cartModel.Cart.Lines);
            Assert.Equal("/", cartModel.ReturnUrl);
        }
    }
}
