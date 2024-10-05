using LicenseAssetManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace LicenseAssetManager.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public NavigationMenuViewComponent(IStoreRepository _repository) 
        {
            repository = _repository;
        }

        private IStoreRepository repository;

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
