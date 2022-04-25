using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eCommerceApp.Shared.Models
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string NameProduct { get; set; }
        public int? ProductQty { get; set; }
        public double? TotalSales { get; set; }
    }
}
