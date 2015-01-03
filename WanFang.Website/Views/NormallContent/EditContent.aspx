<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.NormallContent_Info Model = ViewData["Model"] as WanFang.Domain.NormallContent_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.NormallContent_Info();
        }
        else
        {
            Model.Content1 = Model.Content1 ?? "";
            Model.Content2 = Model.Content2 ?? "";
            Model.Content3 = Model.Content3 ?? "";
            Model.Content1 = Model.Content1.Replace("\n\r", "");
            Model.Content1 = Model.Content1.Replace("\n", "");
            Model.Content1 = Model.Content1.Replace("\r", "");
            Model.Content2 = Model.Content2.Replace("\n\r", "");
            Model.Content2 = Model.Content2.Replace("\n", "");
            Model.Content2 = Model.Content2.Replace("\r", "");
            Model.Content3 = Model.Content3.Replace("\n\r", "");
            Model.Content3 = Model.Content3.Replace("\n", "");
            Model.Content3 = Model.Content3.Replace("\r", "");
            Model.Content1 = Model.Content1.Replace("'", "\\'");
            Model.Content2 = Model.Content2.Replace("'", "\\'");
            Model.Content3 = Model.Content3.Replace("'", "\\'");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            for (var i = 0; i < 3; i++) {
                var inst = FCKeditorAPI.GetInstance("Content" + (i + 1));
                param += "&Content" + (i + 1) + "=" + encodeURIComponent(inst.GetHTML());
            }
            param += "&ContentName=" + '<%=ViewData["Header1"].ToString() %>';

            utility.service("NormallContentService/SaveNormallContent", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('NormallContent', '<%=ViewData["GoBack"].ToString() %>') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="NormallContentId" value="<%=Model.NormallContentId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r"><%=ViewData["Header1"].ToString()%></div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp<%=ViewData["Header2"].ToString()%>&nbsp&#187&nbsp<%=ViewData["Header1"].ToString()%>
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">單元名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="UnitName" size="50" maxlength="255" value="<%=Model.UnitName%>">
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">顯示方式</td>
                    <td class="txt_l"><span class="red" style="clear: both; padding: 0 0 10px 0;">「連結/內容」為前端頁面按下「單元名稱」後的顯示方式（單選）。</span>
                        <table class="ww100" border="0" cellspacing="0" cellpadding="2">
                            <tr class="no_line">
                                <td nowrap="nowrap" class="line-d w60 top">
                                    <input name="OpenType" type="radio" value="0" <%=(Model.OpenType == 0) ? "checked" : ""  %> />
                                    連結：</td>
                                <td class="line-d top">
                                    <input name="OpenUrl" type="text" value="<%=Model.OpenUrl %>" size="100" maxlength="255" />
                                    <br />
                                    （例：about.asp 或 img/1.jpg 或 http://www.xxx.com.tw/）<br />
                                    <input name="UrlTarget" type="radio" value="0" <%=Model.UrlTarget == 0 ? "checked" : "" %> />開啟於原頁面
                                    <input name="UrlTarget" type="radio" value="1" <%=Model.UrlTarget == 1 ? "checked" : "" %> />開啟於新視窗
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">
                                    <input name="OpenType" type="radio" value="1" <%=(Model.OpenType == 1) ? "checked" : ""  %> />
                                    內容：</td>
                                <td>
                                    <div class="red cp">斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                                    內容1：<br />
                                    <script type="text/javascript">
                                        var oFCKeditor = new FCKeditor('Content1');
                                        oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                        oFCKeditor.Width = '100%';
                                        oFCKeditor.Height = '200';
                                        oFCKeditor.Value = '<%=Model.Content1 %>';
                                        oFCKeditor.Create();
                                    </script>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td valign="top">&nbsp;</td>
                                <td>圖1：
                                    <%=UrlExtension.PreviewImage(Model.Image1, "NormallContentImage1", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td class="line-d">
<input type="radio" name="Position1" value="0" <%=Model.Position1 == 0 ? "checked" : "" %> />圖片置於「左側」
<input type="radio" name="Position1" value="1" <%=Model.Position1 == 1 ? "checked" : "" %> />圖片置於「右側」
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>內容2：<br />
                                    <script type="text/javascript">
                                        var oFCKeditor = new FCKeditor('Content2');
                                        oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                        oFCKeditor.Width = '100%';
                                        oFCKeditor.Height = '200';
                                        oFCKeditor.Value = '<%=Model.Content2 %>';
                                        oFCKeditor.Create();
                                    </script>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>圖2：
                                    <%=UrlExtension.PreviewImage(Model.Image2, "NormallContentImage2", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td class="line-d">
<input type="radio" name="Position2" value="0" <%=Model.Position2 == 0 ? "checked" : "" %> />圖片置於「左側」
<input type="radio" name="Position2" value="1" <%=Model.Position2 == 1 ? "checked" : "" %> />圖片置於「右側」
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>內容3：<br />
                                    <script type="text/javascript">
                                        var oFCKeditor = new FCKeditor('Content3');
                                        oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                                        oFCKeditor.Width = '100%';
                                        oFCKeditor.Height = '200';
                                        oFCKeditor.Value = '<%=Model.Content3 %>';
                                        oFCKeditor.Create();
                                    </script>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>圖3：
                                    <%=UrlExtension.PreviewImage(Model.Image3, "NormallContentImage3", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>
<input type="radio" name="Position3" value="0" <%=Model.Position3 == 0 ? "checked" : "" %> />圖片置於「左側」
<input type="radio" name="Position3" value="1" <%=Model.Position3 == 1 ? "checked" : "" %> />圖片置於「右側」
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top">&nbsp;</td>
                                <td>
                                    <div class="red" style="clear: both; padding-top: 10px;">圖1~3　建議尺寸：寬350px，高230px</div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">上傳說明</td>
                    <td><span class="red">&#187圖檔格式，只接受JPG,GIF,BMP,PNG的檔案（色彩模式為RGB〔網頁用〕，CMYK模式〔印刷用〕圖片會無法顯示），檔案大小限300KB以內。<br>
                    </span><span class="red">&#187檔案名稱，請以英數字字元命名(不接受中文檔名及特殊字元)。</span>&nbsp;</td>
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
