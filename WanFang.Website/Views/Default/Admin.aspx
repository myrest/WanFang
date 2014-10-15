<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="WanFang.Core.MVC.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 WanFang
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <!-- link href="<%= Url.CdnContent("/CSS/Login.css") %>" rel="stylesheet" type="text/css" /-->
    <style type="text/css">
        #header0 {
            margin-top: 0px;
            height: 50px;
            z-index: 3;
            visibility: visible;
            opacity: 1;
            background-color: #F2F2F2;
            margin-right: 0px; /* [disabled]margin-left: 0px; */
            position: absolute;
            left: 0px;
            top: 0px;
            right: 0px;
        }

        #headerlogo {
            width: 150px;
            position: static;
            left: 629px;
            top: -5px;
            z-index: 2;
            float: left;
            margin-left: 0px;
        }

        #headerword {
            width: 740px;
            position: absolute;
            font-size: small;
            height: 48px;
            float: right;
            z-index: 1;
            padding-top: 0px;
            margin-left: -370px;
            left: 50%;
        }

        #header0 #head3 {
            width: 400px;
            height: 60px;
        }

        #header0 #body0 {
            height: 450px;
            background-image: url(/pic/back-3.jpg);
            position: absolute;
            z-index: 1;
            border-radius: 20px;
            top: 65px;
            width: 740px;
            margin-left: -370px;
            left: 50%;
            -webkit-box-shadow: 5px 5px 5px;
            box-shadow: 5px 5px 5px;
        }

        #header0 #body1 {
            width: 300px;
            position: absolute;
            left: 466px;
            top: 152px;
            height: 321px;
            z-index: 3;
        }

            #header0 #body1 #body2 {
            }

        #header0 #body2 {
            width: 300px;
            position: absolute;
            left: 780px;
            top: 151px;
            height: 321px;
            z-index: 3;
        }

        #header0 #bottom0 {
            text-align: center;
            margin-top: 10px;
            font-size: small;
            position: absolute;
            left: 50%;
            top: 525px;
            width: 740px;
            margin-left: -370px;
        }

        #header0 #body0 #body3 {
            width: 430px;
            float: left;
            height: 350px;
            font-family: Cambria, "Hoefler Text", "Liberation Serif", Times, "Times New Roman", serif;
            font-size: x-large;
            font-style: normal;
            font-weight: bolder;
            margin-left: 10px;
        }

        #header0 #body0 #body4 {
            width: 300px;
            float: right;
            height: 350px;
        }

        #header0 #body0 #body5 {
            font-family: "Gill Sans", "Gill Sans MT", "Myriad Pro", "DejaVu Sans Condensed", Helvetica, Arial, sans-serif;
            font-size: small;
            color: #FFFFFF;
            height: 25px;
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            padding-top: 8px;
            background-color: #4FA3C7;
            text-align: center;
        }

        #header0 #body0 #body3 #body7 {
            font-weight: normal;
            font-size: small;
            margin-top: -70px;
            margin-left: 30px;
            line-height: 200%;
        }

        #header0 #body0 #body3 #body8 {
            margin-top: -10px;
            padding-top: 0px;
            float: right;
            margin-right: 20px;
            font-size: small;
            text-align: center;
            font-weight: normal;
        }

        #header0 #body0 #body4 #body9 {
            font-size: small;
            padding-left: 0px;
            font-weight: bold;
            border-color: #4FA3C7;
            border-spacing: 1px 1px;
            border-collapse: collapse;
            color: #4FA3C7;
            width: 250px;
            float: right;
        }

        #header0 #headerword #header-word2 {
            width: 540px;
            float: right;
            padding-top: 25px;
            line-height: 120%;
            text-align: right;
        }

        #headeridpass {
            width: 306px;
            position: static;
            font-size: small;
            height: 48px;
            float: right;
            z-index: 1;
            margin-right: -50px;
            margin-top: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="header0">
        <div id="headerword">
            <div id="headerlogo">
                <img src="/pic/logo50x150-3.png" width="150" height="50" alt="" />
            </div>
            <div id="headeridpass">
                帳號
                <label for="username">
                    :</label>
                <input name="username" type="text" id="username" size="20">
                <br>
                密碼
                <label for="password">
                    :</label>
                <input name="password" type="password" id="password" size="20">
                <input type="button" id="btnLogin" value="送出">
            </div>
        </div>
        <p>
            &nbsp;
        </p>
        <div id="body0">
            <div id="body5">
                我們不只是在想，而是在創造。 WanFang means I am not only thinking but also creating.
            </div>
            <p style="float: right; padding-right: 4px; margin-top: 4px;">
                <fb:login-button show-faces="false" width="500" max-rows="5" data-size="small" data-auto-logout-link="false" scope="email"></fb:login-button>
            </p>
            <div id="body3">
                歡迎來到 WanFang。
                <p>
                    &nbsp;
                </p>
                <div id="body7">
                    讓我們一起探索創新思維的世界，從創意中發展出創新元素，再從創新中發掘市場需求，進而打造創業元素。
                </div>
                <div id="body8">
                    <p>
                        <img src="/pic/pc-1.png" width="370" height="193" alt="" />
                    </p>
                    <p>
                        跨平台 PC、Pad、筆電、手持式 智慧手機均可參與討論。
                    </p>
                </div>
                <p>
                    &nbsp;
                </p>
            </div>
            <div id="body4">
                <p>
                    &nbsp;
                </p>
                <p>
                    &nbsp;
                </p>
                <p>
                    &nbsp;
                </p>
            </div>
            <p>
                &nbsp;
            </p>
        </div>
        <div id="bottom0">
            Copyright &copy; 2014 Li-Design 設計與文化創新研究室 關於我們
        </div>
        <p>
            &nbsp;
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/Default/LoginAdmin.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
</asp:Content>