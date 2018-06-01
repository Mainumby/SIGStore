using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIG18.Domain.Abstract;
using SIG18.Domain.Entities;

namespace SIGStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }
        // GET: Admin

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int Id)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.Id == Id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} guardado!", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
                
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Product deleteProduct = repository.DeleteProduct(Id);
            if(deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} borrado!!!",
                    deleteProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}