<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsRoutingDemo._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Default.aspx</h1>
        <% if (RouteData.Values["name"] != null)
           { %>
            <h3>Hello <asp:Literal runat="server" Text="<%$RouteValue:name%>"/></h3>
        <% } %>
        <asp:HyperLink runat="server" NavigateUrl="<%$RouteUrl:routeName=otherPageRoute%>">Go to other page!</asp:HyperLink>
    </div>
    </form>
</body>
</html>
