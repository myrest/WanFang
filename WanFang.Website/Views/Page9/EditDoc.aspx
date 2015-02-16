<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool EditForVerifier = (bool)ViewData["EditForVerifier"];
        WanFang.Domain.Doc_Info Model = ViewData["Model"] as WanFang.Domain.Doc_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Doc_Info();
        }
        List<WanFang.Domain.Webservice.CostDetailInformation> AllCost = new List<WanFang.Domain.Webservice.CostDetailInformation>() { };

        WS_Dept_type WSDept = (WS_Dept_type)ViewData["Dept"];

        string DeptName = ViewData["DeptName"].ToString();
        if (!string.IsNullOrEmpty(Model.DeptName))
        {
            DeptName = Model.DeptName;
        }
                
        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
        if (!string.IsNullOrEmpty(Model.Dept))
        {
            AllCost = new WanFang.BLL.WebService_Manage().GetAllDetailCostcerter(EnumHelper.GetEnumByName<WS_Dept_type>(Model.Dept));
        }
        string CostName = (string.IsNullOrEmpty(Model.CostName)) ? ViewData["CostName"].ToString() : Model.CostName;
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

            utility.service("Page9Service/SaveDoc", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page9', 'Doc') + '?DeptName=<%=WSDept.ToString()%>&CostName=<%=CostName%>&' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="DocId" value="<%=Model.DocId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    醫師詳細介紹管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;團隊介紹管理&nbsp&#187&nbsp;醫師詳細介紹管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">門診類別<span class="red">*</span></td>
                    <td class="txt_l">
                    <%=DeptName %>
                    <%
                        string DeptCode = (string.IsNullOrEmpty(Model.Dept)) ? ViewData["Dept"].ToString() : Model.Dept;
                    %>
                    <input type="hidden" name="DeptName" value="<%=DeptCode %>" />
                      <!-- select name="DeptName" id="DeptName">
                          <option>請選擇</option>
                          <%
                              foreach (var item in Dept)
                              {
                                  string selected = string.Empty;
                                  if (item.Key == Model.Dept)
                                  {
                                      selected = "selected";
                                  }
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Key, selected, item.Value));
                              }
                          %>
                      </!-->
                    </td><!--新欄位-->
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">科別<span class="red">*</span></td>
                    <td class="txt_l">
                    <input type="hidden" name="CostName" value="<%=CostName %>" /><%=CostName %>
                        <!-- select name="CostName" id="CostName">
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
                        </!-->
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">
                        順序<span class="red">*</span>
                    </td>
                    <td class="txt_l">
                        <input name="SortNum" type="text" value="<%=Model.SortNum %>" size="10">
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">醫師中文名字<span class="red">*</span></td>
                    <td>
                        <input name="DocName" type="text" value="<%=Model.DocName %>" size="50" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">科別中文代號</td>
                    <td>
                        <input name="Cost" type="text" value="<%=Model.Cost %>" size="30" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">醫師英文名字</td>
                    <td>
                        <input name="DocNameE" type="text" value="<%=Model.DocNameE %>" size="50" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">醫師員編<span class="red">*</span></td>
                    <td>
                        <input name="DocCode" type="text" value="<%=Model.DocCode %>" size="50" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">醫師照片<span class="red">*</span></td>
                    <td>
                        <%=UrlExtension.PreviewImage(Model.pic, "DocPic", !EditForVerifier)%>
                    <span class="red">建議尺寸：寬405px，高270px</span></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">專科證書</td>
                    <td>
                        <textarea name="slic" cols="60" rows="3"><%=Model.slic%></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">專科學會</td>
                    <td>
                        <textarea name="Association" cols="60" rows="3"><%=Model.Association %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">教職</td>
                    <td>
                        <input name="steach" type="text" value="<%=Model.steach %>" size="50" maxlength="255" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">進修</td>
                    <td>
                        <textarea name="learn" cols="60" rows="6"><%=Model.learn %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">人資核定狀態</td>
                    <td class="txt_l">
                        <%
                            string[] confflag = { "", "" };
                            confflag[0] = (Model.conf_flag == 0) ? "selected" : "";
                            confflag[1] = (Model.conf_flag == 1) ? "selected" : "";
                        %>
                        <select name="conf_flag" id="conf_flag">
                            <option value="0" <%=confflag[0] %>>尚未核准</option>
                            <option value="1" <%=confflag[1] %>>核定發布</option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">核定日期</td>
                    <td class="txt_l">
                        <input name="conf_date" type="text" value="<%=(Model.conf_date.HasValue) ? Model.conf_date.Value.ToString("yyyy/MM/dd") : ""%>" size="50" maxlength="255" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">主治項目<!-- 新欄位--><span class="red">*</span>（醫師詳細內頁）</td>
                    <td>
                        <input name="MainMajor1" type="text" value="<%=Model.MainMajor1 %>" size="50" maxlength="255" />
                        <br />
                        <input name="MainMajor2" type="text" value="<%=Model.MainMajor2 %>" size="50" maxlength="255" />
                        <br />
                        <input name="MainMajor3" type="text" value="<%=Model.MainMajor3 %>" size="50" maxlength="255" />
                        <br />
                        <input name="MainMajor4" type="text" value="<%=Model.MainMajor4 %>" size="50" maxlength="255" />
                        <br />
                        <input name="MainMajor5" type="text" value="<%=Model.MainMajor5 %>" size="50" maxlength="255" />
                        <br />
                        <span class="red">請輸入前5項主治項目</span>
                    </td>
                </tr>

                <tr class="line-d">
                    <td class="line-d0 top">主治項目介紹<!-- 原主治項目-->（醫師列表）</td>
                    <td>
                        <textarea name="smain" cols="60" rows="3"><%=Model.smain %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">學歷<span class="red">*</span></td>
                    <td>
                        <textarea name="school" cols="60" rows="3"><%=Model.school %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">醫師著作</td>
                    <td>
                        <textarea name="sci" cols="60" rows="3"><%=Model.sci %></textarea></td>
                </tr>

                <tr class="line-d">
                    <td class="line-d0 top">經歷<span class="red">*</span></td>
                    <td>
                        <textarea name="career" cols="60" rows="3"><%=Model.career %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">現職<span class="red">*</span></td>
                    <td>
                        <textarea name="ncareer" cols="60" rows="3"><%=Model.ncareer %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">門診時段</td>
                    <td>
                        <input name="otime" type="text" value="<%=Model.otime %>" size="90" maxlength="255" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">狀態</td>
                    <td class="txt_l">
                        <%
                            string[] status = { "", "" };
                            status[0] = (Model.status == 0) ? "selected" : "";
                            status[1] = (Model.status == 1) ? "selected" : "";
                        %>
                        <select name="status" id="status">
                            <option value="0" <%=status[0] %>>離職</option>
                            <option value="1" <%=status[1] %>>在職</option>
                        </select></td>
                </tr>

                <tr class="line-d">
                    <td class="line-d0 top">聯絡方式</td>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr class="no_line">
                                <td nowrap="nowrap" class="w80 top">
                                    <input name="webtype" type="radio" value="0" <%=(Model.webtype == 0) ? "checked" : "" %>/>
                                    連結：</td>
                                <td class="top">
                                    <input name="web" type="text" value="<%=Model.web %>" size="80" maxlength="255" />
                                    <br />
                                    （例：about.asp 或 img/1.jpg 或 http://www.xxx.com.tw/）</td>
                            </tr>
                            <tr class="no_line">
                                <td>
                                    <input name="webtype" type="radio" value="1" <%=(Model.webtype == 1) ? "checked" : "" %> />
                                    內容：</td>
                                <td>
                                    <input name="webcontent" type="text" value="<%=Model.webcontent %>" size="50" maxlength="255" /></td>
                            </tr>
                        </table>
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
    <script type="text/javascript" src="/CDN/Plugins/Manage/fckeditor/fckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
