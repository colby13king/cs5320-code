using LicenseAssetManager.Models;
using LicenseAssetManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LicenseAssetManager.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        private IStoreRepository repository;

        public int PageSize = 1;

        public IActionResult Index(int productPage = 1)
        {
            // Note that the view is Views/Home/Index.cshtml
            return View(
                new ProductsListViewModel
                {
                    Products = repository.Products.OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    }
                }
                );
        }

        public IActionResult Privacy()
        {
            // Note that the view is Views/Home/Privacy.cshtml
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Note that the view is Views/Shared/Error.cshtml
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
