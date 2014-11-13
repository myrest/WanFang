<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.User_Info> Model = ViewData["Model"] as List<WanFang.Domain.User_Info>;
        WanFang.Domain.User_Filter filter = ViewData["Filter"] as WanFang.Domain.User_Filter;
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteUser", param, "POST", function (data) {
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
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    員工帳號管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp員工帳號管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                關鍵字：
                <input name="LoginId" type="text" value="請輸入帳號搜尋" onclick="this.value = '';" size="30"
                    id="LoginId" onkeydown="if(event.keyCode==13){this.form.submit();}" />
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
                    <input name="Add" id="Add" type="button" class="submit3" onclick="window.location = '/Manage/EditUser/';"
                        value="新增資料">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content txt_c h30">
                <td class="w20">
                    &nbsp;
                </td>
                <td>
                    管理者名稱
                </td>
                <td>
                    登入帳號
                </td>
                <td>
                    門診
                </td>
                <td>
                    科別
                </td>
                <td>
                    權限名稱
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
            <tr class="line-d top va_m mous01">
                <td class="va_m">
                    <input type="checkbox" name="id" value="<%=item.UserID %>" />
                </td>
                <td class="txt_c">
                    <%=item.UserName %>
                </td>
                <td class="txt_c">
                    <%=item.LoginId %>
                </td>
                <td class="txt_c">
                    <%=item.DeptName %>
                </td>
                <td class="txt_c">
                    <%=item.CostName %>
                </td>
                <td>
                    <%=item.Permission %>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/Manage/EditUser/<%=item.UserID %>';"
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
        2. 排序：帳號（由小至大）<br />
        <!--main end-->
    </div>
    <!--new 後臺員工帳號專區-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
