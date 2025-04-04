﻿using LicenseAssetManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LicenseAssetManager.Controllers
{
    public class OrderController : Controller
    {
        public OrderController(IOrderRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        private IOrderRepository repository;
        private Cart cart;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if(ModelState.IsValid) 
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new {orderId = order.OrderID});
            }
            else
            {
                return View();
            }
        }
    }
}
