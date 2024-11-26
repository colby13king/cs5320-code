using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LicenseAssetManager.Infrastructure;
using LicenseAssetManager.Models;

namespace LicenseAssetManager.Pages
{
    public class CartModel : PageModel
    {
        public CartModel(IStoreRepository _repository, Cart cartService)
        {
            repository = _repository;
            Cart = cartService;
        }
        private IStoreRepository repository;

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                
                //HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long ProductID, string returnUrl) 
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == ProductID).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
            
           
        }
    }
}
