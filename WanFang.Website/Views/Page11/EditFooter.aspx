<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.Footer_Info Model = ViewData["Model"] as WanFang.Domain.Footer_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Footer_Info();
        }
    %>
    <script>
        function Save() {
            var param = $('#form1').serialize();

            utility.service("Page11Service/SaveFooter", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page11', 'EditFooter') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="FooterId" value="<%=Model.FooterId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">表尾資料管理</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp表尾資料管理</div>        <p class="clear"></p>
    </div>
    <div id="mainpage">
            <table class="ww100" cellspacing="1" cellpadding="2" border="0">
                <tr class="line-d">
                    <td class="line-d0 w150 top">表尾資料<span class="red">*</span></td>
                    <td class="txt_l">
                        <textarea name="FooterText" cols="80" rows="5"><%=Model.FooterText %></textarea>
                        <br />
                        （例：Copyright © 2014 台北市立萬芳醫院-委託財團法人私立臺北醫學大學辦理.版權所有 地址:116 台北市文山區興隆路三段111號 醫院代表號: 02-29307930
最佳瀏覽環境：IE8 以上版本．瀏覽解析度 1024 x 768 ．資訊安全與隱私權政策． 最後更新時間:2014/03/04）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">院長信箱</td>
                    <td class="txt_l">
                        <input type="text" name="FooterTextMail" size="50" maxlength="255" value="<%=Model.FooterTextMail %>" />
                        （例：p1_about_service_dean.aspx）</td>
                </tr>                <tr class="line-d">
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
