﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<%@ OutputCache Duration="43200" VaryByParam="None" VaryByCustom="pageurl" Shared="true" %>

<link href="<%= Url.CdnContent("/Plugins/jquery-ui-1.9.2.custom.min.css") %>" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery-1.9.1.min.js") %>"></script>
