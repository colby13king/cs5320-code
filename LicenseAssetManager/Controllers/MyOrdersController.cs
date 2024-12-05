using LicenseAssetManager.Models;
using LicenseAssetManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace LicenseAssetManager.Controllers
{
    public class MyOrdersController : Controller
    {
        public MyOrdersController(IStoreRepository repo)
        {
            repository = repo;
        }

        private IStoreRepository repository;

        // Example to use this page
        // http://localhost:5228/myorders/Index/?userName=jwilli11&passWord=123&productName=BestCAD
        public IActionResult Index(string? userName, string? passWord, string? productName) 
        {
            // Note that the view is Views/Home/Index.cshtml
            // Get the users orders
            var orders = repository.Orders.
                Where(o => 
                        o.Name == userName 
                        && o.PassWord == passWord
                      )
                .OrderBy(o => o.OrderID);

            //List<CartLine> orderCartLines = new List<CartLine>();
            
            // Get the Product from the Products list
            Product? theProduct = repository.Products.Where(p => p.Name == productName).FirstOrDefault();

            Product? foundProduct = null;

            if (orders.Any())
            {
                // the userName has some orders
                // go thru the cartline table
                // I'm sure there must be a better search!

                foreach (var cl in repository.CartLines)
                {
                    if(cl.Product.ProductID == theProduct?.ProductID)
                    {
                        // orders are specific to the user
                        foreach(var order in orders)
                        {
                            if(order.Lines.Contains(cl))
                            {
                                foundProduct = theProduct;
                            }
                        }
                    }
                }
            }

            return View(
                new OrdersListViewModel
                {
                    Orders = orders,
                    Product = foundProduct,
                    CartLines = new List<CartLine>()
                }
            );
        }
    }
}
