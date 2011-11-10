using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRoutingDemo.Core.Routing
{
    public class DynamicPathRoute<T> : RouteBase where T : Controller
    {
        private readonly RouteCollection _routes = new RouteCollection();

        public DynamicPathRoute(Expression<Action<T>> expression)
        {
            var methodBody = expression.Body as MethodCallExpression;

            if(methodBody == null)
                throw new ArgumentException("Could not determine method from expression", "expression");

            var controllerName = typeof(T).Name.Replace("Controller", String.Empty);
            var actionName = methodBody.Method.Name;
            var parameters = new List<Tuple<string, object>>();

            for (int i = 0; i < methodBody.Arguments.Count; i++)
            {
                var argumentValue = GetArgumentValue(methodBody.Arguments[i]);
                parameters.Add(new Tuple<string, object>(methodBody.Method.GetParameters()[i].Name, argumentValue));
            }

            var defaults = new RouteValueDictionary();
            defaults.Add("controller", controllerName);
            defaults.Add("action", actionName);
            parameters.ForEach(p => defaults.Add(p.Item1, p.Item2));

            // Add route for all params
            _routes.Add(
                new Route(
                    string.Format("{0}/{1}/{2}", controllerName, actionName,
                        string.Join("/", parameters.Select(t => "{" + t.Item1 + "}").ToArray())), 
                    defaults,
                    new MvcRouteHandler()));

            // Individual routes
            parameters.ForEach(p => _routes.Add(new Route(string.Format("{0}/{1}/{2}", controllerName, actionName, "{" + p.Item1 + "}"),
                                                          defaults,
                                                          new MvcRouteHandler())));
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            foreach (var route in _routes)
            {
                var data = route.GetRouteData(httpContext);
                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            foreach (var route in _routes)
            {
                var path = route.GetVirtualPath(requestContext, values);
                if (path != null)
                {
                    return path;
                }
            }
            return null;
        }

        private static object GetArgumentValue(Expression element)
        {
            LambdaExpression l = Expression.Lambda(Expression.Convert(element, element.Type));
            return l.Compile().DynamicInvoke();
        }
    }
}