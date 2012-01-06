using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsRoutingDemo
{
    public partial class OtherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var path = RouteTable.Routes.GetVirtualPath(null, "homeRoute", new RouteValueDictionary());
            homePageHyperLink.NavigateUrl = path.VirtualPath;
        }
    }
}