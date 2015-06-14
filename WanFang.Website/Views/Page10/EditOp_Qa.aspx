<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.Op_Qa_Info Model = ViewData["Model"] as WanFang.Domain.Op_Qa_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Op_Qa_Info();
        }
        else
        {
            Model.op_content = Model.op_content ?? "";
            Model.op_content = Model.op_content.Replace("\n\r", "");
            Model.op_content = Model.op_content.Replace("\n", "");
            Model.op_content = Model.op_content.Replace("\r", "");
            Model.op_content = Model.op_content.Replace("'", "\\'");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&op_content" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page10Service/SaveOp_Qa", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page10', 'Op_Qa') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="Op_QaId" value="<%=Model.Op_QaId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">就醫問答集管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp詢問台管理&nbsp&#187&nbsp就醫問答集管理
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d va_m">
                    <td class="line-d0">類別名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="op_type">
                            <option <%=(Model.op_type == "掛號") ? "selected" : "" %>>掛號</option>
                            <option <%=(Model.op_type == "門診") ? "selected" : "" %>>門診</option>
                            <option <%=(Model.op_type == "住院") ? "selected" : "" %>>住院</option>
                            <option <%=(Model.op_type == "檢查") ? "selected" : "" %>>檢查</option>
                            <option <%=(Model.op_type == "收費") ? "selected" : "" %>>收費</option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">問題標題<span class="red">*</span></td>
                    <td class="line-d txt_l">
                        <input name="op_title" type="text" value="<%=Model.op_title %>" size="50">
                        （例：第一次就診是否也可以電話預約？） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">清單頁簡述</td>
                    <td>
                        <textarea name="Description" cols="60" rows="3"><%=Model.Description %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">回覆內容<span class="red">*</span></td>
                    <td>
                        <div style="clear: both; padding: 3px 0px 3px 0px;" class="red">斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                        <br />
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '450';
                            oFCKeditor.Value = '<%=Model.op_content %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d top">
                    <td class="line-d0">上/下架</td>
                    <td class="txt_l">
                        <% =UrlExtension.GenerIsActive(Model.IsActive, true)%>

                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpdator %></td>
                </tr>
            <tr class="line-d">
                <td class="line-d0 top">最後審核日</td>
                <td><%=(Model.VerifiedDate != null && Model.VerifiedDate != DateTime.MinValue) ? Model.VerifiedDate.ToString() : "" %></td>
            </tr>
            </table>
        <div class="txt_c mag15" id="sendadd">
        <%
            if (EditForVerifier)
            {
                Response.Write("<input type=\"hidden\" name=\"IsActive\" value=\"1\" />");
                Response.Write("<input type=\"button\" class=\"submit submit3\" id=\"Submit\" value=\"通過審核\" onclick=\"Save();\" />");
            }
            else
            {
                Response.Write("<input type=\"button\" class=\"submit\" id=\"Submit\" value=\"送出\" onclick=\"Save();\" />");
            }
        %>
        </div>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
