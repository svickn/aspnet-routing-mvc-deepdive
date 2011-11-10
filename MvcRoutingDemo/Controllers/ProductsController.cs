using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRoutingDemo.Core.Data.Repository;
using MvcRoutingDemo.Models;

namespace MvcRoutingDemo.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult List(Brand brand = Brand.All, PriceRange priceRange = PriceRange.Any)
        {
            var products = new ProductRepository().Products;

            if (brand != Brand.All)
                products = products.Where(product => product.Brand == brand);

            if (priceRange != PriceRange.Any)
                products = products.Where(product => ProductIsInRange(product, priceRange));

            return View(new ProductsListViewModel
                            {
                                Brand = brand,
                                PriceRange = priceRange,
                                Products = products.ToList()
                            });
        }

        private bool ProductIsInRange(Product product, PriceRange priceRange)
        {
            switch (priceRange)
            {
                case PriceRange.Under100:
                    return product.Price < 100M;
                case PriceRange.From100To500:
                    return product.Price >= 100M && product.Price <= 500M;
                case PriceRange.Above500:
                    return product.Price > 500M;
                default: return true;
            }
        }
    }
}
