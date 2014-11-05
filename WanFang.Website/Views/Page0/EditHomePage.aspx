<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.HomePage_Info Model = ViewData["Model"] as WanFang.Domain.HomePage_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.HomePage_Info();
        }
    %>
    <script>
        function Save() {
            var param = $('#form1').serialize();

            utility.service("Page0Service/SaveHomePage", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page0', 'EditHomePage') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="HomePageId" value="<%=Model.HomePageId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">首頁及時資訊管理</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp首頁及時資訊管理</div>        <p class="clear"></p>
    </div>
    <div id="mainpage">
            <table class="ww100" cellspacing="1" cellpadding="2" border="0">
                <tr class="line-d">
                    <td class="line-d0 w150 top">標題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="Title" size="100" maxlength="255" value="<%=Model.Title %>">
                        <br />
                        （例：台北市立萬芳醫院－急診即時資訊）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">連結<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="Link" size="100" maxlength="255" value="<% =Model.Link %>" />
                        <br />
                        （例：about.aspx 或 img/1.jpg 或 http://www.xxx.com.tw/）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">顯示更新時間</td>
                    <td class="txt_l">
                        <input type="text" name="DisplayDateTime" size="100" maxlength="255" value="<%=Model.DisplayDateTime.HasValue ? Model.DisplayDateTime.Value.ToString("yyyy/MM/dd HH:mm") : "" %>" />
                        <br />
                        （例：更新時間 2014/06/03 13:20）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpdator %></td>
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
