<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.HirDetail_Info Model = ViewData["Model"] as WanFang.Domain.HirDetail_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.HirDetail_Info();
        }
        else
        {
            Model.Condition = Model.Condition.Replace("\n\r", "");
            Model.Condition = Model.Condition.Replace("\n", "");
            Model.Condition = Model.Condition.Replace("\r", "");
        }
        var categoary = new WanFang.BLL.HirCategory_Manager().GetAll();

        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
        var AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(EnumHelper.GetEnumByName<WS_Dept_type>(Model.Dept));
        
    %>
    <script>
        $(function () {
            $('#Dept').change(ChangeDept);
        });

        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&Condition" + "=" + encodeURIComponent(inst.GetHTML());
            param += "&HirName" + "=" + $('#HirCategoryId option:selected').text();

            utility.service("Page7Service/SaveHirDetail", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page7', 'HirDetail') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }

        function ChangeDept() {
            $this = $(this);
            var Dept = $this.val();
            $('#DeptName').val($('#Dept option:selected').text());
            var param = { CostCode: Dept };
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
    </script>
    <input type="hidden" name="HirDetailId" value="<%=Model.HirDetailId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">人員募集項目管理</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp人員募集管理&nbsp&#187&nbsp人員募集項目管理        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" width="100%" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">職缺類別代號<span class="red">*</span></td>
                    <td class="line-d txt_l">
                          <select name="HirCategoryId" id="HirCategoryId">
                              <%
                                  foreach (var item in categoary)
                                  {
                                      string selected = (item.HirCategoryId == Model.HirCategoryId) ? "selected" : "";
                                      Response.Write(string.Format("<option {0} value=\"{1}\">{2}</option>", selected, item.HirCategoryId, item.CategoryName));
                                  }
                              %>
                          </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">職缺單位<span class="red">*</span></td>
                    <td class="line-d txt_l">
                        <input type="hidden" id="DeptName" name="DeptName" value="<%=Model.DeptName %>" />
                          <select name="Dept" id="Dept">
                              <option>請選擇</option>
                              <%
                                  foreach (var item in Dept)
                                  {
                                      string selected = string.Empty;
                                      if (Model.Dept == item.Key)
                                      {
                                          selected = "selected";
                                      }
                                      Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                                  }
                              %>
                          </select>
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
                    <td class="line-d0">職缺名稱<span class="red">*</span></td>
                    <td>
                        <input name="JobTitle" type="text" value="<%=Model.JobTitle %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">職缺數量<span class="red">*</span></td>
                    <td>
                        <input name="Nums" type="text" value="<%=Model.Nums %>" size="10" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">學歷限制<span class="red">*</span></td>
                    <td>
                        <input name="SchoolLimit" type="text" value="<%=Model.SchoolLimit %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">其他條件</td>
                    <td>
                        <div style="clear: both; padding: 3px 0px 3px 0px;" class="red">斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                        <br />
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '200';
                            oFCKeditor.Value = '<%=Model.Condition %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">發佈日期</td>
                    <td>
                        <input name="PublishDate" type="text" size="10" value="<%=(Model.PublishDate == DateTime.MinValue) ? DateTime.Now.ToString("yyyy/MM/dd") : Model.PublishDate.ToString("yyyy/MM/dd")%>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">發佈狀態</td>
                    <td>
                        <select name="IsActive">
                            <option value="0" <%=(Model.IsActive == 0) ? "selected" : "" %>>無效關閉此職缺</option>
                            <option value="1" <%=(Model.IsActive == 1) ? "selected" : "" %>>有效</option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">更新日期</td>
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
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
