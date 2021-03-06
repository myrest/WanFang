﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.CostNews_Info Model = ViewData["Model"] as WanFang.Domain.CostNews_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.CostNews_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
        }
        WS_Dept_type WSDept = (WS_Dept_type)ViewData["Dept"];
        string DeptName = ViewData["DeptName"].ToString();
        if (!string.IsNullOrEmpty(Model.DeptName))
        {
            DeptName = Model.DeptName;
            var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
            var _tmp = Dept.Where(x => x.Value == Model.DeptName).FirstOrDefault();
            if (_tmp.Key != null)
            {
                WSDept = EnumHelper.GetEnumByName<WS_Dept_type>(_tmp.Key);
            }
        }
        
        var AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(WSDept);
    %>
    <script>
        function Preview() {
            var previewUrl = FrontEndUrl + '/p9_medical_news_detail.aspx?pv=1&cn=' + $('#pkId').val();
            $('#previewform').attr('action', previewUrl);
            $('#previewform').submit();
            $('#wordIsActive').text('下架');
        }
        function Save(SaveType) {
            if (SaveType == 1) {
                Preview();
            } else {
                var param = $('#form1 :not([name^=Content])').serialize();
                var i = '1';
                var editorContent = Contents[i].getData();
                param += "&ContentBody=" + encodeURIComponent(editorContent);

                utility.service("Page9Service/SaveNews", param, "POST", function (data) {
                    if (data.code > 0) {
                        $('#pkId').val(data.msg);
                        if (SaveType == 0) {
                            utility.showPopUp("資料已儲存", 1, GoBack);
                        } else {
                            Preview();
                        }
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            }
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page9', 'News') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="CostNewsId" id="pkId" value="<%=Model.CostNewsId %>" />
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
                    <%
                        string CostName = (string.IsNullOrEmpty(Model.CostName)) ? ViewData["CostName"].ToString() : Model.CostName;
                    %>
                    <input type="hidden" name="CostName" value="<%=CostName %>" /><%=CostName %>
                        <!-- select name="CostName" id="CostName">
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
                                    if (!string.IsNullOrEmpty(Model.CostId) && item.CostCode.Trim() == Model.CostId)
                                    {
                                        selected = "selected";
                                    }
                                    
                                    Response.Write(string.Format("<option value=\"{0}\" {1} >{0}</option>", item.CostName, selected));
                                }
                            %>
                        </!-->
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
                        <textarea id="ContentBody" name="ContentBody"><%=Model.ContentBody %></textarea>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 top">圖片上傳</td>
                    <td class="txt_l">
                        <table border="0" cellspacing="0" cellpadding="2" class="ww100">
                            <tr class="no_line">
                                <td class="line-d w50 top">圖1：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image1, "CostNewsImage1", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖2：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image2, "CostNewsImage2", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖3：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image3, "CostNewsImage3", !EditForVerifier)%>
                                    </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖4：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image4, "CostNewsImage4", !EditForVerifier)%>
                                    </td>
                            </tr>
                        </table>
                        <span class="red">圖1~4　建議尺寸：寬800px，高535px</span>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">檔案上傳</td>
                    <td class="txt_l">
                        <%=UrlExtension.PreviewImage(Model.UploadFile, "CostNewsUploadFile", !EditForVerifier)%>
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
                <tr class="line-d top">
                    <td class="line-d0">
                        上/下架
                    </td>
                    <td class="txt_l" id="wordIsActive">
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
                Response.Write("<input type=\"button\" class=\"submit submit3\" id=\"Submit\" value=\"通過審核\" onclick=\"Save(0);\" />");
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" class=\"submit\" id=\"Preview\" value=\"預覽\" onclick=\"Save(1);\" />");
            }
            else
            {
                Response.Write("<input type=\"button\" class=\"submit\" id=\"Submit\" value=\"送出\" onclick=\"Save(0);\" />");
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"button\" class=\"submit\" id=\"Preview\" value=\"儲存並預覽\" onclick=\"Save(2);\" />");
            }
        %>
        </div>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <form action="#" target="preview" id="previewform" method="post">
    </form>
    <script>
        var Contents = [];
        $(function () {
            for (var i = 1; i <= 1; i++) {
                Contents[i] = CKEDITOR.editor.replace('ContentBody', {});
            }
        });

    </script>
</asp:Content>
