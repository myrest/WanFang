<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool IsVerifer = (bool)ViewData["Verify"];
        string VeriferClass = IsVerifer ? "" : " hide ";

        WanFang.BLL.CostUnit_Manager man = new WanFang.BLL.CostUnit_Manager();
        var data = man.GetByParameter(new WanFang.Domain.CostUnit_Filter() { }, null, null, "SortNum");
    
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteCostUnit", param, "POST", function (data) {
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
                    <img src="/CDN/Images/Manage/title-left.jpg" alt="" />
                </div>
                <div class="tt-r">
                    &nbsp;單元管理
                </div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle">
            <a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp特色醫療管理&nbsp&#187&nbsp單元管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                上下架：<%int? a = null; %>
                <%=WanFang.Core.MVC.Extensions.UrlExtension.GenerFilterIsActive(a) %>
            </p>
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
                <td class="w70 txt_r">
                    <input name="Add" id="Add" type="button" class="submit3" onclick="window.location = '/Page9/EditCostUnit/';"
                        value="新增資料">
                    <input type="button" class="submit3 <%=VeriferClass %>" onclick="$('#IsActive').val(0);this.form.submit();"
                        value="待審核">
                </td>
            </tr>
        </table>
        <p class="clear">
        </p>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content txt_c h30">
                <td class="w20">
                    &nbsp;
                </td>
                <td class="w40">
                    順序
                </td>
                <td>
                    門診類別
                </td>
                <td>
                    科別
                </td>
                <td>
                    單元名稱
                </td>
                <td class="w100">
                    上/下架
                </td>
                <td class="w100">
                    更新日期
                </td>
                <td class="w80">
                    編輯
                </td>
            </tr>
            <%
                foreach (var item in data)
                {
            %>
            <tr class="mous01 top line-d txt_c va_m">
                <td>
                    <input type="checkbox" name="id" value="<%=item.CostUnitId %>" />
                </td>
                <td>
                    <%=item.SortNum%>
                </td>
                <td class="txt_c">
                    <%
                    WS_Dept_type WSDept = EnumHelper.GetEnumByName<WS_Dept_type>(item.DeptName);
                    string DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(WSDept);
                    Response.Write(DeptName);
                    %>
                </td>
                <td class="txt_c">
                    <%=item.CostName%>
                </td>
                <td>
                    <%=item.UnitName%>
                </td>
                <td>
                    <%=(item.IsActive > 0) ? "上架" : "下架"%>
                </td>
                <td>
                    <%=item.LastUpdate%>
                </td>
                <td>
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/Page9/EditCostUnit/<%=item.CostUnitId %>';"
                        value="編輯">
                    <input name="bt_edit" type="button" class="submit4 <%=VeriferClass %>" onclick="window.location='/Page9/EditCostUnit/<%=item.CostUnitId %>?Verify=1';"
                        value="審核">
                </td>
            </tr>
            <%
                }    
            %>
            <tr class="mous01 top line-d txt_c va_m">
                <td class="line-d">
        </table>
        <br />
        <span class="red">[注意事項]</span><br />
        1. 不分頁<br />
        2. 順序(由小至大)
        <br />
        <span class="red">3. 單元名稱底下有對應資料時，該筆不允許刪除</span>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
