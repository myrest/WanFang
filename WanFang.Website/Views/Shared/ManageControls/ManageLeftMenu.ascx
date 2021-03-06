﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>
<%
    int CurrentMenuNum = (int)ViewData["MenuItem"];
    string[] menus = new string[15];
    menus[CurrentMenuNum] = "Menu_Default";

    bool IsDeptOnly = (bool)ViewData["IsDeptOnly"];

    var Permission = ViewData["Permission"] as List<string>;
    bool Verify = (bool)ViewData["Verify"];
   
%>
<ul id="menu">
    <%if (!IsDeptOnly || Verify)
      {
      %>
    <li class="<%=menus[0] %> <%=(Permission.IndexOf("首頁及時資訊管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">首頁及時資訊管理</a>
        <ul>
            <li><a href="/Page0/EditHomePage">首頁及時資訊管理</a></li>
        </ul>
    </li>
    <!--關於萬芳-->
    <li class="<%=menus[1] %> <%=(Permission.IndexOf("關於萬芳管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">關於萬芳管理</a>
        <ul>
            <li><a href="/About/Index">關於萬芳類別管理</a></li>
            <li><a href="/About/Categoary">關於萬芳系列管理</a></li>
            <li><a href="/About/Content">關於萬芳圖文管理</a></li>
            <li><a href="/About/Team">管理團隊管理</a></li>
            <li><a href="/About/AboutService">服務專區管理</a></li>
        </ul>
    </li>
    <!--最新消息-->
    <li class="<%=menus[2] %> <%=(Permission.IndexOf("最新消息管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">最新消息管理</a>
        <ul>
            <li><a href="/Page2/DiaryData">最新消息項目管理</a></li>
        </ul>
    </li>
    <!--預約查詢系統-->
    <li class="<%=menus[3] %> <%=(Permission.IndexOf("預約及查詢管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">預約及查詢管理</a>
        <ul>
            <li><a href="/Page3/Pilates">其他課程管理</a></li>
        </ul>
    </li>
    <!--就醫指南-->
    <li class="<%=menus[4] %> <%=(Permission.IndexOf("就醫指南管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">就醫指南管理</a>
        <ul>
            <li><a href="/Page4/Guide">就醫指南管理</a></li>
        </ul>
    </li>
    <!--團隊介紹-->
    <li class="<%=menus[5] %> <%=(Permission.IndexOf("團隊介紹管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">團隊介紹管理</a>
        <ul>
            <!-- li><a href="/page5/CostKeyword">科別關鍵字管理</a></!-->
            <li><a href="/page5/TeamIntroduce">團隊介紹管理</a></li>
        </ul>
    </li>
    <!--衛教園區-->
    <li class="<%=menus[6] %> <%=(Permission.IndexOf("衛教園區管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">衛教園區管理</a>
        <ul>
            <li><a href="/Page6/NewsData">醫療衛教管理</a></li>
            <li><a href="/Page6/Edu">健康促進衛教活動管理</a></li>
            <li><a href="/NormallContent/Page6Content">衛教園區圖文管理</a></li>
        </ul>
    </li>
    <!--人員募集-->
    <li class="<%=menus[7] %> <%=(Permission.IndexOf("人員募集管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">人員募集管理</a>
        <ul>
            <li><a href="/Page7/HirCategory">人員募集類別管理</a></li>
            <li><a href="/Page7/HirDetail">人員募集項目管理</a></li>
            <li><a href="/NormallContent/Page7Content">人員募集圖文管理</a></li>
        </ul>
    </li>
    <!--健保專區-->
    <li class="<%=menus[8] %> <%=(Permission.IndexOf("健保專區管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">健保專區管理</a>
        <ul>
            <li><a href="/Page8/Nhi_p">健保專區項目管理</a></li>
            <li><a href="/Page8/Nhi_Med">藥品公告專區管理</a></li>
            <li><a href="/NormallContent/Page8Content">健保專區圖文管理</a></li>
        </ul>
    </li>
    <%
      }

      if (IsDeptOnly)
      {
    %>
    <!--特色醫療-->
    <li class="<%=menus[9] %>"><a href="javascript:void(0);">特色醫療管理</a>
        <ul>
            <li><a href="/Page9/Index">單元管理</a></li>
            <li><a href="/Page9/DownLoad">檔案下載管理</a></li>
            <li><a href="/Page9/News">最新消息管理</a></li>
            <li><a href="/Page6/NewsDataPrivate">醫療衛教管理</a></li>
            <li><a href="/page9/Doc">醫師詳細介紹管理</a></li>
            <li><a href="/page9/CostKeyword">科別關鍵字管理</a></li>
        </ul>
    </li>
    <%
      }

      if (!IsDeptOnly || Verify)
      {
    %>
    <!--詢問台-->
    <li class="<%=menus[10] %> <%=(Permission.IndexOf("詢問台管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">詢問台管理</a>
        <ul>
            <li><a href="/Page10/Op_Qa">就醫問答集管理</a></li>
            <li><a href="/Page10/Question">健康諮詢查詢管理</a></li>
            <li><a href="/Page10/Nhi_Qa">健保部分給付問答集管理</a></li>
        </ul>
    </li>
    <!--表尾資料管理-->
    <li class="<%=menus[11] %> <%=(Permission.IndexOf("表尾資料管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">表尾資料管理</a>
        <ul>
            <li><a href="/Page11/EditFooter">表尾資料管理</a></li>
        </ul>
    </li>
    <!--員工帳號管理-->
    <li class="<%=menus[12] %> <%=(Permission.IndexOf("員工帳號管理") > -1) ? "" : "hide" %>"><a href="javascript:void(0);">員工帳號管理</a>
        <ul>
            <li><a href="/Manage/UserListing">員工帳號管理</a></li>
        </ul>
    </li>
    <%
      }
    %>
    <!--報表-->
    <li class="<%=menus[14] %>"><a href="javascript:void(0);">報表</a>
        <ul>
            <li><a href="/Page14/Report">網站流瀏覽記錄</a></li>
        </ul>
    </li>
    <!--密碼變更-->
    <li class="<%=menus[13] %>"><a href="javascript:void(0);">密碼變更</a>
        <ul>
            <li><a href="/Manage/ChangePassword">密碼變更</a></li>
        </ul>
    </li>
    <!--登出-->
    <li><a href="javascript:void(0);" onclick="javascript:utility.logout();" class="">登出</a></li>
    <!--登出到首頁-->
    <li><a href="javascript:void(0);" onclick="javascript:utility.logoutToHomePage();" class="">登出至首頁</a></li>
</ul>
