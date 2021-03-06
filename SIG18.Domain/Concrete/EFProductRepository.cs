﻿using SIG18.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIG18.Domain.Abstract;

namespace SIG18.Domain.Concrete
{
    public class EFProductRepository:IProductsRepository
    {
        private EFDbContext context = new EFDbContext();


        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }


        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }


        public Product DeleteProduct(int Id)
        {
            Product dbEntry = context.Products.Find(Id);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
    
}
