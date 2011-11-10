using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRoutingDemo.Models
{
    public class Product
    {
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}