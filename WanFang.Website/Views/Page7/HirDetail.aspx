<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool IsVerifer = (bool)ViewData["Verify"];
        string VeriferClass = IsVerifer ? "" : " hide ";
        string CanNotEdit = IsVerifer ? " hide " : "";

        List<WanFang.Domain.HirDetail_Info> Model = ViewData["Model"] as List<WanFang.Domain.HirDetail_Info>;
        WanFang.Domain.HirDetail_Filter filter = ViewData["Filter"] as WanFang.Domain.HirDetail_Filter;

        var categoary = new WanFang.BLL.HirCategory_Manager().GetAll();
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteHirDetail", param, "POST", function (data) {
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
                    人員募集項目管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp人員募集管理&nbsp&#187&nbsp人員募集項目管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                發佈狀態：
                <select name="IsActive" id="IsActive">
                    <option>請選擇</option>
                    <option value="0" <%=(filter.IsActive == 0) ? "selected" : "" %>>無效關閉此職缺</option>
                    <option value="1" <%=(filter.IsActive == 1) ? "selected" : "" %>>有效</option>
                </select>
            </p>
            <p>
                職缺類別：
                <select name="HirName">
                    <option selected="selected">請選擇</option>
                    <%
                        foreach (var item in categoary)
                        {
                            Response.Write(string.Format("<option>{0}</option>", item.CategoryName));
                        }
                    %>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="JobTitle" type="text" value="請輸入職缺科別或職缺名稱搜尋" onclick="this.value = '';"
                    size="30" id="JobTitle" onkeydown="if(event.keyCode==13){this.form.submit();}" />
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
                    <input type="button" class="submit3 <%=CanNotEdit %>" onclick="window.location = '/Page7/EditHirDetail/';"
                        value="新增資料">
                    <input type="button" class="submit3 <%=VeriferClass %>" onclick="$('#IsActive').val(0);$('#CurrentPage').val(1);this.form.submit();"
                        value="待審核">
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
                    職缺類別
                </td>
                <td>
                    職缺科別
                </td>
                <td>
                    職缺名稱
                </td>
                <td class="w60">
                    職缺數量
                </td>
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
                    <input type="checkbox" name="id" value="<%=item.HirDetailId %>" />
                </td>
                <td class="txt_c">
                    <%=item.PublishDate.ToString("yyyy/MM/dd") %>
                </td>
                <td class="txt_c">
                    <%=item.HirName%>
                </td>
                <td class="txt_c">
                    <%=item.CostName %>
                </td>
                <td>
                    <%=item.JobTitle %>
                </td>
                <td class="txt_c">
                    <%=item.Nums %>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit <%= CanNotEdit%>" onclick="window.location='/Page7/EditHirDetail/<%=item.HirDetailId %>';"
                        value="編輯">
                    <input name="bt_edit" type="button" class="submit4 <%=VeriferClass %> <%=(item.IsActive == 1) ? " hide " : "" %>" onclick="window.location='/Page7/EditHirDetail/<%=item.HirDetailId %>?Verify=1';"
                        value="審核">
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
        2. 流水號（由大至小）
        <br />
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
