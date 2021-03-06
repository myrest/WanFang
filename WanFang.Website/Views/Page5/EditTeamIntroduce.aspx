﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.TeamIntroduce_Info Model = ViewData["Model"] as WanFang.Domain.TeamIntroduce_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.TeamIntroduce_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
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
        $(function () {
            $('#CostName').change(ChangeCost);
        });

        function ChangeCost() {
            $this = $(this);
            $('#CostId').val($this.val());
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
                            $("#CostName").append($("<option></option>").attr("value", ele.CostCode).text(ele.CostName));
                        });
                    }
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function Save() {
            var CostName = $('#CostName option:selected').text();
            $('#CostName').html('');
            $("#CostName").append($("<option></option>").attr("value", CostName).text(CostName));
            var param = $('#form1 :not([name^=Content])').serialize();
            var i = '1';
            var editorContent = Contents[i].getData();
            param += "&ContentBody=" + encodeURIComponent(editorContent);

            utility.service("Page5Service/SaveTeamIntroduce", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page5', 'TeamIntroduce') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="TeamIntroduceId" value="<%=Model.TeamIntroduceId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">團隊介紹</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp團隊介紹
        </div>
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
                                  if (item.Key == DeptCode && Model.TeamIntroduceId > 0)
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
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.CostCode, selected, item.CostName));
                              }
                          %>
                        </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">科別代號<span class="red">*</span></td>
                    <td>
                        <input name="CostId" type="text" id="CostId" value="<%=Model.CostId %>" size="30" maxlength="255" readonly /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">網頁選單代號<span class="red">*</span></td>
                    <td>
                            <input name="WebMenuCode" type="text" value="<%=Model.WebMenuCode %>" size="50" maxlength="255" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">網頁選單名稱<span class="red">*</span></td>
                    <td>
                        <input name="WebMenuName" type="text" value="<%=Model.WebMenuName %>" size="50" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 top">內容<span class="red">*</span></td>
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
                                    <%=UrlExtension.PreviewImage(Model.Image1, "TeamIntroduceImage1", !EditForVerifier)%>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖2：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image2, "TeamIntroduceImage2", !EditForVerifier)%>
                                    </td>
                                <!--新欄位-->
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖3：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image3, "TeamIntroduceImage3", !EditForVerifier)%>

                                    </td>
                                <!--新欄位-->
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖4：</td>
                                <td>
                                    <%=UrlExtension.PreviewImage(Model.Image4, "TeamIntroduceImage4", !EditForVerifier)%>
                                    </td>
                                <!--新欄位-->
                            </tr>
                        </table>
                        <div class="red" style="clear: both; padding-top: 10px;">圖1~4　建議尺寸：寬800px，高535px</div>
                    </td>
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
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        var Contents = [];
        $(function () {
            for (var i = 1; i <= 1; i++) {
                Contents[i] = CKEDITOR.editor.replace('ContentBody', {});
            }
        });
    </script>
</asp:Content>
