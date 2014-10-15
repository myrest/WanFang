<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" AutoEventWireup="true" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ Import Namespace="WanFang.Domain" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>萬芳醫院後端系統</title>
<link href="<%= Url.CdnContent("/Plugins/jquery-ui-1.9.2.custom.min.css") %>" rel="stylesheet" type="text/css" />
<link type="text/css" href="/CDN/css/style.css" rel="stylesheet" />
<link href="<%= Url.CdnContent("/CSS/Reset.css") %>" rel="stylesheet" type="text/css" />
<link href="<%= Url.CdnContent("/CSS/common.css") %>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1">
    <div id="wrapper">
        <div id="inside1" class="index_page">
            <div>
                <div class="index_line">
                    <img src="/CDN/Images/Manage/manage-top.jpg" />
                    <div id="title" class="index_pad">
                        <div class="float-l">
                            <h1>
                                <div class="float-l">
                                    <img src="/CDN/Images/Manage/title-left.jpg" />
                                </div>
                                <div class="tt-r">
                                    後端管理系統</div>
                            </h1>
                        </div>
                    </div>
                    <div id="mainpage">
                        <div class="ligin">
                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                <tr align="center">
                                    <td>
                                        <table border="0" align="center" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td align="right" nowrap="nowrap" class="menu-black">
                                                    帳號：
                                                </td>
                                                <td height="20" align="left">
                                                    <input name="LoginId" type="text" class="wd100" id="LoginId" maxlength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap" class="menu-black">
                                                    密碼：
                                                </td>
                                                <td height="20" align="left">
                                                    <input name="Password" type="password" class="wd100" id="Password" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap" class="menu-black">
                                                    &nbsp;
                                                </td>
                                                <td height="20" align="left">
                                                    <a href="#" id="btnLogin">
                                                        <img src="/CDN/Images/Manage/button-login.jpg" width="114" height="34" border="0" /></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--mainpage end-->
                    </div>
                    <!-- index_line-->
                </div>
                <!--contentpage end-->
            </div>
            <!--inside1 end-->
        </div>
    </div>
    ﻿<div id="footer">
        <div id="copyright">
            &copy;台北市立萬芳醫院版權所有 最佳瀏覽IE10以上 Designed by <a href="http://www.tsg.com.tw" target="_blank">
                T.S.G</a> &nbsp;
        </div>
        <!--footer end-->
    </div>
    </form>
    <div id="dialog">
    </div>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery-1.9.1.min.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery-ui-1.9.2.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/json2.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/Common.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/Default/Login.js") %>"></script>
</body>
</html>
