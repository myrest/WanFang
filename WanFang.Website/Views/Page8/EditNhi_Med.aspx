<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="Rest.Core.Utility" %>
<%@ Import Namespace="WanFang.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WanFang.Domain.Nhi_Med_Info Model = ViewData["Model"] as WanFang.Domain.Nhi_Med_Info;
        if (Model == null)
        {
            Model = new WanFang.Domain.Nhi_Med_Info();
        }
    %>
    <script>
        function Save() {
            var param = $('#form1 :not([name^=Content])').serialize();
            //var inst = FCKeditorAPI.GetInstance("Content1");
            //param += "&ContentBody" + "=" + encodeURIComponent(inst.GetHTML());

            utility.service("Page8Service/SaveNhi_Med", param, "POST", function (data) {
                if (data.code > 0) {
                    utility.showPopUp("資料已儲存", 1, GoBack);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }

        function GoBack() {
            var redirto = utility.getRedirUrl('Page8', 'Nhi_Med') + '?' + (new Date()).getMilliseconds();
            window.location.href = redirto;
        }
    </script>
    <input type="hidden" name="MedicationID" value="<%=Model.MedicationID %>" />
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                    <div class="tt-r">藥品公告專區管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp健保專區管理&nbsp&#187&nbsp藥品公告專區管理
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
            <table cellspacing="1" cellpadding="2" class="ww100" border="0">
                <tr class="line-d">
                    <td class="line-d0 w150 va_m">中文品名_舊<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="PNameOld" type="text" value="<%=Model.PNameOld%>" size="50"></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">藥品照片_舊 <span class="red">*</span></td>
                    <td>
                                    <%=UrlExtension.PreviewImage(Model.ImageOld, "Nhi_MedImageOld")%>
                    <span class="red">建議尺寸：寬332px，高248px</span></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">院內碼_舊 <span class="red">*</span></td>
                    <td>
                        <input name="PCodeOld" type="text" value="<%=Model.PCodeOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">健保代碼_舊<span class="red">*</span></td>
                    <td>
                        <input name="CodeOld" type="text" value="<%=Model.CodeOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">學品名_舊<span class="red">*</span></td>
                    <td>
                        <input name="ScientificNameOld" type="text" value="<%=Model.ScientificNameOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">商品名/含量_舊<span class="red">*</span></td>
                    <td>
                        <input name="PNameAndNumOld" type="text" value="<%=Model.PNameAndNumOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">藥商名稱 _舊<span class="red">*</span></td>
                    <td>
                        <input name="CompanyNameOld" type="text" value="<%=Model.CompanyNameOld %>" size="20" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">適應症 _舊<span class="red">*</span></td>
                    <td>
                        <input name="SuitOld" type="text" value="<%=Model.SuitOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">用法用量_舊<span class="red">*</span></td>
                    <td>
                        <input name="UsageOld" type="text" value="<%=Model.UsageOld %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">副作用_舊<span class="red">*</span></td>
                    <td>
                        <input name="SideEffectOld" type="text" value="<%=Model.SideEffectOld %>" size="90" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">禁忌及其他注意事項_舊<span class="red">*</span></td>
                    <td>
                        <textarea name="NotificationOld" cols="60" rows="3"><%=Model.NotificationOld %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td valign="middle" class="line-d0">中文品名_新<span class="red">*</span></td>
                    <td class="txt_l">
                        <input name="PName" type="text" value="<%=Model.PName %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">藥品照片_新 <span class="red">*</span></td>
                    <td>
                            <%=UrlExtension.PreviewImage(Model.Image, "Nhi_MedImage")%>
                            <span class="red">建議尺寸：寬332px，高248px</span></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">院內碼_新 <span class="red">*</span></td>
                    <td>
                        <input name="PCode" type="text" value="<%=Model.PCode %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">健保代碼_新<span class="red">*</span></td>
                    <td>
                        <input name="Code" type="text" value="<%=Model.Code %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">學品名_新<span class="red">*</span></td>
                    <td>
                        <input name="ScientificName" type="text" value="<%=Model.ScientificName %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">商品名/含量_新<span class="red">*</span></td>
                    <td>
                        <input name="PNameEng" type="text" value="<%=Model.PNameEng %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">藥商名稱 _新<span class="red">*</span></td>
                    <td>
                        <input name="CompanyName" type="text" value="<%=Model.CompanyName %>" size="20" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">適應症 _新<span class="red">*</span></td>
                    <td>
                        <input name="Suit" type="text" value="<%=Model.Suit %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">用法用量_新<span class="red">*</span></td>
                    <td>
                        <input name="Usage" type="text" value="<%=Model.Usage %>" size="50" /></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">副作用_新<span class="red">*</span></td>
                    <td>
                        <textarea name="SideEffect" cols="60" rows="3"><%=Model.SideEffect %></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">禁忌及其他注意事項_新<span class="red">*</span></td>
                    <td>
                        <textarea name="Notification" cols="60" rows="3"><%=Model.Notification%></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">異動內容<span class="red">*</span></td>
                    <td>
                        <textarea name="ModifiedContent" cols="60" rows="3"><%=Model.ModifiedContent%></textarea></td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">發佈日期<span class="red">*</span></td>
                    <td>
                        <input name="PublishDate" type="text" size="10" value="<%=(Model.PublishDate == DateTime.MinValue)?DateTime.Now.ToString("yyyy/MM/dd"):Model.PublishDate.ToString("yyyy/MM/dd") %>" />
                    </td>
                </tr>
                <tr class="line-d">
                    <td class="line-d0 top">更新日期</td>
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
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
