<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.Nhi_Qa_Info Model = ViewData["Model"] as WanFang.Domain.Nhi_Qa_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Nhi_Qa_Info();
        }
        else
        {
            Model.nhi_con = Model.nhi_con ?? "";
            Model.nhi_con = Model.nhi_con.Replace("\n\r", "");
            Model.nhi_con = Model.nhi_con.Replace("\n", "");
            Model.nhi_con = Model.nhi_con.Replace("\r", "");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&nhi_con" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page10Service/SaveNhi_Qa", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page10', 'Nhi_Qa') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="Nhi_QaId" value="<%=Model.Nhi_QaId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">健保部分給付問答集管理</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp詢問台管理&nbsp&#187&nbsp健保部分給付問答集管理        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m w150">問題標題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="nhi_title" type="text" value="<%=Model.nhi_title%>" size="50">
                        （例：全民健康保險部分給付塗藥血管支架注意事項） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">清單頁簡述</td>
                    <td>
                        <textarea name="Description" cols="60" rows="3"><%=Model.Description %></textarea></td>
                    <!-- 新增的-->
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">回覆內容<span class="red">*</span></td>
                    <td>斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。
                             <br />
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '200';
                            oFCKeditor.Value = '<%=Model.nhi_con %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">發佈日期</td>
                    <td>
                        <input name="nhi_date" type="text" size="10" value="<%=(Model.nhi_date == DateTime.MinValue) ? DateTime.Now.ToString("yyyy/MM/dd") : Model.nhi_date.ToString("yyyy/MM/dd")%>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpdator %></td>
                </tr>
            </table>        <div class="txt_c mag15" id="sendadd">
            <input type="button" class="submit" id="Submit" value="送出" onclick="Save();" />
        </div>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
