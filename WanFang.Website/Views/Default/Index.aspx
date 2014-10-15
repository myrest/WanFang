<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 WanFang
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <!-- Put your CSS file here. -->
    <!-- link href="<%= Url.CdnContent("/CSS/Login.css") %>" rel="stylesheet" type="text/css" /-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Here is main content. -->
    Hello WanFan.
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <!-- put your javascript file here. -->
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
</asp:Content>
