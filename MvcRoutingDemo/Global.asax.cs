using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcRoutingDemo.Controllers;
using MvcRoutingDemo.Core.Routing;
using MvcRoutingDemo.Models;

namespace MvcRoutingDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignoring a route is the same as adding a route with the StopRoutingHandler
            // this effectively tells routing to let ASP.NET handle this path like it would normally.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // Vanilla routing
            AddRoutesWithVanillaRouting(routes);

            // RouteConstraint
            //AddRoutesWithCustomRouteConstraint(routes);

            // RouteBase
            //AddRoutesWithCustomRouteBase(routes);

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        private static void AddRoutesWithCustomRouteBase(RouteCollection routes)
        {
            routes.Add(new DynamicPathRoute<ProductsController>(c => c.List(Brand.All, PriceRange.Any)));
        }

        private static void AddRoutesWithCustomRouteConstraint(RouteCollection routes)
        {
            routes.MapRoute("Products-List-Brand-And-PriceRange",
                            "Products/List/{brand}/{priceRange}",
                            new {controller = "Products", action = "List"});

            routes.MapRoute("Products-List-Brand-Only",
                            "Products/List/{brand}",
                            new {controller = "Products", action = "List"},
                            new {brand = new EnumRouteConstraint<Brand>()});

            routes.MapRoute("Products-List-PriceRange-Only",
                            "Products/List/{priceRange}",
                            new {controller = "Products", action = "List"},
                            new {priceRange = new EnumRouteConstraint<PriceRange>()});
        }

        private static void AddRoutesWithVanillaRouting(RouteCollection routes)
        {
            routes.MapRoute("Products-List-Brand-And-PriceRange",
                            "Products/List/{brand}/{priceRange}",
                            new {controller = "Products", action = "List"});

            routes.MapRoute("Products-List-Brand-Only",
                            "Products/List/{brand}",
                            new {controller = "Products", action = "List"},
                            new {brand = "All|Sony|Panasonic|GreatValue|Visio"});

            routes.MapRoute("Products-List-PriceRange-Only",
                            "Products/List/{priceRange}",
                            new {controller = "Products", action = "List"},
                            new {priceRange = "Any|Under100|From100To500|Above500"});
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}