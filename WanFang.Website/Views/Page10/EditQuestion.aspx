<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.Question_Info Model = ViewData["Model"] as WanFang.Domain.Question_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Question_Info();
        }
        else
        {
            Model.Q_ans = Model.Q_ans ?? "";
            Model.Q_ans = Model.Q_ans.Replace("\n\r", "");
            Model.Q_ans = Model.Q_ans.Replace("\n", "");
            Model.Q_ans = Model.Q_ans.Replace("\r", "");
        }

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
            param += "&Q_ans" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page10Service/SaveQuestion", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page10', 'Question') + '?' + (new Date()).getMilliseconds();
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
    <input type="hidden" name="QuestionId" value="<%=Model.QuestionId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">健康諮詢查詢管理</div>            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp詢問台管理&nbsp&#187&nbsp健康諮詢查詢管理        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d va_m">
                    <td class="line-d0">類別名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="Q_type">
                            <option <%=(Model.Q_type == "營養諮詢") ? "selected" : "" %>>營養諮詢</option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">科別<span class="red">*</span></td>
                    <td class="txt_l">
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
                    <td class="line-d0 va_m w150">提問標題<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="Q_title" type="text" value="<%=Model.Q_title%>" size="50">
                        （例：B肝帶原相關問題） </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">問題內容<span class="red">*</span></td>
                    <td>
                        <textarea name="Q_question" cols="60" rows="3"><%=Model.Q_question %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">回覆內容<span class="red">*</span></td>
                    <td>斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。
                             <br />
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '200';
                            oFCKeditor.Value = '<%=Model.Q_ans %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m w150">回覆者<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="Q_edit" type="text" value="<%=Model.Q_edit%>" size="10">
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">發佈日期</td>
                    <td>
                        <input type="text" name="Q_time" size="10" value="<%=(Model.Q_time == DateTime.MinValue) ? DateTime.Now.ToString("yyyy/MM/dd") : Model.Q_time.ToString("yyyy/MM/dd")%>" />
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
