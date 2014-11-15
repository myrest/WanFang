<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        bool IsVerifer = (bool)ViewData["Verify"];
        string VeriferClass = IsVerifer ? "" : " hide ";
        
        List<WanFang.Domain.AboutContent_Info> Model = ViewData["Model"] as List<WanFang.Domain.AboutContent_Info>;
        List<WanFang.Domain.About_Info> About = ViewData["About"] as List<WanFang.Domain.About_Info>;
        List<WanFang.Domain.AboutCategory_Info> Categoary = ViewData["Categoary"] as List<WanFang.Domain.AboutCategory_Info>;
        WanFang.Domain.AboutContent_Filter filter = ViewData["Filter"] as WanFang.Domain.AboutContent_Filter;
        string DDlstr = "{" + Environment.NewLine;
        About.ForEach(x =>
        {
            DDlstr += Environment.NewLine + x.AboutId + ":" + Environment.NewLine + "{";
            Categoary.Where(y => y.AboutId == x.AboutId).ToList().ForEach(y =>
            {
                DDlstr += string.Format("'{0}':'{1}',", y.AboutCategoryId, y.Category);
            });
            if (DDlstr.EndsWith(",")) DDlstr = DDlstr.Substring(0, DDlstr.Length - 1);
            DDlstr += "},";
        });
        if (DDlstr.EndsWith(",")) DDlstr = DDlstr.Substring(0, DDlstr.Length - 1);
        DDlstr += "}";
    %>
    <script>
        function DeleteSelected() {
            var param = $('input[name="id"]:checked').serialize();
            utility.showPopUp('您確定要刪除嗎？', 3, function () {
                utility.service("DeleteService/DeleteAboutContent", param, "POST", function (data) {
                    if (data.code > 0) {
                        document.location.reload(true);
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            });

        }
        var DDLMenu = <%=DDlstr %>;
        function ChangeDDL(){
            $this = $(this);
            var AboutId = $this.val();
            var data = DDLMenu[AboutId];
            $('#AboutCategoryId').html('');
            $('#AboutCategoryId').append(new Option('全部顯示', "", true, true));
            if (data != undefined){
                $.each(data, function (index, ele) {
                    $('#AboutCategoryId').append(new Option(ele, index, false, false));
                });                
            }
        }
        $(function(){
            $('#AboutId').change(ChangeDDL);
        });
    </script>
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" />
                </div>
                <div class="tt-r">
                    關於萬芳圖文管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp關於萬芳管理&nbsp&#187&nbsp關於萬芳圖文管理
        </div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                上下架：
                <%=WanFang.Core.MVC.Extensions.UrlExtension.GenerFilterIsActive(filter.IsActive) %>
            </p>
            <p>
                類 別：
                <select name="AboutId" id="AboutId">
                    <option>全部顯示</option>
                    <%
                        foreach (var item in About)
                        {
                            string selected = "";
                            if (filter.AboutId.HasValue && filter.AboutId.Value == item.AboutId)
                            {
                                selected = "selected";
                            }
                            Response.Write(string.Format("<option value=\"{0}\" {1} >{2}</option>", item.AboutId, selected, item.Category));
                        }
                    %>
                </select>
                <select name="AboutCategoryId" id="AboutCategoryId">
                    <option>全部顯示</option>
                </select>
            </p>
            <p>
                關鍵字：
                <input name="UnitName" type="text" value="請輸入系列名稱搜尋" onclick="this.value = '';" size="30"
                    id="UnitName" onkeydown="if(event.keyCode==13){this.form.submit();}" />
                <input type="submit" class="submit" value="搜尋" id="Submit" />
            </p>
        </div>
        <table class="ww100 magTop10" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <input name="button" type="button" class="submit" value="全選" onclick="selectAll(this.form);">
                    <input name="Del" type="button" class="submit" value="刪除" onclick="DeleteSelected();">
                    <input name="button2" type="button" class="submit" value="取消全選" onclick="unselectAll(this.form);">
                    --點選以下項目來進行維護
                </td>
                <td class=" txt_r">
                    <input type="button" class="submit3" onclick="window.location = '/About/EditAboutContent/';"
                        value="新增資料">
                    <input type="button" class="submit3 <%=VeriferClass %>" onclick="$('#IsActive').val(0);this.form.submit();"
                        value="待審核">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content h30 txt_c">
                <td class="w20">
                    &nbsp;
                </td>
                <td>
                    類別名稱
                </td>
                <td>
                    系列名稱
                </td>
                <td>
                    單元名稱
                </td>
                <td class="w80">
                    上/下架
                </td>
                <td class="w80">
                    更新日期
                </td>
                <td class="w80">
                    編輯
                </td>
            </tr>
            <%
                foreach (var item in Model)
                {
                    string AboutName = string.Empty;
                    string AboutCategoaryName = string.Empty;
                    var AboutData = About.Where(x => x.AboutId == item.AboutId).FirstOrDefault();
                    if (AboutData != null)
                    {
                        AboutName = AboutData.Category;
                    }
                    var AboutCategoaryData = Categoary.Where(x => x.AboutCategoryId == item.AboutCategoryId).FirstOrDefault();
                    if (AboutCategoaryData != null)
                    {
                        AboutCategoaryName = AboutCategoaryData.Category;
                    }
            %>
            <tr class="top mous01 line-d va_m">
                <td>
                    <input type="checkbox" name="id" value="<%=item.AboutContentId %>" />
                </td>
                <td class="txt_c">
                    <%=AboutName %>
                </td>
                <td>
                    <%=AboutCategoaryName %>
                </td>
                <td>
                    <%=item.UnitName %>
                </td>
                <td class="txt_c">
                    <%=WanFang.Core.MVC.Extensions.UrlExtension.GenerIsActive(item.IsActive, true)%>
                </td>
                <td class="txt_c">
                    <%=item.LastUpdate %>
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="window.location='/About/EditAboutContent/<%=item.AboutContentId %>';"
                        value="編輯">
                    <input name="bt_edit" type="button" class="submit4 <%=VeriferClass %>" onclick="window.location='/About/EditAboutContent/<%=item.AboutContentId %>?Verify=1';"
                        value="審核">
                </td>
            </tr>
            <%
                }
            %>
        </table>
        <br />
        <div class="m_page">
            <% Html.RenderPartial("~/Views/Shared/UserControls/PagingBar.ascx"); %>
        </div>
        <br />
        <span class="red">[注意事項]</span><br />
        1. 每10筆分1頁<br />
        2. 排序：系列順序（由小至大）<br />
        <span class="red">3. 系列底下有對應資料時，該筆不允許刪除</span>
        <!--main end-->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
