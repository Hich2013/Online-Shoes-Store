using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Models
{
    [Bind(Exclude = "ProductId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "A Product Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 130.00,
            ErrorMessage = "Price must be between 0.01 and 130.00")]
        public decimal Price { get; set; }

        [DisplayName("Product Image URL")]
        [StringLength(1024)]
        public string ProductArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Brand Brand { get; set; }
    }
}