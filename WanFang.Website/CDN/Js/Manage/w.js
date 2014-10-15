function showfadeerr(errmsg) {
    $("#msgbox").fadeTo(200, 0.1, function() {
        $(this).html(errmsg).addClass('messageboxerror').fadeTo(900, 1)
    })
}

function displayLoading() {
    $.blockUI({
          message: $('#loading'),
          css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
          }
    });
}

function hiddenLoading() {
    //$(document).ajaxStop($.unblockUI);
    $.unblockUI();
}

function disabledSendButton(thisButtonId)
{
    $('#' + thisButtonId).attr('disabled', true).attr("value", "資料處理中...");
}

function enabledSendButton(thisButtonId)
{
    $('#' + thisButtonId).attr('disabled', false).attr("value", "送出");
}

function showSuccessToast(msg) {
     $().toastmessage('showToast', {
            text     : msg,
            sticky   : false,
            position : 'bottom-left',
            type     : 'success'
     });
}

function showErrorToast(msg) {
    $().toastmessage('showToast', {
            text: msg,
            sticky: false,
            position: 'bottom-left',
            type: 'error'
    });
}

function showNoticeToast(msg) {
    $().toastmessage('showToast', {
        text: msg,
        sticky: false,
        position: 'bottom-left',
        type: 'notice'
    });
}

function showWarningToast(msg) {
    $().toastmessage('showToast', {
        text: msg,
        sticky: false,
        position: 'bottom-left',
        type: 'warning'
    });
}

function performCheck() {
    if (!Page_ClientValidate()) {
        showWarningToast('請檢查必填欄位!');
    }
}

function performCheckSave() {
    if (!Page_ClientValidate()) {
        showWarningToast('請檢查必填欄位!');
    } else {
        displayLoading();
        //$(".btnSave").attr("disabled", true).attr('value', '儲存中...');
        //$("#btnSave").text("儲存中...");
        //$('#btnSave').attr('disabled', 'disabled');
    }
}

function reLoginSystem() {
    window.setTimeout(function () {
        window.location.href = 'logout.aspx';
    }, 2000);
}

function reUrl(url) {
    window.setTimeout(function () {
        window.location.href = url;
    }, 1500);
}

function selectAll() {
    $("input[type='checkbox']").prop('checked', true);
}

function unselectAll() {
    $("input[type='checkbox']").prop('checked', false);
    //$("input[type='checkbox']").removeAttr('checked');
}

function toggleMore() {
    $('#divImgMore').slideToggle();
}

function swapImg(photo, title, slink) {
    var myImg = document.getElementById("main");
    myImg.setAttribute("src", photo);
    myImg.setAttribute("title", title);
    var imglink = document.getElementById("imglink");
    imglink.setAttribute("href", slink);

    if (title.length > 0) {
        var oLi = document.getElementById("tx1");
        oLi.innerHTML = title + "";
    }
}

function bsanet(groupid, ctrlid) {
    $('#' + ctrlid).toggle(function () {
        $('#' + groupid + ' input:checkbox').attr('checked', 'checked');
        $(this).val('取消全選')
    }, function () {
        $('#' + groupid + ' input:checkbox').removeAttr('checked');
        $(this).val('全部選擇');
    })
}

function textCounter(field, countfield, maxlimit) {
    if (field.value.length > maxlimit) {
        field.value = field.value.substring(0, maxlimit);
    } else {
        countfield.value = maxlimit - field.value.length;
    }
}

function NewWindow() {
    document.forms[0].target = "_blank";
}

this.imagePreview = function () {
    xOffset = -30;
    yOffset = -150;

    $("a.preview").hover(function (e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' />" + c + "</p>");
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px")
            .fadeIn("fast");
    },
    function () {
        this.title = this.t;
        $("#preview").remove();
    });
    $("a.preview").mousemove(function (e) {
        $("#preview")
            .css("top", (e.pageY - xOffset) + "px")
            .css("left", (e.pageX + yOffset) + "px");
    });
};

//$(document).ready(function () {
function pageLoad(sender, args) {
    imagePreview();
}
//});
