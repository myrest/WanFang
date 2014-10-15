$(function () {
    User.init();
    Utils.textBoxsOnEnter(User._User, $('#mainpage input'));
    $("#btnUser").click(User._User);
});

var User =
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
    _User: function () {
        var id = $("#UserId").val();
        var pwd = $("#Password").val();

        if (id.length === 0) {
            utility.showPopUp('請輸入帳號', 1, function () { $("#UserId").focus(); });
        }
        else if (pwd.length === 0) {
            utility.showPopUp('請輸入密碼', 1, function () { $("#Password").focus(); });
        }
        else {
            var param = $('#form1').serialize();
            utility.service("ManageUserService/User", param, "POST", function (data) {
                if (data.code > 0) {
                    var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                    window.location.href = redirto;
                } else {
                    utility.showPopUp(data.msg, 1, function () { $("#UserId").focus(); });
                }
            });
        }
    }
};