using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerceApp.Shared.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This item is required...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This item is required...")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "This item is required...")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "This item is required...")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "This item is required...")]
        public string Description { get; set; }
    }
}
