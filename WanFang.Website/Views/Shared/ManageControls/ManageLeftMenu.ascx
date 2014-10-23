<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>
<%
    int CurrentMenuNum = (int)ViewData["MenuItem"];
    string[] menus = new string[14];
    menus[CurrentMenuNum] = "Menu_Default";
    
%>
<ul id="menu">
    <li class="<%=menus[0] %>"><a href="m1-1.aspx">首頁及時資訊管理</a>
        <ul>
            <li><a href="m1-1.aspx">首頁及時資訊管理</a></li></ul>
    </li>
    <!--關於萬芳-->
    <li class="<%=menus[1] %>"><a href="#">關於萬芳管理</a>
        <ul>
            <li><a href="m2-1.aspx">關於萬芳管理</a>
                <li class="menu_s"><a href="/About/Index">關於萬芳類別管理</a></li>
                <li class="menu_s"><a href="m2-12.aspx">關於萬芳系列管理</a></li>
                <li class="menu_s"><a href="m2-13.aspx">關於萬芳圖文管理</a></li>
            </li>
            <li><a href="m2-2.aspx">管理團隊管理</a></li>
            <li><a href="m2-3.aspx">服務專區管理</a></li>
        </ul>
    </li>
    <!--最新消息-->
    <li class="<%=menus[2] %>"><a href="m3-1.aspx">最新消息管理</a>
        <ul>
            <!--<li><a href="m3-1.aspx">最新消息類別管理</a></li>-->
            <li><a href="m3-2.aspx">最新消息項目管理</a></li>
        </ul>
    </li>
    <!--預約查詢系統-->
    <li class="<%=menus[3] %>"><a href="m4-1.aspx">預約及查詢管理</a>
        <ul>
            <li><a href="m4-1.aspx">其他課程管理</a></li>
            <!--<li><a href="m4-2.aspx">報名管理</a></li>-->
        </ul>
    </li>
    <!--就醫指南-->
    <li class="<%=menus[4] %>"><a href="m5-1.aspx">就醫指南管理</a>
        <ul>
            <li><a href="m5-1.aspx">就醫指南管理</a></li></ul>
    </li>
    <!--團隊介紹-->
    <li class="<%=menus[5] %>"><a href="m6-1.aspx">團隊介紹管理</a>
        <ul>
            <li><a href="m6-1.aspx">科別關鍵字管理</a></li>
            <li><a href="m6-2.aspx">醫師詳細介紹管理</a></li>
        </ul>
    </li>
    <!--衛教園區-->
    <li class="<%=menus[6] %>"><a href="m7-1.aspx">衛教園區管理</a>
        <ul>
            <li><a href="m7-1.aspx">醫療衛教管理</a></li>
            <li><a href="m7-2.aspx">健康促進衛教活動管理</a></li>
        </ul>
    </li>
    <!--人員募集-->
    <li class="<%=menus[7] %>"><a href="m8-1.aspx">人員募集管理</a>
        <ul>
            <li><a href="m8-2.aspx">人員募集類別管理</a></li><li><a href="m8-1.aspx">人員募集項目管理</a></li></ul>
    </li>
    <!--健保專區-->
    <li class="<%=menus[8] %>"><a href="m9-1.aspx">健保專區管理</a>
        <ul>
            <li><a href="m9-1.aspx">塗藥支架給付專區管理</a></li>
            <li><a href="m9-2.aspx">藥品公告專區管理</a></li>
        </ul>
    </li>
    <!--特色醫療-->
    <li class="<%=menus[9] %>"><a href="m10-1.aspx">特色醫療管理</a>
        <ul>
            <li><a href="m10-1.aspx">單元管理</a></li>
            <li><a href="m10-2.aspx">檔案下載管理</a></li>
            <li><a href="m10-3.aspx">最新消息管理</a></li>
        </ul>
    </li>
    <!--尋問台-->
    <li class="<%=menus[10] %>"><a href="m11-1.aspx">詢問台管理</a>
        <ul>
            <li><a href="m11-1.aspx">就醫問答集管理</a></li>
            <li><a href="m11-2.aspx">健康諮詢查詢管理</a></li>
            <li><a href="m11-3.aspx">健保部分給付問答集管理</a></li>
        </ul>
    </li>
    <!--表尾資料管理-->
    <li class="<%=menus[11] %>"><a href="m12-1.aspx">表尾資料管理</a>
        <ul>
            <li><a href="m12-1.aspx">表尾資料管理</a></li></ul>
    </li>
    <!--員工帳號管理-->
    <li class="<%=menus[12] %>"><a href="#">員工帳號管理</a>
        <ul>
            <li><a href="/Manage/UserListing">員工帳號管理</a></li></ul>
    </li>
    <!--密碼變更-->
    <li class="<%=menus[13] %>"><a href="L2-1.aspx">密碼變更</a>
        <ul>
            <li><a href="L2-1.aspx">密碼變更</a></li></ul>
    </li>
    <!--登出-->
    <li><a href="index.aspx" class="">登出</a></li>
    <!--登出到首頁-->
    <li><a href="../index.aspx" class="">登出至首頁</a></li>
</ul>
