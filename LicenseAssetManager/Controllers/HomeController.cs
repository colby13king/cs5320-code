using LicenseAssetManager.Models;
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

        public IActionResult Index()
        {
            // Note that the view is Views/Home/Index.cshtml
            return View(repository.Products);
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
