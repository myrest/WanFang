﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.HirCategory_Info> Model = ViewData["Model"] as List<WanFang.Domain.HirCategory_Info>;
        WanFang.Domain.HirCategory_Filter filter = ViewData["Filter"] as WanFang.Domain.HirCategory_Filter;
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.service("DeleteService/DeleteHirCategory", param, "POST", function (data) {
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
                    人員募集類別代號管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp人員募集管理&nbsp&#187&nbsp人員募集類別代號管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <table class="ww100 magTop10" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <input name="button" type="button" class="submit" value="全選" onclick="selectAll(this.form);">
                    <input name="Del" type="button" class="submit" value="刪除" onclick="DeleteSelected();">
                    <input name="button2" type="button" class="submit" value="取消全選" onclick="unselectAll(this.form);">
                    --點選以下項目來進行維護
                </td>
                <td class=" txt_r">
                    <input type="button" class="submit3" onclick="window.location = '/Page7/EditHirCategory/';"
                        value="新增資料">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
                <tr class="form-content h30 txt_c">
                    <td class="w20">&nbsp;</td>
                    <td class="w80">順序</td>
                    <td>類別名稱</td>
                    <td class="w80">上/下架</td>
                    <td class="w80">更新日期</td>
                    <td class="w70">編輯</td>
                </tr>            <%
                foreach (var item in Model)
                {
            %>
                <tr class="top mous01 line-d va_m">
                    <td>
                        <input type="checkbox" name="id" value="<%=item.HirCategoryId %>" />
                    </td>
                    <td class="txt_c"><%=item.SortNum %></td>
                    <td><%=item.CategoryName %></td>
                    <td class="txt_c"><%=(item.IsActive > 0) ? "上架" : "下架"%></td>
                    <td class="txt_c"><%=item.LastUpdate %></td>
                    <td class="txt_c">
                        <input name="bt_edit" type="button" class="submit" onclick="window.location='/Page7/EditHirCategory/<%=item.HirCategoryId %>';"
                            value="編輯">
                    </td>
                </tr>            <%
                }
            %>
        </table>
        <br />
        <!-- div class="m_page">
            < % Html.RenderPartial("~/Views/Shared/UserControls/PagingBar.ascx"); %>
        </div>
        <br / -->
        <span class="red">[注意事項]</span><br />
        1. 不分頁<br />
        2. 排序：順序（由小至大）<br />
        <span class="red">3. 類別底下有對應資料時，該筆不允許刪除</span>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
