using SIG18.Domain.Abstract;
using SIG18.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIGStore.Models;

namespace SIGStore.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController (IProductsRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }


        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart,ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "La compra está vacia!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Complete");
            }
            else
            {
                return View(shippingDetails);
            }
        }



        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                //Cart = GetCart(),
                ReturnUrl = returnUrl,
                Cart = cart

            });
        }


        public RedirectToRouteResult AddToCart(Cart cart,int Id, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                //GetCart().AddItem(product, 1);
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
            

            
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart; 

            }
            return cart;
        }

    }
}