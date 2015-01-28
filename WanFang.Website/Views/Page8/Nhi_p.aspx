<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.Nhi_p_Info> Model = ViewData["Model"] as List<WanFang.Domain.Nhi_p_Info>;
        WanFang.Domain.Nhi_p_Filter filter = ViewData["Filter"] as WanFang.Domain.Nhi_p_Filter;
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteNhi_p", param, "POST", function (data) {
                    if (data.code > 0) {
                        document.location.reload(true);
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
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
                    健保專區項目管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp後端管理系統&nbsp&#187&nbsp健保專區項目管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                特材類型：
                <select name="nhi_code">
                    <option>請選擇</option>
                    <option <%=(filter.nhi_code == "塗藥血管支架") ? "selected" : "" %>>塗藥血管支架</option>
                    <option <%=(filter.nhi_code == "人工髖關節組件") ? "selected" : "" %>>人工髖關節組件</option>
                    <option <%=(filter.nhi_code == "特殊功能人工水晶體") ? "selected" : "" %>>特殊功能人工水晶體</option>
                    <option <%=(filter.nhi_code == "自費特材品項") ? "selected" : "" %>>自費特材品項 </option>
                    <option <%=(filter.nhi_code == "人工心律調節器") ? "selected" : "" %>>人工心律調節器 </option>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="nhi_cname" type="text" value="<%=(string.IsNullOrEmpty(filter.nhi_cname)) ? "請輸入中文品名搜尋" : filter.nhi_cname %>" onclick="this.value = '';"
                    size="30" id="nhi_cname" onkeydown="if(event.keyCode==13){this.form.submit();}" />
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
                <td class=" txt_r">
                    <input type="button" class="submit3" onclick="window.location = '/Page8/EditNhi_p/';"
                        value="新增資料">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content h30 txt_c">
                <td class="w20">
                    &nbsp;
                </td>
                <td class="w60">
                    發佈日期
                </td>
                <td>
                    特材類型
                </td>
                <td>
                    中文品名
                </td>
                <td class="w40">
                    點閱數
                </td>
                <!--點閱數 id=hit-->
                <td class="w80">
                    更新日期
                </td>
                <td class="w80">
                    編輯
                </td>
            </tr>
            <%
                foreach (var item in Model)
                {
            %>
            <tr class="mous01 top line-d va_m">
                <td>
                    <input type="checkbox" name="id" value="<%=item.nhi_pId %>" />
                </td>
                <td class="txt_c">
                    <%=(item.nhi_date.HasValue) ? item.nhi_date.Value.ToString("yyyy/MM/dd") : ""%>
                </td>
                <td>
                    <%=item.nhi_code%>
                </td>
                <td>
                    <%=item.nhi_cname%>
                </td>
                <td class="txt_c">
                    <%=item.hit %>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/Page8/EditNhi_p/<%=item.nhi_pId %>';"
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
        <span class="red">[注意事項]</span><br>
        1. 每10筆分1頁<br>
        2. 發布日期（由大至小）
        <br />
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
