using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRoutingDemo.Models;

namespace MvcRoutingDemo.Core.Data.Repository
{
    public class ProductRepository
    {
        readonly List<Product> _products = new List<Product>
            {
                new Product { Name = "Extremo Awesome TV", Brand = Brand.Visio, Price = 214.99M },
                new Product { Name = "Annihilator HD", Brand = Brand.Sony, Price = 5000.00M },
                new Product { Name = "Cardboard TV", Brand = Brand.GreatValue, Price = 4.99M },
                new Product { Name = "Awesome TV", Brand = Brand.Visio, Price = 513.57M },
                new Product { Name = "Generic TV", Brand = Brand.Panasonic, Price = 142.50M },
                new Product { Name = "48\" Attainable Widescreen TV", Brand = Brand.GreatValue, Price = 700M }
            };

        public IEnumerable<Product> Products { get { return _products; } }
    }
}