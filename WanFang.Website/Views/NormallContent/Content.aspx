﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.NormallContent_Info> Model = ViewData["Model"] as List<WanFang.Domain.NormallContent_Info>;
        WanFang.Domain.NormallContent_Filter filter = ViewData["Filter"] as WanFang.Domain.NormallContent_Filter;
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.service("DeleteService/DeleteNormallContent", param, "POST", function (data) {
                if (data.code > 0) {
                    document.location.reload(true);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }
    </script>
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    <%=ViewData["Header1"].ToString() %></div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp<%=ViewData["Header2"].ToString() %>&nbsp&#187&nbsp<%=ViewData["Header1"].ToString() %>
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                關鍵字：
                <input name="Category" type="text" value="請輸入單元名稱搜尋" onclick="this.value = '';" size="30"
                    id="Category" onkeydown="if(event.keyCode==13){this.form.submit();}" />
                <input type="submit" class="submit" value="搜尋" id="Submit" />
            </p>
        </div>
        <table class="ww100 magTop10" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <input name="button" type="button" class="submit" value="全選" onclick="selectAll(this.form);">
                    <input name="Del" type="button" class="submit" value="刪除" onclick="DeleteSelected();">
                    <input name="button2" type="button" class="submit" value="取消全選" onclick="unselectAll(this.form);">
                    --點選以下項目來進行維護
                </td>
                <td class=" txt_r">                    <input type="button" class="submit3" onclick="window.location = '/NormallContent/<%=ViewData["EditPage"].ToString() %>/';"
                        value="新增資料">
                    <input type="button" class="submit3" onclick="window.location = './Pending';" value="待審核">                </td>
            </tr>
        </table>
            <table class="ww100" border="0" cellpadding="2" cellspacing="1">
                <tr class="form-content txt_c h30">
                    <td class="w20">&nbsp;</td>
                    <td class="w60">單元名稱</td>
                    <td class="w80">上/下架</td>
                    <td class="w80">更新日期</td>
                    <td class="w70">編輯</td>
                </tr>            <%
                foreach (var item in Model)
                {
            %>
                <tr class="top mous01 line-d va_m">
                    <td>
                        <input type="checkbox" name="id" value="<%=item.NormallContentId %>" /></td>
                    <td class="txt_c"><%=item.UnitName %></td>
                    <td class="txt_c"><%=WanFang.Core.MVC.Extensions.UrlExtension.GenerIsActive(item.IsActive, true)%></td>
                    <td class="txt_c"><%=item.LastUpdate %></td>
                    <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/NormallContent/<%=ViewData["EditPage"].ToString() %>/<%=item.NormallContentId %>';"
                        value="編輯">
                        </td>
                </tr>
            <%
                }
            %>
            </table>        <br />
        <div class="m_page">
        <% Html.RenderPartial("~/Views/Shared/UserControls/PagingBar.ascx"); %>
        </div>
        <br />
        <span class="red">[注意事項]</span><br />
        1. 每10筆分1頁<br />
        2. 排序：單元名稱（由小至大）
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
