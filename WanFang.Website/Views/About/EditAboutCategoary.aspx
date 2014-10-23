<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.AboutCategory_Info Model = ViewData["Model"] as WanFang.Domain.AboutCategory_Info;
        List<WanFang.Domain.About_Info> About = ViewData["About"] as List<WanFang.Domain.About_Info>;
        if (Model == null)
        {
            Model = new WanFang.Domain.AboutCategory_Info();
        }
    %>
    <script>
        function Save() {
            var param = $('#form1').serialize();
            utility.service("AboutService/SaveAboutCategoary", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('About', 'Categoary') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="AboutCategoryId" value="<%=Model.AboutCategoryId %>" />
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
        <table class="ww100" cellspacing="1" cellpadding="2" border="0">
            <tr class="line-d top">
                <td class="line-d0">
                    類別名稱<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <select name="AboutId">
                        <%
                            bool hasSelect = false;
                            foreach (var item in About)
                            {
                                string selected = "";
                                if (!hasSelect && (Model.AboutId == item.AboutId || Model.AboutId == 0))
                                {
                                    hasSelect = true;
                                    selected = "selected";
                                }
                                Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.AboutId, selected, item.Category));
                            }
                        %>
                    </select>
                </td>
            </tr>
            <tr class="line-d top">
                <td class="line-d0">
                    順序<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input name="SortNum" id="SortNum" value="<%=Model.SortNum%>" size="2" maxlength="2" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" />
                    <span class="red">僅排序用，例：01 <span class="orange">可以填0</span>，可以重複</span>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 va_m w150">
                    類別名稱<span class="red">*</span>
                </td>
                <td class="txt_l">
                    <input type="text" name="Category" id="Category" size="50" maxlength="255" value="<%=Model.Category%>">
                    （例：品質介紹）
                </td>
            </tr>
            <tr class="line-d top">
                <td class="line-d0">
                    上/下架
                </td>
                <td class="txt_l">
                    <% =UrlExtension.GenerIsActive(Model.IsActive)%>
                </td>
            </tr>
            <tr class="line-d">
                <td class="line-d0 top">
                    更新日期
                </td>
                <td>
                    <%=Model.LastUpdate %> -- <%=Model.LastUpdator %>
                </td>
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
