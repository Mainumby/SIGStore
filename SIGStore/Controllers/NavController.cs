using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIG18.Domain.Abstract;

namespace SIGStore.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;


        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        
    public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);
            return PartialView(categories);
        }

        //// GET: Nav
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}