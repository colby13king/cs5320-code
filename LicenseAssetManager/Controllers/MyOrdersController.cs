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

        public IActionResult Index(string? userName) 
        {
            // Note that the view is Views/Home/Index.cshtml
            var orders = repository.Orders.Where(o => o.Name == userName).OrderBy(o => o.OrderID);
            var cartLines = repository.CartLines;

            return View(
                new OrdersListViewModel
                {
                    Orders = orders,
                    CartLines = cartLines
                }
            );
        }
    }
}
