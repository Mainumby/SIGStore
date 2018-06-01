using SIG18.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SIG18.Domain.Abstract
{
   public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int Id);
    }
}
