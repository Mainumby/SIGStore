using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIG18.Domain.Entities;


namespace SIGStore.Models
{
    public class CartIndexViewModel
    {         
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}