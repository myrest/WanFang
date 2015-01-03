<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.AboutTeam_Info Model = ViewData["Model"] as WanFang.Domain.AboutTeam_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.AboutTeam_Info();
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
            var param = $('#form1 :not([name^=ContentBody])').serialize();
            var inst = FCKeditorAPI.GetInstance("ContentBody");
            param += "&ContentBody=" + encodeURIComponent(inst.GetHTML());

            utility.service("AboutService/SaveAboutTeam", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('About', 'Team') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="AboutTeamId" value="<%=Model.AboutTeamId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">管理團隊管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_c">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp關於萬芳管理&nbsp&#187&nbsp管理團隊管理
        </div>
        <p class="clear"></p>
    </div>
    <div id="mainpage">
            <table class="ww100" cellspacing="1" cellpadding="2" border="0">
                <tr class="line-d top">
                    <td class="line-d0 w150">順序<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="SortNum" value="<%=Model.SortNum%>" size="2" maxlength="2" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" />
                        <span class="red">僅排序用，例：01　<span class="orange">可以填0</span>，可以重複</span></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">職稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="StrName" size="50" maxlength="255" value="<%=Model.StrName%>"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">姓名<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="UserName" size="50" maxlength="255" value="<%=Model.UserName%>" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">簡介</td>
                    <td class="txt_l">
                        <input type="text" name="Introduction" size="100" maxlength="255"  value="<%=Model.Introduction %>"/></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">簡述<span class="red">*</span></td>
                    <td>
                        <textarea name="Description"  style="width: 100%" rows="4" cols="20"><%=Model.Description %></textarea>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">內容</td>
                    <td class="txt_l">
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('ContentBody');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '200';
                            oFCKeditor.Value = '<%=Model.ContentBody%>';
                            oFCKeditor.Create();
                        </script>

                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">圖片上傳</td>
                    <td class="txt_l">
                        <table class="ww100" border="0" cellspacing="0" cellpadding="2">
                            <tr class="no_line">
                                <td class="w50">清單圖：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Photo1, "TeamPhoto1", !EditForVerifier)%>
                                    <span class="red">建議尺寸：寬120px，高145px</span></td>
                            </tr>
                            <tr class="no_line">
                                <td>內容圖：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Photo2, "TeamPhoto2", !EditForVerifier)%>
                                    <span class="red">建議尺寸：寬230px，高346px</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">上傳說明</td>
                    <td><span class="red">&#187圖檔格式，只接受JPG,GIF,BMP,PNG的檔案（色彩模式為RGB〔網頁用〕，CMYK模式〔印刷用〕圖片會無法顯示），檔案大小限300KB以內。<br>
                    </span><span class="red">&#187檔案名稱，請以英數字字元命名(不接受中文檔名及特殊字元)。</span></td>
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
