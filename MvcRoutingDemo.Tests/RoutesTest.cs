using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRoutingDemo;
using MvcRoutingDemo.Controllers;
using MvcContrib.TestHelper;
using MvcRoutingDemo.Models;

namespace MvcRoutingDemo.Tests
{
    [TestClass]
    public class RoutesTest
    {
        
        [TestInitialize]
        public void TestInitialize()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [TestMethod]
        public void ProductsListWithBrandAndPriceRange()
        {
            "~/Products/List/Sony/Any"
                .ShouldMapTo<ProductsController>(p => p.List(Brand.Sony, PriceRange.Any));
        }
    }
}
