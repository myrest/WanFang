<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.Guide_Info Model = ViewData["Model"] as WanFang.Domain.Guide_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Guide_Info();
        }
        else
        {
            Model.ContentBody1 = Model.ContentBody1 ?? "";
            Model.ContentBody2 = Model.ContentBody2 ?? "";
            Model.ContentBody3 = Model.ContentBody3 ?? "";
            Model.ContentBody1 = Model.ContentBody1.Replace("\n", "");
            Model.ContentBody1 = Model.ContentBody1.Replace("\r", "");
            Model.ContentBody2 = Model.ContentBody2.Replace("\n\r", "");
            Model.ContentBody2 = Model.ContentBody2.Replace("\n", "");
            Model.ContentBody2 = Model.ContentBody2.Replace("\r", "");
            Model.ContentBody3 = Model.ContentBody3.Replace("\n\r", "");
            Model.ContentBody3 = Model.ContentBody3.Replace("\n", "");
            Model.ContentBody3 = Model.ContentBody3.Replace("\r", "");
            Model.ContentBody1 = Model.ContentBody1.Replace("'", "\\'");
            Model.ContentBody2 = Model.ContentBody2.Replace("'", "\\'");
            Model.ContentBody3 = Model.ContentBody3.Replace("'", "\\'");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&ContentBody1" + "=" + encodeURIComponent(inst.GetHTML());
            inst = FCKeditorAPI.GetInstance("Content2");
            param += "&ContentBody2" + "=" + encodeURIComponent(inst.GetHTML());
            inst = FCKeditorAPI.GetInstance("Content2");
            param += "&ContentBody3" + "=" + encodeURIComponent(inst.GetHTML());
            utility.service("Page4Service/SaveGuide", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page4', 'Guide') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="GuideId" value="<%=Model.GuideId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    就醫指南管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp就醫指南項目管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <table cellspacing="1" cellpadding="2" class="ww100" border="0">
            <tr class="line-d">
                <td class="line-d0 va_m w100">
                    項目名稱<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input name="ItemName" type="text" value="<%=Model.ItemName %>" size="70">
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m w100">
                    排序<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input name="SortNum" type="text" value="<%=Model.SortNum %>" size="70">
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">
                    顯示方式<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <span class="red" style="clear: both; padding: 0 0 10px 0;">「連結/內容」為前端頁面按下「單元名稱」後的顯示方式（單選）。</span>
                    <table class="ww100" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td nowrap="nowrap" class="line-d w60 top">
                                <input name="DisplayType" type="radio" value="0" <%=(Model.DisplayType == 0) ? "checked" : ""%> />
                                連結：
                            </td>
                            <td class="line-d top">
                                <input name="Link" type="text" value="<%=Model.Link %>" size="100" maxlength="255" />
                                <br />
                                （例：about.asp 或 img/1.jpg 或 http://www.xxx.com.tw/）
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                <input name="DisplayType" type="radio" value="1" <%=(Model.DisplayType == 1) ? "checked" : ""%> />
                                內容：
                            </td>
                            <td>
                                <div class="red cp">
                                    斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                                內容1：<br />
                                <script type="text/javascript">
                                    var oFCKeditor = new FCKeditor('Content1');
                                    oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                    oFCKeditor.Width = '100%';
                                    oFCKeditor.Height = '250';
                                    oFCKeditor.Value = '<%=Model.ContentBody1 %>';
                                    oFCKeditor.Create();
                                </script>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td>
                                圖1：
                                <%=UrlExtension.PreviewImage(Model.Image1, "GuideImage1", !EditForVerifier)%>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                <input type="radio" name="Position1" value="0" <%=(Model.Position1 == 0) ? "checked" : "" %> />圖片置於「左側」
                                <input type="radio" name="Position1" value="1" <%=(Model.Position1 == 1) ? "checked" : "" %> />圖片置於「右側」
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                內容2：<br />
                                <script type="text/javascript">
                                    var oFCKeditor = new FCKeditor('Content2');
                                    oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                    oFCKeditor.Width = '100%';
                                    oFCKeditor.Height = '250';
                                    oFCKeditor.Value = '<%=Model.ContentBody2 %>';
                                    oFCKeditor.Create();
                                </script>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                圖2：
                                <%=UrlExtension.PreviewImage(Model.Image2, "GuideImage2", !EditForVerifier)%>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                <input type="radio" name="Position2" value="0" <%=(Model.Position2 == 0) ? "checked" : "" %> />圖片置於「左側」
                                <input type="radio" name="Position2" value="1" <%=(Model.Position2 == 1) ? "checked" : "" %> />圖片置於「右側」
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                內容3：<br />
                                <script type="text/javascript">
                                    var oFCKeditor = new FCKeditor('Content3');
                                    oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                    oFCKeditor.Width = '100%';
                                    oFCKeditor.Height = '250';
                                    oFCKeditor.Value = '<%=Model.ContentBody3 %>';
                                    oFCKeditor.Create();
                                </script>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                圖3：
                                <%=UrlExtension.PreviewImage(Model.Image3, "GuideImage3", !EditForVerifier)%>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                <input type="radio" name="Position3" value="0" <%=(Model.Position3 == 0) ? "checked" : "" %> />圖片置於「左側」
                                <input type="radio" name="Position3" value="1" <%=(Model.Position3 == 1) ? "checked" : "" %> />圖片置於「右側」
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td class="top">
                                &nbsp;
                            </td>
                            <td>
                                <div class="red" style="clear: both; padding-top: 10px;">
                                    圖1~3 建議尺寸：寬350px，高230px</div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">
                    上傳說明
                </td>
                <td>
                    <span class="red">&#187圖檔格式，只接受JPG,GIF,BMP,PNG的檔案（色彩模式為RGB〔網頁用〕，CMYK模式〔印刷用〕圖片會無法顯示），檔案大小限300KB以內。<br>
                    </span><span class="red">&#187檔案名稱，請以英數字字元命名(不接受中文檔名及特殊字元)。</span>&nbsp;
                </td>
            </tr>
            <tr class="line-d top">
                <td class="line-d0">
                    上/下架
                </td>
                <td class="txt_l">
                    <% =UrlExtension.GenerIsActive(Model.IsActive, true)%>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">
                    更新日期
                </td>
                <td>
                    <%=Model.LastUpdate %>--<%=Model.LastUpdator %>
                </td>
            <tr class="line-d">
                <td class="line-d0 top">最後審核日</td>
                <td><%=(Model.VerifiedDate != null && Model.VerifiedDate != DateTime.MinValue) ? Model.VerifiedDate.ToString() : "" %></td>
            </tr>
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
