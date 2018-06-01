using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;

namespace SIG18.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Por favor ingrese un nombre")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]

        [Required(ErrorMessage ="Por favor ingrese una descripcion")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="Ingrese un Precio.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Especifique una categoria")]
        public string Category { get; set; }
    }
}
