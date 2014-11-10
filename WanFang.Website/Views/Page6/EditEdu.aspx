<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script language="JavaScript" src="/CDN/Plugins/Manage/calendar.js"></script>
<script language="JavaScript" src="/CDN/Plugins/Manage/calendar-setup.js"></script>
<script language="JavaScript" src="/CDN/Plugins/Manage/lang/calendar-big5-utf8.js"></script>
    <%
        WanFang.Domain.Edu_Info Model = ViewData["Model"] as WanFang.Domain.Edu_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Edu_Info();
        }
        //var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();

            utility.service("Page6Service/SaveEdu", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page6', 'Edu') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="EduId" value="<%=Model.EduId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    健康促進衛教活動管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;特色醫療管理&nbsp&#187&nbsp;健康促進衛教活動管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">衛教類別<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="EduType">
                            <option value="營養保健" <%=(Model.EduType == "營養保健")?"selected" : "" %>>營養保健</option>
                            <option value="門診團衛" <%=(Model.EduType == "門診團衛")?"selected" : "" %>>門診團衛</option>
                            <option value="親子教室" <%=(Model.EduType == "親子教室")?"selected" : "" %>>親子教室</option>
                            <option value="體重控制" <%=(Model.EduType == "體重控制")?"selected" : "" %>>體重控制</option>
                            <option value="糖尿病保健" <%=(Model.EduType == "糖尿病保健")?"selected" : "" %>>糖尿病保健</option>
                            <option value="產前夫婦保健" <%=(Model.EduType == "產前夫婦保健")?"selected" : "" %>>產前夫婦保健</option>
                            <option value="腎臟保健講座" <%=(Model.EduType == "腎臟保健講座")?"selected" : "" %>>腎臟保健講座</option>
                            <option value="母乳支持團體" <%=(Model.EduType == "母乳支持團體")?"selected" : "" %>>母乳支持團體</option>
                            <option value="中醫衛教" <%=(Model.EduType == "中醫衛教")?"selected" : "" %>>中醫衛教</option>
                            <option value="藥品團衛" <%=(Model.EduType == "藥品團衛")?"selected" : "" %>>藥品團衛</option>
                            <option value="社區衛教" <%=(Model.EduType == "社區衛教")?"selected" : "" %>>社區衛教</option>
                            <option value="專題講座" <%=(Model.EduType == "專題講座")?"selected" : "" %>>專題講座</option>
                        </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">衛教標題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="Title" type="text" value="<%=Model.Title %>" size="50"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">衛教主講者<span class="red">*</span></td>
                    <td>
                        <input name="Teacher" type="text" value="<%=Model.Teacher %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">衛教地點<span class="red">*</span></td>
                    <td>
                        <input name="Place" type="text" value="<%=Model.Place %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">衛教日期<span class="red">*</span></td>
                    <td>
                        <input name="EduDate" type="text" size="10" value="<%=(Model.EduDate == DateTime.MinValue)?DateTime.Now.ToString("yyyy/MM/dd"):Model.EduDate.ToString("yyyy/MM/dd") %>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">衛教起始時間<span class="red">*</span></td>
                    <td>
                        <input name="DateStart" type="text" value="<%=Model.DateStart %>" size="10" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">衛教結束時間<span class="red">*</span></td>
                    <td>
                        <input name="DateEnd" type="text" value="<%=Model.DateEnd %>" size="10" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">備註</td>
                    <td>
                        <textarea name="Notes" cols="60" rows="6"><%=Model.Notes %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpdator %></td>
                </tr>
            </table>        <div class="txt_c mag15" id="sendadd">
            <input type="button" class="submit" id="Submit" value="送出" onclick="Save();" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
