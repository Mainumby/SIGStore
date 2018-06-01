using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIG18.Domain.Entities;
using SIG18.Domain.Abstract;
using SIGStore.Models;

namespace SIGStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}


        public ViewResult List( string category, int page = 1)
        {
            //return View(repository.Products
            //    .OrderBy( p => p.Id)
            //    .Skip((page - 1) * PageSize)
            //    .Take(PageSize));

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)  //agregado para filtrar por categoria
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()
                    TotalItems = category == null ? 
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category   //agregado para filtrar categoria
            };
            return View(model);
            }
        }
    }
 