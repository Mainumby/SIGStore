using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SIG18.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ingrese Direccion")]
        [Display(Name ="Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string Line3 { get; set; }



        [Required(ErrorMessage = "Ingrese Departamento")]
        public string State { get; set; }

        [Required(ErrorMessage = "Ingrese Ciudad")]
        public string City { get; set; }

        

        public string Zip { get; set; }

        [Required(ErrorMessage ="Pais")]  //omitir
        public string Country { get; set; }

        public bool GiftWrap { get; set; }



    }
}
