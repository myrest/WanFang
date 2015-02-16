<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.CostKeyword_Info Model = ViewData["Model"] as WanFang.Domain.CostKeyword_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.CostKeyword_Info();
        }
        List<WanFang.Domain.Webservice.CostDetailInformation> AllCost = new List<WanFang.Domain.Webservice.CostDetailInformation>() { };
        var ALLDept = new WanFang.BLL.WebService_Manage().GetAllDept();
        var DeptCode = ALLDept.Where(x => x.Value == Model.DeptName).FirstOrDefault().Key;
        WS_Dept_type Dept = EnumHelper.GetEnumByName<WS_Dept_type>(DeptCode);
        if (!string.IsNullOrEmpty(Model.DeptName))
        {
            AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(Dept);
        }
    %>
    <script>
        $(function () {
            $('#DeptName').change(ChangeDept);
        });

        function ChangeDept() {
            $this = $(this);
            var CostName = $this.val();
            var param = { CostCode: CostName };
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

        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            //var inst = FCKeditorAPI.GetInstance("Content1");
            //param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page5Service/SaveCostKeyword", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page5', 'CostKeyword') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="CostKeywordId" value="<%=Model.CostKeywordId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    科別關鍵字管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;團隊介紹管理&nbsp&#187&nbsp;科別關鍵字管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">門診類別<span class="red">*</span></td>
                    <td class="txt_l">
                      <select name="DeptName" id="DeptName">
                          <option>請選擇</option>
                          <%
                              foreach (var item in ALLDept)
                              {
                                  string selected = string.Empty;
                                  if (item.Key == DeptCode && Model.CostKeywordId > 0)
                                  {
                                      selected = "selected";
                                  }
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                              }
                          %>
                      </select>
                    </td><!--新欄位-->
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">科別<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="CostName" id="CostName">
                            <option>請選擇</option>
                          <%
                              foreach (var item in AllCost)
                              {
                                  string selected = string.Empty;
                                  if (item.CostName == Model.CostName)
                                  {
                                      selected = "selected";
                                  }
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.CostName, selected, item.CostName));
                              }
                          %>
                        </select>
                    </td>
                </tr>
                <tr class="line-d">
                  <td class="line-d0 top">關鍵字<span class=red>*</span></td>
                  <td><textarea name="KeyWord" cols="60" rows="3"><%=Model.KeyWord %></textarea></td>
                </tr>
                <tr class="line-d">
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
