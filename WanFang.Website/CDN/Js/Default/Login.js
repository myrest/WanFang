var HomeControl = 'Manage';
var HomeAction = 'Index';

$(function () {
    if (top.location != self.location) {
        top.location = self.location;
    } else {
        login.init();
        Utils.textBoxsOnEnter(login._login, $('#mainpage input'));
        $("#btnLogin").click(login._login);
        $("#LoginId").focus();
    }
});

var login =
{
    init: function () {
        $("#dialog-message").dialog({
            autoOpen: true,
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
    },
    _login: function () {
        var id = $("#LoginId").val();
        var pwd = $("#Password").val();

        if (id.length === 0) {
            utility.showPopUp('請輸入帳號', 1, function () { $("#LoginId").focus(); });
        }
        else if (pwd.length === 0) {
            utility.showPopUp('請輸入密碼', 1, function () { $("#Password").focus(); });
        }
        else {
            var param = $('#form1').serialize();
            utility.service("ManageLoginService/Login", param, "POST", function (data) {
                if (data.code > 0) {
                    var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                    window.location.href = redirto;
                } else {
                    utility.showPopUp(data.msg, 1, function () { $("#LoginId").focus(); });
                }
            });
        }
    }
};