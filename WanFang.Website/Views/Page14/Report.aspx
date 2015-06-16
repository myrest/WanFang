<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.Report_Info> Model = ViewData["Model"] as List<WanFang.Domain.Report_Info>;
        WanFang.Domain.Report_Filter filter = ViewData["Filter"] as WanFang.Domain.Report_Filter;
    %>
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    報表
                </div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp報表
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                天數：<select name="DaysOfPeroid">
                    <%
                        string selected = "selected=\"selected\"";
                    %>
                    <option <%=(filter.DaysOfPeroid.Value == 120) ? selected : "" %>>120</option>
                    <option <%=(filter.DaysOfPeroid.Value == 90) ? selected : "" %>>90</option>
                    <option <%=(filter.DaysOfPeroid.Value == 60) ? selected : "" %>>60</option>
                    <option <%=(filter.DaysOfPeroid.Value == 30) ? selected : "" %>>30</option>
                </select><br />
                名稱：
                <input name="ItemName" type="text" value="<%=(string.IsNullOrEmpty(filter.ItemName)) ? "請輸入完整名稱搜尋" : filter.ItemName %>" onclick="this.value = '';" size="30"
                    id="ItemName" onkeydown="if(event.keyCode==13){this.form.submit();}" /><br />
                網址：
                <input name="Url" type="text" value="<%=(string.IsNullOrEmpty(filter.Url)) ? "請輸入部份網址搜尋" : filter.Url %>" onclick="this.value = '';" size="30"
                    id="Url" onkeydown="if(event.keyCode==13){this.form.submit();}" /><br />
                <input type="submit" class="submit" value="搜尋" id="Submit" />
            </p>
        </div>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content h30 txt_c">
                <td class="w20">&nbsp;
                </td>
                <td>名稱
                </td>
                <td>網址
                </td>
                <td>來源
                </td>
                <td>IP
                </td>
                <td>建立時間
                </td>
            </tr>
            <%
                Rest.Core.Paging Page = ViewData["Page"] as Rest.Core.Paging;
                int CurrentPage = Convert.ToInt32(Page.CurrentPage);
                long SerialNumber = (CurrentPage - 1) * Page.ItemsPerPage;
                foreach (var item in Model)
                {
                    SerialNumber++;
            %>
            <tr class="top mous01 line-d va_m">
                <td class="txt_c">
                    <%=SerialNumber %>
                </td>
                <td class="txt_c">
                    <%=item.ItemName %>
                </td>
                <td style="word-break:break-all;">
                    <%=item.Url %>
                </td>
                <td style="word-break:break-all;">
                    <%=item.Reff %>
                </td>
                <td>
                    <%=item.IP %>
                </td>
                <td>
                    <%=item.CreateDateTime.ToString() %>
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
        <span class="red">[注意事項]</span><br>
        1. 每10筆分1頁<br>
        2. 建立時間（由大至小）
        <br />
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
