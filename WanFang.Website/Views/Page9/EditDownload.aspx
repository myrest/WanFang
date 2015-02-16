<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.WebDownload_Info Model = ViewData["Model"] as WanFang.Domain.WebDownload_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.WebDownload_Info();
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
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            //var inst = FCKeditorAPI.GetInstance("Content1");
            //param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page9Service/SaveDownLoad", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page9', 'Download') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="WebDownLoadID" value="<%=Model.WebDownLoadID %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    檔案下載管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;特色醫療管理&nbsp&#187&nbsp;檔案下載管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m w100">順序<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="SortNum" type="text" value="<%=Model.SortNum %>" size="10"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">門診</td>
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
                                    Response.Write(string.Format("<option value=\"{0}\" {1} >{0}</option>", item.CostName, selected));
                                }
                            %>
                        </!-->
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">檔案名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="DocumentName" type="text" value="<%=Model.DocumentName %>" size="80"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">檔案上傳<span class="red">*</span></td>
                    <td>
                        <%=UrlExtension.PreviewImage(Model.File1, "WebDownLoadFile1", !EditForVerifier)%>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">上傳說明</td>
                    <td>
                        <span class="red">&#187;檔案格式，只接受JPG,GIF,BMP,PNG,PDF,DOC,DOCX,PPT,PPTX,XLS,XLSX,TXT,ZIP,RAR的檔案，檔案大小限3MB以內。<br>
                        </span><span class="red">&#187;檔案名稱，請以英數字字元命名(不接受中文檔名及特殊字元)。</span>
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
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
