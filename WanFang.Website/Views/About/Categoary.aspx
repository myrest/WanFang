<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.AboutCategory_Info> Model = ViewData["Model"] as List<WanFang.Domain.AboutCategory_Info>;
        List<WanFang.Domain.About_Info> About = ViewData["About"] as List<WanFang.Domain.About_Info>;
        WanFang.Domain.AboutCategory_Filter filter = ViewData["Filter"] as WanFang.Domain.AboutCategory_Filter;
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.service("DeleteService/DeleteAboutCategoary", param, "POST", function (data) {
                if (data.code > 0) {
                    document.location.reload(true);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }
    </script>
    <!--new 關於萬芳／p1_about.aspx-->
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    關於萬芳系列管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp關於萬芳管理&nbsp&#187&nbsp關於萬芳系列管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                上下架：
                <%=WanFang.Core.MVC.Extensions.UrlExtension.GenerFilterIsActive(filter.IsActive) %>
            </p>
            <p>
                類&nbsp;&nbsp;&nbsp;&nbsp;別：
                <select name="AboutId">
                    <option>全部顯示</option>
                    <%
                        foreach (var item in About)
                        {
                            string selected = "";
                            if (filter.AboutId.HasValue && filter.AboutId.Value == item.AboutId)
                            {
                                selected = "selected";
                            }
                            Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.AboutId, selected, item.Category));
                        }
                    %>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="Category" type="text" value="請輸入系列名稱搜尋" onclick="this.value = '';" size="30"
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
                <td class="w70 txt_r">
                    <input name="Add" id="Add" type="button" class="submit3" onclick="window.location = '/About/EditAboutCategoary/';" value="新增資料">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content h30 txt_c">
                <td class="w20">
                    &nbsp;
                </td>
                <td class="w100 txt_c">
                    類別名稱
                </td>
                <td class="w80 txt_c">
                    順序
                </td>
                <td>
                    系列名稱
                </td>
                <td class="w80">
                    上/下架
                </td>
                <td class="w80">
                    更新日期
                </td>
                <td class="w70">
                    編輯
                </td>
            </tr>
            <%
                foreach (var item in Model)
                {
            %>
            <tr class="top mous01 line-d va_m">
                <td>
                    <input type="checkbox" name="id" value="<%=item.AboutCategoryId %>" />
                </td>
                <td class="txt_c">
                    <% =About.Where(x=>x.AboutId == item.AboutId).FirstOrDefault().Category %>
                </td>
                <td class="txt_c">
                    <%=item.SortNum %>
                </td>
                <td class="txt_c">
                    <%=item.Category %>
                </td>
                <td class="txt_c"><%=(item.IsActive > 0) ? "上架" : "下架"%></td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/About/EditAboutCategoary/<%=item.AboutCategoryId %>';"
                        value="編輯">
                </td>
            </tr>
            <%
                }
            %>
        </table>
        <br />
        <div class="m_page">
        <% Html.RenderPartial("~/Views/Shared/UserControls/PagingBar.ascx"); %>
        </div>
        <br />
        <span class="red">[注意事項]</span><br />
        1. 每10筆分1頁<br />
        2. 排序：系列順序（由小至大）<br />
        <span class="red">3. 系列底下有對應資料時，該筆不允許刪除</span>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
