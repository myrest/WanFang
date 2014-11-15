<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.CostNews_Info Model = ViewData["Model"] as WanFang.Domain.CostNews_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.CostNews_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
            Model.ContentBody = Model.ContentBody.Replace("\n\r", "");
            Model.ContentBody = Model.ContentBody.Replace("\n", "");
            Model.ContentBody = Model.ContentBody.Replace("\r", "");
        }
        WS_Dept_type WSDept = (WS_Dept_type)ViewData["Dept"];
        string DeptName = ViewData["DeptName"].ToString();
        var AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(WSDept);
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page9Service/SaveNews", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page9', 'News') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="CostNewsId" value="<%=Model.CostNewsId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    最新消息管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;特色醫療管理&nbsp&#187&nbsp;最新消息管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m w150">門診類別</td>
                    <td class="txt_l"><%=DeptName %>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">科別</td>
                    <td class="txt_l">
                        <select name="CostName" id="CostName">
                            <%
                                WanFang.BLL.WebService_Manage service = new WanFang.BLL.WebService_Manage();
                                var cost = service.GetAllDetailCostcerter(WSDept);
                                foreach (var item in cost)
                                {
                                    string selected = string.Empty;
                                    if (Model.CostName != null && item.CostName.Trim() == Model.CostName.Trim())
                                    {
                                        selected = "selected";
                                    }
                                    Response.Write(string.Format("<option value=\"{0}\" {1} >{0}</option>", item.CostName, selected));
                                }
                            %>
                        </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">發布日期<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="PublishDate" type="text" id="PublishDate" size="10" value="<%=(Model.PublishDate == DateTime.MinValue)?DateTime.Now.ToString("yyyy/MM/dd"):Model.PublishDate.ToString("yyyy/MM/dd") %>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">發布主題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input type="text" name="Subject" size="50" maxlength="255" value="<%=Model.Subject %>">
                        （例：103年度老人體檢開跑!!）</td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 top">發布內容 </td>
                    <td class="txt_l">
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '200';
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
                                    <input type="file" id="CostNewsImage1" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image1, "CostNewsImage1")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖2：</td>
                                <td>
                                    <input type="file" id="CostNewsImage2" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image2, "CostNewsImage2")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖3：</td>
                                <td>
                                    <input type="file" id="CostNewsImage3" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image3, "CostNewsImage3")%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖4：</td>
                                <td>
                                    <input type="file" id="CostNewsImage4" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image4, "CostNewsImage4")%>
                                    </td>
                            </tr>
                        </table>
                        <span class="red">圖1~4　建議尺寸：寬800px，高535px</span>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">檔案上傳</td>
                    <td class="txt_l">
                        <input type="file" id="CostNewsUploadFile" size="30"/>
                        <%=UrlExtension.PreviewImage(Model.UploadFile, "DownLoadUploadFile")%>
                    </td>
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
