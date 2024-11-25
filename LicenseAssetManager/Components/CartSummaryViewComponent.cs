using Microsoft.AspNetCore.Mvc;
using LicenseAssetManager.Models;

namespace LicenseAssetManager.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        private Cart cart;

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
