<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        var UserName = ViewData["UserName"].ToString();
    %>
    <script>
        function Save() {
            var param = $('#form1').serialize();

            utility.service("ManageService/ChangePassword", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Manage', 'ChangePassword') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">密碼變更</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp密碼變更</div>        <p class="clear"></p>
    </div>
    <div id="mainpage">
            <table border="0" align="center" cellpadding="2" cellspacing="1">
                <tr class="line-d va_m">
                    <td class="line-d0 w150 h30">管理者名稱</td>
                    <td class="txt_l"><%=UserName %></td>
                </tr>
                <tr class="line-d va_m">
                    <td class="line-d0 h30">原登入密碼<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="oldpw" type="password""></td>
                </tr>
                <tr class="line-d va_m">
                    <td class="line-d0 h30">新密碼<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="newpw" type="password"></td>
                </tr>
                <tr class="line-d va_m">
                    <td class="line-d0 h30">確認新密碼<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="repw" type="password"></td>
                </tr>
            </table>        <div class="txt_c mag15" id="sendadd">
            <input type="button" class="submit" id="Submit" value="送出" onclick="Save();" />
        </div>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
