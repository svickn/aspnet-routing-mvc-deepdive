using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MvcRoutingDemo.Core.Routing
{
    public class EnumRouteConstraint<T> : IRouteConstraint 
        where T : struct, IComparable, IFormattable, IConvertible
    {
        static EnumRouteConstraint()
        {
            if(!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type.");
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = values[parameterName];

            return Enum.GetNames(typeof (T)).Contains(value);
        }
    }
}