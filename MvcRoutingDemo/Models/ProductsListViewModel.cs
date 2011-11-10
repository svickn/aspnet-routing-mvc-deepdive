using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRoutingDemo.Models
{
    public class ProductsListViewModel
    {
        public Brand Brand { get; set; }
        public PriceRange PriceRange { get; set; }
        public List<Product> Products { get; set; }
    }
}