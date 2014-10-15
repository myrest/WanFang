<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--new 後臺員工帳號專區-->
    <div id="title">
        <div class="float-l">
            <h1>
                <div class="float-l">
                    <img src="/CDN/Images/Manage/title-left.jpg" /></div>
                <div class="tt-r">
                    員工帳號管理</div>
            </h1>
        </div>
        <div id="nav" class="txt_r">
            <img src="/CDN/Images/Manage/icon01.gif" hspace="5" border="0" align="absmiddle"><a
                href="login.aspx">後端管理系統</a>&nbsp&#187&nbsp員工帳號管理</div>
        <p class="clear">
        </p>
    </div>
    <div id="mainpage">
        <!--main begin-->
        <div class="bg-s">
            <p>
                關鍵字：
                <input name="Keywords" type="text" placeholder="請輸入帳號搜尋" />
                <input type="submit" class="submit" value="搜尋" id="Search" />
            </p>
        </div>
        <table class="ww100 magTop10" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <input type="button" class="submit" value="全選" onclick="selectAll(this.form);">
                    <input type="button" class="submit" value="刪除" onclick="delSelect(this.form);">
                    <input type="button" class="submit" value="取消全選" onclick="unselectAll(this.form);">
                    --點選以下項目來進行維護
                </td>
                <td class=" txt_r">
                    <input id="Add" type="button" class="submit3" value="新增資料" onclick="User.AddNew">
                </td>
            </tr>
        </table>
        <table class="ww100" border="0" cellpadding="2" cellspacing="1">
            <tr class="form-content txt_c h30">
                <td class="w20">
                    &nbsp;
                </td>
                <td>
                    管理者名稱
                </td>
                <td>
                    登入帳號
                </td>
                <td>
                    門診
                </td>
                <td>
                    科別
                </td>
                <td>
                    權限名稱
                </td>
                <td class="w80">
                    更新日期
                </td>
                <td class="w70">
                    編輯
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="va_m">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工1
                </td>
                <td class="txt_c">
                    test1
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td>
                    首頁及時資訊管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯">
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工2
                </td>
                <td class="txt_c">
                    test2
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td>
                    最新消息管理,預約及查詢管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工3
                </td>
                <td class="txt_c">
                    test3
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td>
                    最新消息管理,預約及查詢管理,團隊介紹管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工4
                </td>
                <td class="txt_c">
                    test4
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td>
                    最新消息管理,預約及查詢管理,就醫指南管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工5
                </td>
                <td class="txt_c">
                    test5
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td class="txt_c">
                    &nbsp;
                </td>
                <td>
                    最新消息管理,預約及查詢管理,就醫指南管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工6
                </td>
                <td class="txt_c">
                    test6
                </td>
                <td class="txt_c">
                    內科
                </td>
                <td class="txt_c">
                    消化內科
                </td>
                <td>
                    特色醫療管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工7
                </td>
                <td class="txt_c">
                    test7
                </td>
                <td class="txt_c">
                    內科
                </td>
                <td class="txt_c">
                    腎臟內科
                </td>
                <td>
                    特色醫療管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工8
                </td>
                <td class="txt_c">
                    test8
                </td>
                <td class="txt_c">
                    內科
                </td>
                <td class="txt_c">
                    胸腔內科
                </td>
                <td>
                    特色醫療管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工9
                </td>
                <td class="txt_c">
                    test9
                </td>
                <td class="txt_c">
                    內科
                </td>
                <td class="txt_c">
                    神經內科
                </td>
                <td>
                    特色醫療管理
                </td>
                <td class="txt_c">
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
            <tr class="line-d top va_m mous01">
                <td class="txt_c">
                    <input type="checkbox" name="nid" id="nid" />
                </td>
                <td class="txt_c">
                    員工10
                </td>
                <td class="txt_c">
                    test10
                </td>
                <td class="txt_c">
                    內科
                </td>
                <td class="txt_c">
                    心臟內科
                </td>
                <td>
                    特色醫療管理
                </td>
                <td>
                    2014/09/26
                </td>
                <td class="txt_c">
                    <input name="bt_edit" type="button" class="submit" onclick="javascript: window.location = 'L1-1a.aspx';"
                        value="編輯" />
                </td>
            </tr>
        </table>
        <br />
        <div class="m_page">
            <!-- &nbsp;<a href="#">&nbsp;第一頁&nbsp;</a> -->
            &nbsp;<a href="#">&#171;上一頁</a>&nbsp;<span class="on">&nbsp;1&nbsp;</span>&nbsp;<a
                href="#">&nbsp;2&nbsp;</a> <a href="#">&nbsp;3&nbsp;</a>&nbsp;<a href="#">&nbsp;4&nbsp;</a>&nbsp;<a
                    href="#">&nbsp;5&nbsp;</a>&nbsp;<a href="#">&nbsp;6&nbsp;</a>&nbsp;<a href="#">&nbsp;7&nbsp;</a>&nbsp;<a
                        href="#">&nbsp;8&nbsp;</a>&nbsp;<a href="#">&nbsp;9&nbsp;</a>&nbsp;<a href="#">&nbsp;10&nbsp;</a>&nbsp;<a
                            href="#">下一頁&#187;</a>&nbsp;<!-- <a href="#">&nbsp;最後一頁&nbsp;</a> -->
            1/12</div>
        <br />
        <span class="red">[注意事項]</span><br />
        1. 每10筆分1頁<br />
        2. 排序：帳號（由小至大）<br />
        <!--main end-->
    </div>
    <!--new 後臺員工帳號專區-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
