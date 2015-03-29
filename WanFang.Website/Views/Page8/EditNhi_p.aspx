<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.Nhi_p_Info Model = ViewData["Model"] as WanFang.Domain.Nhi_p_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Nhi_p_Info();
        }
        else
        {
            Model.warnings = Model.warnings ?? "";
            Model.warnings = System.Web.HttpUtility.HtmlDecode(Model.warnings);
            Model.warnings = Model.warnings.Replace("\n\r", "");
            Model.warnings = Model.warnings.Replace("\n", "");
            Model.warnings = Model.warnings.Replace("\r", "");
            Model.warnings = Model.warnings.Replace("'", "\\'");
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            var inst = FCKeditorAPI.GetInstance("Content1");
            param += "&warnings" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page8Service/SaveNhi_p", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page8', 'Nhi_p') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="nhi_pId" value="<%=Model.nhi_pId %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">健保專區項目管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp健保專區管理&nbsp&#187&nbsp健保專區項目管理
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 va_m">特材類型<span class="red">*</span></td>
                    <td class="txt_l">
                        <select name="nhi_code" id="nhi_code">
                            <option <%=(Model.nhi_code == "塗藥血管支架") ? "selected" : "" %>>塗藥血管支架</option>
                            <option <%=(Model.nhi_code == "人工髖關節組件") ? "selected" : "" %>>人工髖關節組件</option>
                            <option <%=(Model.nhi_code == "特殊功能人工水晶體") ? "selected" : "" %>>特殊功能人工水晶體</option>
                            <option <%=(Model.nhi_code == "自費特材品項") ? "selected" : "" %>>自費特材品項 </option>
                            <option <%=(Model.nhi_code == "人工心律調節器") ? "selected" : "" %>>人工心律調節器 </option>
                        </select></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 va_m">品項名稱<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="nhi_type" type="text" value="<%=Model.nhi_type %>" size="50">
                        </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">中文品名<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="nhi_cname"type="text" value="<%=Model.nhi_cname %>" size="50"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">英文品名 / 許可證號<span class="red">*</span></td>
                    <td>
                        <input name="nhi_ename" type="text" value="<%=Model.nhi_ename %>" size="100" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">院內代碼</td>
                    <td>
                        <input name="fee_code" type="text" value="<%=Model.fee_code %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">健保代碼</td>
                    <td>
                        <input name="HealthCode" type="text" value="<%=Model.HealthCode %>" size="50" /></td>
                    <!--新欄位-->
                </tr>
                <tr class="line-d">
                    <td class="line-d0">品項代碼 / 廠牌名稱</td>
                    <td>
                        <input name="mark_name" type="text" value="<%=Model.mark_name %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">計價單位</td>
                    <td>
                        <input name="unit" type="text" value="<%=Model.unit %>" size="10" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">健保金額</td>
                    <td>
                        <input name="nhi_cost" type="text" value="<%=Model.nhi_cost %>" size="20" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">自費金額</td>
                    <td>
                        <input name="self_cost" type="text" value="<%=Model.self_cost %>" size="20" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0">自付差額</td>
                    <td>
                        <input name="price_dif" type="text" value="<%=Model.price_dif %>" size="20" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">警語</td>
                    <td>
                        <div style="clear: both; padding: 3px 0px 3px 0px;" class="red">斷行：先按住「Shift 鍵」不放,再按「Enter 鍵」。</div>
                        <br />
                        <script type="text/javascript">
                            var oFCKeditor = new FCKeditor('Content1');
                            oFCKeditor.BasePath = "/CDN/Plugins/Manage/fckeditor/";
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '250';
                            oFCKeditor.Value = '<%=Model.warnings %>';
                            oFCKeditor.Create();
                        </script>
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">禁忌症</td>
                    <td>
                        <textarea name="contrain" cols="60" rows="6"><%=Model.contrain%></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">副作用</td>
                    <td>
                        <textarea name="sideffect" cols="60" rows="6"><%=Model.sideffect%></textarea></td>
                </tr>

                <tr class="line-d">
                    <td class="line-d0 ">發佈日期<span class="red">*</span></td>
                    <td>
                        <input name="nhi_date" type="text" size="10" value="<%=(Model.nhi_date.HasValue && Model.nhi_date != DateTime.MinValue) ? Model.nhi_date.Value.ToString("yyyy/MM/dd") : "" %>" />
                    </td>
                </tr>
                <!-- 他的id="nhi_date"-->
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
