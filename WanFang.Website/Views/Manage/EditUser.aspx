<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.User_Info Model = ViewData["Model"] as WanFang.Domain.User_Info;
        //List<WanFang.Domain.Webservice.CostInformation> Cost = ViewData["AllCost"] as List<WanFang.Domain.Webservice.CostInformation>;
        Dictionary<string, string> Dept = ViewData["AllDept"] as Dictionary<string, string>;
        if (Model == null)
        {
            Model = new WanFang.Domain.User_Info();
        }
    %>
    <script>
        $(function () {
            $('#DeptType').change(ChangeDept);
        });

        function ChangeDept() {
            $this = $(this);
            var CostName = $this.val();
            var param = { CostName: CostName };
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
            var param = $('#form1').serialize();
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
                        <input name="LoginId" type="text" maxlength="20" value="<%=Model.LoginId %>" /></td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0">登入密碼<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="Password" type="password" maxlength="20" />
                        <%if (Model.UserID > 0) Response.Write(" 不更改時，請留空白"); %>
                        </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 top">管理權限<span class="red">*</span>
                        <br />
                        <span class="red">(權限二則一)</span></td>
                    <td class="txt_l">
                        <table class="ww100" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="top"><input type="radio" name="PermissionType" value="0" <%=(Model.PermissionType==0?"checked":"") %> />權限1：</td>
                                <td class="top">科別管理權限<br />
                                    門診：
              <select name="DeptType" id="DeptType">
                  <option>請選擇</option>
                  <%
                      foreach (var item in Dept)
                      {
                          Response.Write(string.Format("<option value=\"{0}\">{1}</option>", item.Key, item.Value));
                      }
                  %>
              </select>
                                    科別：
              <select name="CostName" id="CostName">
                  <option selected="selected">請選擇</option>
              </select>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="top"><input type="radio" name="PermissionType" value="1" <%=(Model.PermissionType==1?"checked":"") %> />權限2：</td>
                                <td class="top">
                                    <input name="Permission" type="checkbox" value="首頁及時資訊管理" />首頁及時資訊管理<br />
                                    <input name="Permission" type="checkbox" value="關於萬芳管理" />關於萬芳管理<br />
                                    <input name="Permission" type="checkbox" value="最新消息管理" />最新消息管理<br />
                                    <input name="Permission" type="checkbox" value="預約及查詢管理" />預約及查詢管理<br />
                                    <input name="Permission" type="checkbox" value="就醫指南管理" />就醫指南管理<br />
                                    <input name="Permission" type="checkbox" value="團隊介紹管理" />團隊介紹管理<br />
                                    <input name="Permission" type="checkbox" value="衛教園區管理" />衛教園區管理<br />
                                    <input name="Permission" type="checkbox" value="人員募集管理" />人員募集管理<br />
                                    <input name="Permission" type="checkbox" value="健保專區管理" />健保專區管理<br />
                                    <input name="Permission" type="checkbox" value="詢問台管理" />詢問台管理<br />
                                    <input name="Permission" type="checkbox" value="表尾資料管理" />表尾資料管理<br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="va_m line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %> -- <% =Model.LastUpdator %></td>
                </tr>
            </table>        <div class="txt_c mag15" id="sendadd">
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
