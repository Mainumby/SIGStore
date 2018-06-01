using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIG18.Domain.Entities;

namespace SIGStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}