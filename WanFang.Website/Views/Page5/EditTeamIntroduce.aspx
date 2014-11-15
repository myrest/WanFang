<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.TeamIntroduce_Info Model = ViewData["Model"] as WanFang.Domain.TeamIntroduce_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.TeamIntroduce_Info();
        }
        else
        {
            Model.ContentBody = Model.ContentBody ?? "";
            Model.ContentBody = Model.ContentBody.Replace("\n\r", "");
            Model.ContentBody = Model.ContentBody.Replace("\n", "");
            Model.ContentBody = Model.ContentBody.Replace("\r", "");
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
                    $('#CostName').append(new Option('請選擇', "", true, true));
                    if (data.list != undefined) {
                        $.each(data.list, function (index, ele) {
                            $('#CostName').append(new Option(ele.CostName, ele.CostCode, false, false));
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
            $('#CostName').append(new Option(CostName, CostName, true, true));
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

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
                <div class="tt-r">團隊介紹</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp團隊介紹        </div>        <p class="clear">
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
                        <script type="text/javascript" id="content">
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
                                    <input type="file" id="TeamIntroduceImage1" size="30" />
                                    <%=UrlExtension.PreviewImage(Model.Image1, "TeamIntroduceImage1")%>
                                </td>
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖2：</td>
                                <td>
                                    <input type="file" id="TeamIntroduceImage2" size="30" />
                                    <%=UrlExtension.PreviewImage(Model.Image2, "TeamIntroduceImage2")%>
                                    </td>
                                <!--新欄位-->
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖3：</td>
                                <td>
                                    <input type="file" id="TeamIntroduceImage3" size="30" />
                                    <%=UrlExtension.PreviewImage(Model.Image3, "TeamIntroduceImage3")%>

                                    </td>
                                <!--新欄位-->
                            </tr>
                            <tr class="no_line">
                                <td class="line-d w50 top">圖4：</td>
                                <td>
                                    <input type="file" id="TeamIntroduceImage4" size="30" />
                                    <%=UrlExtension.PreviewImage(Model.Image4, "TeamIntroduceImage4")%>
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
                        <% =UrlExtension.GenerIsActive(Model.IsActive)%>
                    </td>
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
