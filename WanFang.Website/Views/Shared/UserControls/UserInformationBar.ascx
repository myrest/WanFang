<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="WanFang.Core" %>

<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>
<%
    SessionData sessionData = new SessionData();
    if (sessionData != null && sessionData.trading != null)
    {
        string bar = string.Empty;
        string username = (string.IsNullOrEmpty(sessionData.trading.UserName)) ? sessionData.trading.LoginId : sessionData.trading.UserName;
        bar = string.Format("HI，{0} 歡迎回來 我的文章 私人訊息 <a href=\"#\" class=\"logout\">(登出)</a>", username);
        Response.Write(bar);
    }
%>

<script>
    var gv = {
        UserID : <% =ViewData["_UserID"] %>
    }
</script>