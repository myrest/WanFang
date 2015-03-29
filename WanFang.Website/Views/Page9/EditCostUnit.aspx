<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.CostUnit_Info Model = ViewData["Model"] as WanFang.Domain.CostUnit_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.CostUnit_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
            Model.ContentBody = Model.ContentBody.Replace("\n\r", "");
            Model.ContentBody = Model.ContentBody.Replace("\n", "");
            Model.ContentBody = Model.ContentBody.Replace("\r", "");
            Model.ContentBody = Model.ContentBody.Replace("'", "\\'");
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
            var previewUrl = FrontEndUrl + '/p9_medical_detail.aspx?pv=1&cu=' + $('#pkId').val();
            var previewHomePageUrl = FrontEndUrl + '/p9_medical.aspx?pv=1&cu=' + $('#pkId').val();
            if ($('input[name=IsHomePage]:checked').val() == "1") {
                $('#previewform').attr('action', previewHomePageUrl);
            } else {
                $('#previewform').attr('action', previewUrl);
            }
            $('#previewform').submit();
            $('#wordIsActive').text('下架');
        }
        function Save(SaveType) {
            if (SaveType == 1) {
                Preview();
            } else {
                var param = $('#form1 :not([name^=Content])').serialize();
                var inst = FCKeditorAPI.GetInstance("Content1");
                param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

                utility.service("Page9Service/SaveCostUnit", param, "POST", function (data) {
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

        function togTrContent(isHomePage) {
            var $block = $('#trcontent');
            if (isHomePage == 1) {
                $block.hide();
            } else {
                $block.show();
            }
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page9', 'Index') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="CostUnitId" id="pkId" value="<%=Model.CostUnitId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    單元管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp特色醫療管理&nbsp&#187&nbsp單元管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <table cellspacing="1" cellpadding="2" class="ww100" border="0">
            <tr class="line-d">
                <td class="line-d0 va_m w150">
                    順序<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input name="SortNum" type="text" value="<%=Model.SortNum %>" size="10">
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m w150">
                    門診
                </td>
                <td class="txt_l">
                    <%=DeptName %>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m w150">
                    科別
                </td>
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
                <td class="line-d0 va_m w150">
                    單元名稱<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input name="UnitName" type="text" value="<%=Model.UnitName %>" size="50">
                </td>
            </tr>
            <tr class="line-d <% =(Model.IsHomePage == 1) ? "hide" : "" %>" id="trcontent">
                <td class="line-d0 top">
                    內容<span class="red">*</span>
                </td>
                <td>
                    <div style="clear: both; padding: 3px 0px 3px 0px;" class="red">
                        斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                    <br />
                    <script type="text/javascript">
                        var oFCKeditor = new FCKeditor('Content1');
                        oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                        oFCKeditor.Width = '100%';
                        oFCKeditor.Height = '250';
                        oFCKeditor.Value = '<%=Model.ContentBody %>';
                        oFCKeditor.Create();
                    </script>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">
                    圖片上傳
                </td>
                <td>
                    <table class="ww100" border="0" cellpadding="0" cellspacing="0">
                        <tr class="no_line">
                            <td>
                                圖1：
                            </td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image1, "CostUnitImage1", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td>
                                圖2：
                            </td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image2, "CostUnitImage2", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span>
                            </td>
                        </tr>
                        <tr class="no_line">
                            <td>
                                圖3：
                            </td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image3, "CostUnitImage3", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="line-d top">
                <td class="line-d0">
                    是否為首頁
                </td>
                <td class="txt_l">
                    <input type="radio" value="1" name="IsHomePage" <%=(Model.IsHomePage) == 1 ? "checked" : "" %> onclick="togTrContent(1);" />是
                    <input type="radio" value="0" name="IsHomePage" <%=(Model.IsHomePage) == 0 ? "checked" : "" %> onclick="togTrContent(0);" />否
                </td>
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
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <form action="#" target="preview" id="previewform" method="post">
    </form>
</asp:Content>
