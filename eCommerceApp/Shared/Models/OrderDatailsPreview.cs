using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCommerceApp.Shared.Models
{
   public class OrderDatailsPreview
    {
        [Required()]
        public string ProductCode { get; set; }
        [Required()]
        public string NamePoduct { get; set; }
        [Required()]
        public double? Price { get; set; }
        [Required()]
        public int? Cuantity { get; set; }
        [Required()]
        public int? Stock { get; set; }
    }
}
