<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<WanFang.Domain.Question_Info> Model = ViewData["Model"] as List<WanFang.Domain.Question_Info>;
        WanFang.Domain.Question_Filter filter = ViewData["Filter"] as WanFang.Domain.Question_Filter;

        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
    %>
    <script>
        $(function () {
            $('#DeptName').change(ChangeDept);
        });

        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteQuestion", param, "POST", function (data) {
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
                    健康諮詢查詢管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp詢問台管理&nbsp&#187&nbsp健康諮詢查詢管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                類 別：
                <select name="Q_type">
                    <option>請選擇</option>
                    <option>營養諮詢</option>
                </select>
            </p>
            <p>
                門診類別：
                <select name="Dept" id="DeptName">
                    <option>請選擇</option>
                    <%
                        foreach (var item in Dept)
                        {
                            string selected = string.Empty;
                            Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                        }
                    %>
                </select>
                科別：
                <select name="CostName" id="CostName">
                    <option>請選擇</option>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="Q_question" type="text" value="請輸入提問標題搜尋" onclick="this.value = '';"
                    size="30" id="Q_question" onkeydown="if(event.keyCode==13){this.form.submit();}" />
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
                    <input type="button" class="submit3" onclick="window.location = '/Page10/EditQuestion/';"
                        value="新增資料">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content txt_c h30">
                <td class="w20">
                    &nbsp;
                </td>
                <td class="w60">
                    發佈日期
                </td>
                <td class="w60">
                    諮詢類別
                </td>
                <td class="w80">
                    科別
                </td>
                <td>
                    提問標題
                </td>
                <td class="w60">
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
            <tr class="mous01 top line-d va_m line-d va_m">
                <td>
                    <input type="checkbox" name="id" value="<%=item.QuestionId %>" />
                </td>
                <td class="txt_c">
                    <%=item.Q_time.ToString("yyyy/MM/dd") %>
                </td>
                <td class="txt_c">
                    <%=item.Q_type %>
                </td>
                <td class="txt_c">
                    <%=item.CostName %>
                </td>
                <td>
                    <%=item.Q_title %>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/Page10/EditQuestion/<%=item.QuestionId %>';"
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
        2. 流水號（由大至小）
        <br />
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
