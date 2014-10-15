<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--new 登入頁面-->
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    後端管理系統</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <div align="center">
            <div id="signin" class="wd100">
                <p>
                    您好，歡迎您的登入</p>
                <p>
                    &nbsp;</p>
                <p>
                    直接點選左方選單進行管理，謝謝！
                </p>
                <p>
                    &nbsp;</p>
            </div>
        </div>
        <!--mainpage end-->
    </div>
    <!--new 登入頁面-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
