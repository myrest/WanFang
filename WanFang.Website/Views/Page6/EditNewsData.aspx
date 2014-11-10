<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script language="JavaScript" src="/CDN/Plugins/Manage/calendar.js"></script>
<script language="JavaScript" src="/CDN/Plugins/Manage/calendar-setup.js"></script>
<script language="JavaScript" src="/CDN/Plugins/Manage/lang/calendar-big5-utf8.js"></script>
    <%
        WanFang.Domain.NewsData_Info Model = ViewData["Model"] as WanFang.Domain.NewsData_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.NewsData_Info();
        }
        var Dept = new WanFang.BLL.WebService_Manage().GetAllDept();
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page6Service/SaveNewsData", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page6', 'NewsData') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="NewsId" value="<%=Model.NewsId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    醫療衛教管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp;特色醫療管理&nbsp&#187&nbsp;醫療衛教管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" width="100%" border="0">
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
                                  Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.Value, selected, item.Value));
                              }
                          %>
                      </select>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">發表科別代號</td>
                    <td>
                        <input name="Cost" type="text" value="<%=Model.Cost %>" size="50" /></td>
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
                                    <input type="file" id="NewsDataImage1" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image1, "NewsDataImage1")%>
                    <span class="red">建議尺寸：寬800px，高535px</span></td>
                            </tr>
                            <tr class="no_line">
                                <td>圖2：</td>
                                <td>
                                    <input type="file" id="NewsDataImage2" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image2, "NewsDataImage2")%>
                    <span class="red">建議尺寸：寬800px，高535px</span></td>
                            </tr>
                            <tr class="no_line">
                                <td>圖3：</td>
                                <td>
                                    <input type="file" id="NewsDataImage3" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image3, "NewsDataImage3")%>
                    <span class="red">建議尺寸：寬800px，高535px</span></td>
                            </tr>
                            <tr class="no_line">
                                <td>圖4：</td>
                                <td>
                                    <input type="file" id="NewsDataImage4" size="30"/>
                                    <%=UrlExtension.PreviewImage(Model.Image4, "NewsDataImage4")%>
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
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
                    <td><%=Model.LastUpdate %>--<%=Model.LastUpadtor %></td>
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
