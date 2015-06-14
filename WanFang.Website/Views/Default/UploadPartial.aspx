<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="WanFang.Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    UploadPartial
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Website.Models.ImagesViewModel> Model = ViewData["Model"] as List<WanFang.Website.Models.ImagesViewModel>;
        Model.ForEach(x =>
        {
    %>
    <a href="#" class="returnImage" data-url="<%=x.Url%>">
        <img src="<%=x.Url%>" alt="Hejsan" id="#image" data-source="<%=x.Url%>" width="200" height="200" />
    </a>

    <%
    });  
    %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <% Html.RenderPartial("~/Views/Shared/UserControls/CssReferences.ascx"); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <% Html.RenderPartial("~/Views/Shared/UserControls/ScriptReferences.ascx"); %>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".returnImage").click("click", function (e) {
                var urlImage = $(this).attr("data-url");
                //This takes the data value and id of the editor and sends the data(i.e.,image url) back to the caller page
                window.opener.updateValue(urlImage);
                window.close();
            });
        });
    </script>
</asp:Content>
