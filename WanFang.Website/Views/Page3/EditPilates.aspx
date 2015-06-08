<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.Pilates_Info Model = ViewData["Model"] as WanFang.Domain.Pilates_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Pilates_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
            Model.ContentBody = Model.ContentBody.Replace("\n\r", "");
            Model.ContentBody = Model.ContentBody.Replace("\n", "");
            Model.ContentBody = Model.ContentBody.Replace("\r", "");
            Model.ContentBody = Model.ContentBody.Replace("'", "\\'");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page3Service/SavePilates", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page3', 'Pilates') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="PilatesId" value="<%=Model.PilatesId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">其他課程管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp其他課程管理
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">課程代號<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="RegID">
                            <option <%=(Model.RegID == "Pilates核心復健" ? "selected" : "") %>>Pilates核心復健</option>
                            <option <%=(Model.RegID == "孕婦健康瑜珈班" ? "selected" : "") %>>孕婦健康瑜珈班</option>
                            <option <%=(Model.RegID == "肩頸上背疼痛復健班" ? "selected" : "") %>>肩頸上背疼痛復健班</option>
                            <option <%=(Model.RegID == "兒童背部運動及姿態矯正班" ? "selected" : "") %>>兒童背部運動及姿態矯正班</option>
                            <option <%=(Model.RegID == "有氧太P力" ? "selected" : "") %>>有氧太P力</option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">課程名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="RegName" type="text" size="50" value="<%=Model.RegName %>" >
                        （例：Pilates核心復健） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">課程主題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="RegSubject" type="text" value="<%=Model.RegSubject %>" size="50">
                        （例：下背痛核心復健(基礎夜)） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">開課日期<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="PublishDate" type="text" value="<%=(Model.PublishDate == DateTime.MinValue)? "" : Model.PublishDate.ToString("yyyy/MM/dd") %>" size="20">
                        （例：2013/08/29） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">上課開始時間<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="TimeStart" type="text" value="<%=Model.TimeStart %>" size="20">
                        （例：19:00） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">上課結束時間<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="TimeEnd" type="text" value="<%=Model.TimeEnd %>" size="20">
                        （例：20:00） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">備註</td>
                    <td>
                        <textarea name="Memo" cols="60" rows="3"><%=Model.Memo %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 top">發布內容 </td>
                    <td class="txt_l">
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '450';
                            oFCKeditor.Value = '<%=Model.ContentBody %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d top">
                    <td class="line-d0 va_m">狀態</td>
                    <td class="txt_l va_m">
                        <input type="checkbox" value="1" name="HasTail" <%=(Model.HasTail == 1)?"checked":"" %> /> 是否顯示問卷</td>
                </tr>
                <tr class="line-d">
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
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
