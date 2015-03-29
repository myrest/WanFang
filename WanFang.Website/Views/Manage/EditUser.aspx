<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.User_Info Model = ViewData["Model"] as WanFang.Domain.User_Info;
        if (Model == null) Model = new WanFang.Domain.User_Info();
        WS_Dept_type WSDept = EnumHelper.GetEnumByName<WS_Dept_type>(Model.DeptName);
        string DeptName = (string.IsNullOrEmpty(Model.DeptName)) ? "" : EnumHelper.GetEnumDescription<WS_Dept_type>(WSDept);
        
        Dictionary<string, string> Dept = ViewData["AllDept"] as Dictionary<string, string>;
        if (Model == null)
        {
            Model = new WanFang.Domain.User_Info();
        }

        if (string.IsNullOrEmpty(DeptName) && Model.IsVerifier == 1)
        {
            DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(WSDept);
        }
    %>
    <script>
        $(function () {
            $('#DeptName').change(ChangeDept);
            $('#IsVerifier').change(ChangeToVerifier);
        });

        function ChangeToVerifier() {
            if ($('input[name="IsVerifier"]:checked').length > 0) {
                $('input[name="Permission"]').prop('checked', true);
                $('input[name="PermissionType"]').first().prop('checked', true);
                $('input[name="PermissionType"]').last().prop('checked', false);
                $('#DeptName option').last().prop('selected', true);
                $('#PermissionSetting').hide();
            } else {
                $('#PermissionSetting').show();
            }
        }

        function ChangeDept() {
            $this = $(this);
            var CostName = $this.val();
            var param = { CostCode: CostName };
            utility.service("ManageService/GetDeptInfo", param, "POST", function (data) {
                if (data.code > 0) {
                    $('#CostName').html('');
                    $("#CostName").append($("<option></option>").attr("value", "").text("請選擇"));
                    if (data.list != undefined) {
                        $.each(data.list, function (index, ele) {
                            $("#CostName").append($("<option></option>").attr("value", ele.CostName).text(ele.CostName));
                        });
                    }
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }
        function Save() {
            var param = $('#form1 :not([name=Permission])').serialize();
            var allpermiss = "";
            $('input[name="Permission"]:checked').each(function () {
                allpermiss += "," + this.value;
            });
            if (allpermiss.length > 0) {
                allpermiss = allpermiss.substring(1, allpermiss.length);
            }
            param += "&Permission=" + allpermiss;

            utility.service("ManageService/SaveUser", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Manage', 'UserListing') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="UserID" value="<%=Model.UserID %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    關於萬芳系列管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp關於萬芳管理&nbsp&#187&nbsp關於萬芳系列管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="va_m line-d">
                    <td class="line-d0">管理者名稱</td>
                    <td class="txt_l">
                        <input name="UserName" type="text" value="<%=Model.UserName %>" maxlength="20"></td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0">登入帳號<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="LoginId" type="text" maxlength="20" value="<%=Model.LoginId %>" 
                        <% if (Model.UserID > 0) Response.Write(" readonly "); %>
                        /></td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0">登入密碼<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="Password" type="password" maxlength="20" />
                        <%if (Model.UserID > 0) Response.Write(" 不更改時，請留空白"); %>
                        </td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0">特別設定</td>
                    <td class="txt_l">
                        <input type="checkbox" value="1" id="IsVerifier" name="IsVerifier" <%=Model.IsVerifier == 0?"":"checked" %> />具有審核權
                    </td>
                </tr>
                <tr class="line-d <%=(Model.IsVerifier == 1) ? "hide" : "" %>" id="PermissionSetting">
                    <td class="line-d0 w150 top">管理權限<span class="red">*</span>
                        <br />
                        <span class="red">(權限二則一)</span></td>
                    <td class="txt_l">
                        <table class="ww100" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="top"><input type="radio" name="PermissionType" value="0" <%=(Model.PermissionType==0?"checked":"") %> />私領域：</td>
                                <td class="top">
                                    門診：
              <select name="DeptName" id="DeptName">
                  <option>請選擇</option>
                  <%
                      foreach (var item in Dept)
                      {
                          string selected = string.Empty;
                          if (Model.UserID > 0 && item.Value == DeptName) selected = "selected";
                          Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                      }
                  %>
              </select>
                                    科別：
              <select name="CostName" id="CostName">
                  <option>請選擇</option>
                  <%
                      WanFang.BLL.WebService_Manage service = new WanFang.BLL.WebService_Manage();
                      var cost = service.GetAllDetailCostcerter(WSDept);
                      foreach (var item in cost)
                      {
                          string selected = string.Empty;
                          if (!string.IsNullOrEmpty(Model.CostName) && item.CostName.Trim() == Model.CostName.Trim())
                          {
                              selected = "selected";
                          }
                          Response.Write(string.Format("<option value=\"{0}\" {1} >{0}</option>", item.CostName, selected));
                      }
                  %>
              </select>
              <br />
              限定使用[特色醫療管理]
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top"><input type="radio" name="PermissionType" value="1" <%=(Model.PermissionType==1?"checked":"") %> />公領域：</td>
                                <td class="top">
                                <%
                                    List<string> permisses = new List<string>()
                                    {
                                        "首頁及時資訊管理"
                                        ,"關於萬芳管理"
                                        ,"最新消息管理"
                                        ,"預約及查詢管理"
                                        ,"就醫指南管理"
                                        ,"團隊介紹管理"
                                        ,"衛教園區管理"
                                        ,"人員募集管理"
                                        ,"健保專區管理"
                                        ,"詢問台管理"
                                        ,"表尾資料管理"
                                        ,"員工帳號管理"
                                    };

                                    foreach (string perstr in permisses)
                                    {
                                        string ischecked = string.Empty;
                                        if (Model.Permission != null && Model.Permission.Contains(perstr))
                                        {
                                            ischecked = "checked";
                                        }
                                        Response.Write(string.Format("<input name=\"Permission\" type=\"checkbox\" value=\"{0}\" {1} />{0}<br />\n\r", perstr, ischecked));
                                    }
                                %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %> -- <% =Model.LastUpdator %></td>
                </tr>
            </table>
        <div class="txt_c mag15" id="sendadd">
            <input type="button" class="submit" id="Submit" value="送出" onclick="Save();" />
        </div>
        <!--main end-->
    </div>
    <!--new 關於萬芳／p1_about.aspx-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
