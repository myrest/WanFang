﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool IsVerifer = (bool)ViewData["Verify"];
        string VeriferClass = IsVerifer ? "" : " hide ";
        string CanNotEdit = IsVerifer ? " hide " : "";

        List<WanFang.Domain.CostKeyword_Info> Model = ViewData["Model"] as List<WanFang.Domain.CostKeyword_Info>;
        WanFang.Domain.CostKeyword_Filter filter = ViewData["Filter"] as WanFang.Domain.CostKeyword_Filter;
        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
        if (Model == null) Model = new List<WanFang.Domain.CostKeyword_Info>();
        List<WanFang.Domain.Webservice.CostDetailInformation> Costs = null;
        //if filter's DeptName != null, need list down the cost
        if (!string.IsNullOrEmpty(filter.DeptName))
        {
            var DirDeptCode = Dept.Where(x => x.Value.Trim() == filter.DeptName).FirstOrDefault();
            if (!string.IsNullOrEmpty(DirDeptCode.Key))
            {
                WanFang.Domain.Constancy.WS_Dept_type depttype =
                    Rest.Core.Utility.EnumHelper.GetEnumByName<WanFang.Domain.Constancy.WS_Dept_type>(DirDeptCode.Key);
                Costs = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(depttype);
            }
        }

    %>
    <script>
        $(function () {
            $('#Dept').change(ChangeDept);
        });

        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteCostKeyword", param, "POST", function (data) {
                    if (data.code > 0) {
                        document.location.reload(true);
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            });
        }

        function ChangeDept() {
            $this = $(this);
            var CostName = $this.val();
            var param = { CostCode: CostName };
            utility.service("ManageService/GetDeptInfo", param, "POST", function (data) {
                if (data.code > 0) {
                    $('#CostName').html('');
                    $("#CostName").append($("<option></option>").attr("value", "").text("請選擇"));
                    if (data.list != undefined) {
                        $.each(data.list, function (index, ele) {
                            $("#CostName").append($("<option></option>").attr("value", ele.CostName).text(ele.CostName));
                        });
                    }
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
                    科別關鍵字管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp團隊介紹管理&nbsp&#187&nbsp科別關鍵字管理
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
            <p class="<%=VeriferClass %>">
                門診類別：
                <select name="DeptName" id="DeptName">
                    <option>請選擇</option>
                    <%
                        foreach (var item in Dept)
                        {
                            string selected = string.Empty;
                            if (item.Value.Trim() == filter.DeptName) selected = " selected ";
                            Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                        }
                    %>
                </select>
                科別：
                <select name="CostName" id="CostName">
                    <option>請選擇</option>
                    <%
                        if (Costs != null)
                        {
                            Costs.ForEach(x =>
                            {
                                string selected = "";
                                if (!string.IsNullOrEmpty(filter.CostName) && x.CostName.Trim() == filter.CostName.Trim())
                                {
                                    selected = " selected ";
                                }
                                Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", x.CostName, selected, x.CostName));
                            });
                        }
                    %>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="KeyWord" type="text" value="請輸入關鍵字搜尋" onclick="this.value = '';" size="30"
                    id="KeyWord" onkeydown="if(event.keyCode==13){this.form.submit();}" />
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
                    <input type="button" class="submit3 <%=CanNotEdit %>" onclick="window.location = '/Page9/EditCostKeyword/';"
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
                <td>
                    門診類別
                </td>
                <td>
                    科別
                </td>
                <td class="w60">
                    上/下架
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
                    <input type="checkbox" name="id" value="<%=item.CostKeywordId %>" />
                </td>
                <td class="txt_c">
                    <%=item.DeptName %>
                </td>
                <td class="txt_c">
                    <%=item.CostName %>
                </td>
                <td class="txt_c">
                    <%=(item.IsActive > 0) ? "上架" : "下架"%>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit <%= CanNotEdit%>" onclick="window.location='/Page9/EditCostKeyword/<%=item.CostKeywordId %>';"
                        value="編輯">
                    <input name="bt_edit" type="button" class="submit4 <%=VeriferClass %> <%=(item.IsActive == 1) ? " hide " : "" %>" onclick="window.location='/Page9/EditCostKeyword/<%=item.CostKeywordId %>?Verify=1';"
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
        2. 排序：流水號（由大至小）
        <br />
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
