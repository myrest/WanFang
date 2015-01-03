<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language="JavaScript" src="/CDN/Plugins/Manage/calendar.js"></script>
    <script language="JavaScript" src="/CDN/Plugins/Manage/calendar-setup.js"></script>
    <script language="JavaScript" src="/CDN/Plugins/Manage/lang/calendar-big5-utf8.js"></script>

    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.NewsData_Info Model = ViewData["Model"] as WanFang.Domain.NewsData_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.NewsData_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
            Model.ContentBody = Model.ContentBody.Replace("\n\r", "");
            Model.ContentBody = Model.ContentBody.Replace("\n", "");
            Model.ContentBody = Model.ContentBody.Replace("\r", "");
            Model.ContentBody = Model.ContentBody.Replace("'", "\\'");
        }
        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
        List<WanFang.Domain.Webservice.CostDetailInformation> AllCost = new List<WanFang.Domain.Webservice.CostDetailInformation>() { };
        WS_Dept_type? DeptType = ViewData["Dept"] as WS_Dept_type?;
        bool IsPrivate = (bool)ViewData["IsPrivate"];
        if (IsPrivate)
        {
            //若為私領域,則不顯示診別,只秀科別
            AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(DeptType.Value);
        }
        else
        {
            //若為公領域,要找出WS_Dept_type
            var _tmp = Dept.Where(x => x.Value == Model.DeptName).FirstOrDefault();
            if (_tmp.Key != null)
            {
                DeptType = EnumHelper.GetEnumByName<WS_Dept_type>(_tmp.Key);
                AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(DeptType.Value);
            }
        }

    %>
    <script>
        $(function () {
            $('#DeptName').change(ChangeDept);
        });
        function Preview() {
            var previewUrl = FrontEndUrl + '/p9_medical_education_detail.aspx?pv=1&cu=' + $('#pkId').val();
            $('#previewform').attr('action', previewUrl);
            $('#previewform').submit();
            $('#wordIsActive').text('下架');
        }
        function ChangeDept() {
            $this = $(this);
            var Cost = $this.val();
            var param = { CostCode: Cost };
            utility.service("ManageService/GetDeptInfo", param, "POST", function (data) {
                if (data.code > 0) {
                    $('#CostName').html('');
                    $('#CostName').append(new Option('請選擇', "", true, true));
                    if (data.list != undefined) {
                        $.each(data.list, function (index, ele) {
                            $('#CostName').append(new Option(ele.CostName, ele.CostName, false, false));
                        });
                    }
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function Save(SaveType) {
            if (SaveType == 1) {
                Preview();
            } else {
                var DeptName = $('#DeptName option:selected').text();
                $('#DeptName').html('');
                $('#DeptName').append(new Option(DeptName, DeptName, true, true));
                var param = $('#form1 :not([name^=Content])').serialize();
                var inst = FCKeditorAPI.GetInstance("Content1");
                param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

                utility.service("Page6Service/SaveNewsData", param, "POST", function (data) {
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
        var backAction = '<% =(IsPrivate ? "NewsDataPrivate" : "NewsData")%>';

        function GoBack() {
            var redirto = utility.getRedirUrl('Page6', backAction) + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="NewsId" id="pkId" value="<%=Model.NewsId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    醫療衛教管理
                </div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;特色醫療管理&nbsp&#187&nbsp;醫療衛教管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <input type="hidden" name="IsPrivate" value="<%=IsPrivate ? "1" : "0" %>" />
        <table cellspacing="1" cellpadding="2" width="100%" border="0">
            <% if (!IsPrivate)
               {
                   %>
                <tr class="line-d">
                    <td class="line-d0 va_m">科別<span class="red">*</span></td>
                    <td class="txt_l">
                      <select name="DeptName" id="DeptName">
                          <option>請選擇</option>
                          <%
                              foreach (var item in Dept)
                              {
                                  string selected = string.Empty;
                                  if (item.Value == Model.DeptName) selected = "selected";
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                              }
                          %>
                      </select>
                    </td>
                </tr>
                    <%
               }
               else
               {
                   %>
            <input type="hidden" id="DeptName" name="DeptName" value="<%=DeptType.Value %>" />
                    <%
               }
            %>
            <tr class="line-d">
                <td class="line-d0 top">發表科別代號</td>
                <td>
                    <%
                        if (!IsPrivate)
                        {
                            %>
                    <select name="Cost" id="CostName">
                        <%
                            foreach (var item in AllCost)
                            {
                                string selected = string.Empty;
                                if (!string.IsNullOrEmpty(Model.Cost) && item.CostName.Trim() == Model.Cost.Trim())
                                {
                                    selected = "selected";
                                }
                                if (!string.IsNullOrEmpty(Model.CostId) && item.CostCode.Trim() == Model.CostId.Trim())
                                {
                                    selected = "selected";
                                }
                                Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.CostName, selected, item.CostName));
                            }
                        %>
                    </select>
                            <%
                        }
                        else
                        {
                            string CostName = ViewData["CostName"].ToString();
                            if (!string.IsNullOrEmpty(Model.Cost)) CostName = Model.Cost;
                            %>
                        <input type="hidden" name="Cost" value="<%=CostName %>" />
                        <%=CostName %>
                            <%
                        }
                    %>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m w150">標題<span class="red">*</span></td>
                <td class="txt_l">
                    <input name="Title" type="text" value="<%=Model.Title %>" size="50"></td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">發表者<span class="red">*</span></td>
                <td>
                    <input name="Author" type="text" value="<%=Model.Author %>" size="50" /></td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">後台關鍵字<span class="red">*</span></td>
                <td>
                    <textarea name="Keyword" cols="60" rows="3"><%=Model.Keyword %></textarea></td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">內容<span class="red">*</span></td>
                <td>
                    <div style="clear: both; padding: 3px 0px 3px 0px;" class="red">斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                    <br />
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
                <td class="line-d0 top">圖片上傳<span class="red">*</span></td>
                <td>
                    <table class="ww100" border="0" cellpadding="0" cellspacing="0">
                        <tr class="no_line">
                            <td>圖1：</td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image1, "NewsDataImage1", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span></td>
                        </tr>
                        <tr class="no_line">
                            <td>圖2：</td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image2, "NewsDataImage2", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span></td>
                        </tr>
                        <tr class="no_line">
                            <td>圖3：</td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image3, "NewsDataImage3", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span></td>
                        </tr>
                        <tr class="no_line">
                            <td>圖4：</td>
                            <td>
                                <%=UrlExtension.PreviewImage(Model.Image4, "NewsDataImage4", !EditForVerifier)%>
                                <span class="red">建議尺寸：寬800px，高535px</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m">顯示在團隊介紹</td>
                <td class="txt_l">
                    <input name="IsShowOnTeam" type="checkbox" value="1" <%=(Model.IsShowOnTeam == 1) ?"checked" : ""  %> />
                    顯示
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">發佈日期</td>
                <td>
                    <input name="PublishDate" type="text" size="10" value="<%=(Model.PublishDate == DateTime.MinValue) ? DateTime.Now.ToString("yyyy/MM/dd") : Model.PublishDate.ToString("yyyy/MM/dd")%>" />
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
                <td><%=Model.LastUpdate %>--<%=Model.LastUpadtor %></td>
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
