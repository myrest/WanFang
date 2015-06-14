<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.DiaryData_Info Model = ViewData["Model"] as WanFang.Domain.DiaryData_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.DiaryData_Info();
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

            utility.service("Page2Service/SaveDiaryData", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page2', 'DiaryData') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="DiaryDataID" value="<%=Model.DiaryDataID %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">最新消息項目管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp最新消息管理&nbsp&#187&nbsp最新消息項目管理
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">類別名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="DiaryType">
                            <option <%=(Model.DiaryType == "訊息公告")?"selected":"" %>>訊息公告</option>
                            <option <%=(Model.DiaryType == "新聞稿")?"selected":"" %>>新聞稿</option>
                            <option <%=(Model.DiaryType == "人資公告")?"selected":"" %>>人資公告</option>
                        </select></td>
                    <!--新聞類型-->
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">類別代碼</td>
                    <td class="txt_l">
                        <input name="DiaryTypeCode" type="text" size="5" value="<%=Model.DiaryTypeCode %>" ></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">發布日期<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="PublishDate" type="text" size="10" value="<%=(Model.PublishDate == DateTime.MinValue) ? "" : Model.PublishDate.ToString("yyyy/MM/dd")%>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">發布主題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="Subject" size="50" maxlength="255" value="<%=Model.Subject %>" >
                        （例：103年度老人體檢開跑!!）</td>
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
                <tr class="line-d">
                    <td class="line-d0 w150 top">圖片上傳</td>
                    <td class="txt_l">
                        <table border="0" cellspacing="0" cellpadding="2" class="ww100">
                            <tr class="no_line">
                                <td class="line-d w50 top">圖1：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image1, "DiaryDataImage1")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖2：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image2, "DiaryDataImage2")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖3：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image3, "DiaryDataImage3")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖4：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image4, "DiaryDataImage4")%>
                                    </td>
                            </tr>
                        </table>
                        <span class="red">圖1~4　建議尺寸：寬800px，高535px</span>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">檔案上傳</td>
                    <td class="txt_l">
                        <%=UrlExtension.PreviewImage(Model.FileDocument, "DiaryDataFileDocument")%>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">影片上傳</td>
                    <td class="txt_l">http://www.youtube.com/v/
                        <input type="text" name="YoutubeLink" size="15" maxlength="255" value="<%=Model.YoutubeLink %>" ><!--新欄位-->（例：http://www.youtube.com/v/<span class="red">0Vnq0q1ecOE</span>）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">上傳說明</td>
                    <td>
                        <span class="red">&#187圖檔格式，只接受JPG,GIF,BMP,PNG的檔案（色彩模式為RGB〔網頁用〕，CMYK模式〔印刷用〕圖片會無法顯示），檔案大小限300KB以內。<br>
                        </span>
                        <span class="red">&#187;檔案格式，只接受JPG,GIF,BMP,PNG,PDF,DOC,DOCX,PPT,PPTX,XLS,XLSX,TXT,ZIP,RAR的檔案，檔案大小限3MB以內。<br>
                        </span>
                        <span class="red">&#187檔案名稱，請以英數字字元命名(不接受中文檔名及特殊字元)。</span>&nbsp;</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">是否放在頭條首頁</td>
                    <td class="txt_l">
                        <select name="IsShowInHeader">
                            <option value="1" <%=(Model.IsShowInHeader == 1)?"selected":"" %> >首頁</option>
                            <option value="0" <%=(Model.IsShowInHeader == 0)?"selected":"" %>>非首頁</option>
                        </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpdator %></td>
                </tr>
            </table>
        <div class="txt_c mag15" id="sendadd">
            <input type="button" class="submit" id="Submit" value="送出" onclick="Save();" />
        </div>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
