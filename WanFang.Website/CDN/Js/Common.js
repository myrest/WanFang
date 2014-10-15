/// <reference path="lib/jquery-1.4.4-vsdoc.js" />
var ClockTimeout = 60;
var utility = {
    stopRequest: false,
    templateCache: new Object()
    , template: function (templateUrl, callBack, key) {
        var templateObj;
        if (key) {
            templateObj = this.templateCache[key];
            if (templateObj) {
                callBack(templateObj);
                return;
            } else {
                var version;
                var fileUrl = "/CDN/Templates/" + templateUrl;
                $.ajax({
                    url: fileUrl
                        , cache: true
                        , type: "GET"
                        , success: function (response) {
                            templateObj = TrimPath.parseTemplate(response);
                            response = null;
                            utility.templateCache[key] = templateObj;
                            callBack(templateObj);
                        }
                });
            }
        } else {
            return;
        }
    },
    getRedirUrl: function (controller, action, para) {
        var url;
        if (para !== undefined) {
            if (para.toString().indexOf('?', 0) !== 0) { para = '?' + para };
        } else {
            para = '';
        }
        if (action === undefined) {
            url = '/' + controller;
        } else {
            url = '/' + controller + '/' + action + para;
        }
        return url;
    }
    , ecb: function (data) {
        utility.showPopUp(data.msg, 1);
    }
    , service: function (mvcUrl, parameter, httpMethod, callBack, errorCallback, responseDataType) {
        if (mvcUrl.indexOf('http') != 0) {
            mvcUrl = '/' + mvcUrl;
        }
        if (utility.stopRequest) {
            return;
        } else {
            utility.stopRequest = true;
        }

        $("#loading").remove();
        $('<div id="loading" class="loading" />').appendTo($('body'));
        var paramObj = {
            url: mvcUrl,
            cache: false,
            data: parameter,
            type: httpMethod,
            traditional: true,
            dataType: "json",
            success: function (response) {
                if (response.sysCode == undefined) {
                    if (callBack) {
                        callBack(response);
                    }
                } else {
                    var rd = '/';
                    switch (response.sysCode) {
                        case 100:
                            alert('Got System Error [SessionLost]');
                            break;
                        case 200:
                            alert('Got System Error [SystemKickOut]');
                            break;
                        case 300:
                            alert('Got System Error');
                            break;
                        case 400:
                            alert('You do not have the permission.');
                            rd = '';
                            break;
                        default:
                            alert('Got System Error [Unknow]');
                            break;
                    }
                    window.location = rd;
                }
            },
            error: function (response) {
                if (errorCallback) {
                    errorCallback(response);
                } else {
                    if (typeof (response) != 'object') {
                        alert('Got Error [ ' + response + ']');
                    } else {
                        alert('[ ' + paramObj.url + ' ] status code [ ' + response.status + ']');
                    }
                }
            },
            complete: function () {
                $("#loading").remove();
                utility.stopRequest = false;
            }
        };

        if (responseDataType) {
            var dataTypeObj = { dataType: responseDataType };
            $.extend(paramObj, dataTypeObj);
        }

        $.ajax(paramObj);
    }
    , ajaxQuiet: function (mvcUrl, parameter, callBack, errCallBack) {
        var cb = function (data) {
            if (callBack) {
                callBack(data);
            }
        };
        var ecb = function (data) {
            if (errCallBack) {
                errCallBack(data);
            }
        }
        utility.service(mvcUrl, parameter, 'POST', function (data) {
            utility.stopRequest = false;
            if (data.code > 0) {
                cb(data);
            } else {
                ecb(data);
            }
        });
    }
    , parseToJson: function (jsonString) {
        if (jsonString === "" || jsonString === null)
            return {};
        var cdata;
        return eval("cdata =" + jsonString);
    }
    , stringifyJson: function (jsonObj) {
        var sstr = [];
        var hasAttr = false;
        sstr.push("{");
        for (var attr in jsonObj) {
            if (jsonObj[attr] && jsonObj[attr].length > 0) {
                hasAttr = true;
                sstr.push(attr);
                sstr.push(":[");
                sstr.push(jsonObj[attr].join(","));
                sstr.push("]");
                sstr.push(",");
            }
        }
        if (hasAttr)
            sstr.pop();
        sstr.push("}");
        return sstr.join("");
    }
    , jsonToString: function (obj) {
        switch (typeof (obj)) {
            case 'string':
                return '"' + obj.replace(/(["\\])/g, '\\$1') + '"';

            case 'array':
                return '[' + obj.map(utility.jsonToString).join(',') + ']';

            case 'object':
                if (obj instanceof Array) {
                    var strArr = [];
                    var len = obj.length;
                    for (var i = 0; i < len; i++) strArr.push(utility.jsonToString(obj[i]));
                    return '[' + strArr.join(',') + ']';
                } else if (obj == null) {
                    return 'null';
                } else {
                    var string = [];
                    for (var property in obj) string.push(utility.jsonToString(property) + ':' + utility.jsonToString(obj[property]));
                    return '{' + string.join(',') + '}';
                }

            case 'number':
                return obj;

            default:
                return obj;
        }
    }
    , showPopUp: function (message, itype, fun, clfun) {
        $('#dialog').html(message);
        var btn = new Object();
        var i = parseInt(itype, 10);
        var clsedialog = function () { $(this).dialog("close"); };
        var callback, closeCallBack;
        if (!$.isFunction(fun)) {
            callback = clsedialog;
        } else {
            callback = function () {
                fun();
                $(this).dialog("close");
            }
        }

        if (!$.isFunction(clfun)) {
            closeCallBack = clsedialog;
        } else {
            closeCallBack = function () {
                clfun();
                $(this).dialog("close");
            }
        }

        switch (i) {
            case 1: //close
                btn['關閉'] = callback;
                break;
            case 2: //ok
                btn['確定'] = callback;
                break;
            case 3: //ok or close
                btn['取消'] = closeCallBack;
                btn['確定'] = callback;
                break;
            default:
                btn['關閉'] = closeCallBack;
                break;
        }

        $('#dialog').dialog({
            autoOpen: true,
            dialogClass: 'dialogwithouttitle',
            resizable: false,
            closeOnEscape: true,
            modal: true,
            position: ['center', 100],
            buttons: btn
        });
    }
   , popupUrl: function (url, title, id, w, h, scrolling) {
       if (!scrolling) { scrolling = "no"; }
       if (!id) { id = "popupIframe"; }
       if (!title) { title = '&nbsp;'; }
       var iframe = $("#" + id);
       if (iframe.length > 0) iframe.remove();
       var obj = '<div id="popup-div" class="ui-corner-all" style="width:' + w + 'px; height:' + h + 'px;"></div>';
       var $popDiv = $(obj);
       $popDiv.html('<a href="javascript:void(0);" title="Close" id="closeIframe" class="ui-icon ui-icon-close MsgCloseIcon"></a><span class="ui-corner-all title">' + title + '</span><iframe id="' + id + '" allowtransparency="true" marginWidth="0" marginHeight="0" frameBorder="0" scrolling="' + scrolling + ' width="100%" height="100%" />');
       $("body").append("<div class=\"action-popup-cover\"></div>").append($popDiv);
       $("#popup-div").center('3');

       $("#" + id).attr("src", url);
       $('#closeIframe').unbind('click').click(utility.closePopUpUrl);
       $("#loading").remove();
   }
    , closePopUpUrl: function () {
        window.parent.$("div.action-popup-cover").remove();
        window.parent.$("div#popup-div").remove();
    }
    , closePopUpUrlConfirm: function (needConrim) {
        if (needConrim) {
            if (confirm("Are you want close this form?")) {
                utility.closePopUpUrl();
            }
        } else {
            utility.closePopUpUrl();
        }
    }
    , parseToSizeInfo: function (css) {
        var classvalues = css.split(' ');
        var id, w = -1, h = -1, s, r;
        for (var i = 0; i < classvalues.length; i++) {
            switch (String(classvalues[i]).toLowerCase().charAt(0)) {
                case "w": w = parseInt(String(classvalues[i]).substr(1)); break;
                case "h": h = parseInt(String(classvalues[i]).substr(1)); break;
                case "i": id = String(classvalues[i]).substr(1); break;
                case "s": s = String(classvalues[i]).substr(1); break;
                case "r": r = String(classvalues[i]).substr(1); break; // values in "yes" or "no"
            }
        }
        w = (w < 310) ? 310 : w;
        if (typeof (s) == 'undefined' || s.toLowerCase() != "no") s = 'yes';
        if (typeof (r) == 'undefined' || r.toLowerCase() != "yes") r = 'no';
        if (isNaN(w) || isNaN(h)) { Control.Dialog.showAlert(global.tLogin, "Error:" + css, function () { }); }
        return { 'id': id, 'width': w, 'height': h, 'scroll': s, resizable: r };
    }
    , pars2Numic: function (x) {
        return isNaN(x) ? 0 : x;
    }
    , getSelection: function () {
        if (window.getSelection) {
            return window.getSelection();
        } else if (document.getSelection) {
            return document.getSelection();
        } else {
            return document.selection.createRange().text;
        };
    }
    , logout: function () {
        var cb = function () { window.parent.location = '/'; }
        utility.ajaxQuiet("LoginService/Logout", null, cb);
    }
    , CheckOnFocus: function () {//設定欄位初始值
        var $this = $(this);
        if ($this.attr('defaultValue').trim() == $this.val().trim()) {
            $this.val('');
        }
    }, SetAsDefault: function ($obj) {
        if ($obj.length > 0) {
            //$this.val($this.attr('defaultValue'));
            $obj.find('input[defaultValue], textarea[defaultValue]').each(
                function () {
                    var $this = $(this);
                    var defval = $this.attr('defaultValue');
                    if (defval == undefined) {
                        $this.val('');
                    } else {
                        $this.val(defval);
                    }
                }
            );
        } else {
            var $this = $(this);
            if ($this.val() == '') {
                $this.val($this.attr('defaultValue'));
            }
        }
    }, CancleUpdate: function () {
        var $this = $(this);
        var $table = $this.closest('table');
        $table.find('input:text, textarea').each(
            function () {
                var $this = $(this);
                var defval = $this.attr('defaultValue');
                if (defval == undefined) {
                    $this.val('');
                } else {
                    $this.val(defval);
                }
            }
        );
        $table.find('[name="savebtn"]').show();
        $table.find('[name="updatebtn"]').hide();
        $table.find('[name="cancle"]').hide();
    }, ShowNotice: function ($obj) {
        $obj.show(500);
        setTimeout(function () {
            $obj.hide(500);
        }, 3000);
    }
};

Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
                (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
                    RegExp.$1.length == 1 ? o[k] :
             ("00" + o[k]).substr(("" + o[k]).length));
    return format;
};

var KeyPressHelper = {
    getCode: function (e) {
        return e.keyCode ? e.keyCode : e.which;
    },

    // allow backspace, tab, delete, enter, numbers and keypad numbers, arrows
    isNumeric: function (e) {
        if (e.shiftKey) return false; // to prevent shift key combination

        var code = this.getCode(e);
        return (code == 8 || code == 110 || code == 190 ||
        code == 9 ||
        code == 46 ||
        code == 13 ||
        code >= 48 && code <= 57 ||
        code >= 96 && code <= 105 ||
        code >= 37 && code <= 40);
    },

    isEnter: function (e) {
        if (this.getCode(e) == 13) return true;
        else return false;
    }
};

var Utils = {
    textBoxsOnEnter: function (onEnter, filter) {
        if (onEnter && $.isFunction(onEnter)) {
            var inputs = $;
            if (filter) inputs = $(filter);
            else inputs = $("input:text,input:password");

            inputs.keypress(function (e) {
                var code;
                if (!e) var e = window.event;
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                if (code == 13) {
                    onEnter(this);
                    e.cancelBubble = true;
                    if (e.stopPropagation) {
                        e.preventDefault();
                        e.stopPropagation();
                    }
                }
            });
        }
    },
    textBoxOnESC: function (onEsc, filter) {
        if (onEsc && $.isFunction(onEsc)) {
            var inputs = $;
            if (filter) inputs = $(filter);
            else inputs = $(document);
            inputs.unbind('keyup');
            inputs.unbind('keyup').keyup(function (e) {
                var code;
                if (!e) var e = window.event;
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                if (code == 27) {
                    onEsc();
                    e.cancelBubble = true;
                    if (e.stopPropagation) {
                        e.preventDefault();
                        e.stopPropagation();
                    }
                }
            });
        }
    }
};

var PageInitial = {
    InitialPopupDiv: function () {
        $("a.popup-div").unbind('click').click(function (event) {
            var info = utility.parseToSizeInfo(this.className);
            utility.popupUrl(this.href, this.title, info.id, info.width, info.height);
            return false;
        });
    },
    InitialActionBtn: function () {
        $("a.lis-tab-butt").unbind('click').click(function () {
            $(".listing-table  > li > ul").hide();
            var offset = $(this).offset();
            var subtop = offset.top + 16;
            $(this).parent().find("ul.actions-list")
            .fadeIn().css({ "top": subtop, "left": offset.left })
            .unbind().click(function () { $(this).hide(); })
            .mouseleave(function () { $(this).hide(); });
        });
    },
    InitialCancelCloseBtn: function () {
        $("a.button-close,a.button-cancel").unbind('click').click(function () {
            utility.closePopUpUrl();
        });
    },
    InitialPopupAnchor: function () {
        this.InitialPopupDiv();
        this.InitialActionBtn();
        this.InitialCancelCloseBtn();
    }
}

//JQuery extantion start.
jQuery.fn.center = function (x) {
    var pers;
    pers = parseInt(x, 10);
    if (pers === NaN) {
        pers = 2;
    }
    this.css("position", "absolute");
    this.css("top", parseInt((($(window).height() - this.outerHeight()) / pers) + $(window).scrollTop(), 10) + "px");
    this.css("left", parseInt((($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft(), 10) + "px");
    this.css("visibility", "visible");
    this.css("display", "inline-block");
    return this;
};
//Extantion end.

var ErrorHelper = {
    hasError: false
    , ErrorMsg: ""
    , FirstObj: undefined
    , init: function () {
        this.hasError = false;
        this.ErrorMsg = "";
        this.FirstObj = undefined;
    }
    , checkNonNull: function (data, msg) {
        if (data.length > 0) {
            if (data.val().length === 0) {
                this.ErrorMsg += msg + "<Br>";
                if (this.FirstObj == undefined) {
                    this.FirstObj = data;
                }
                this.hasError = true;
            }
        } else {
            alert('Some Element not exist in checkNonNull');
        }
    }
    , checkIsEq: function (dataA, dataB, msg) {
        var blA = dataA.length > 0;
        var blB = dataB.length > 0;
        if (blA && blB) {
            if (dataA.val() != dataB.val()) {
                this.ErrorMsg += msg + "<Br>";
                if (this.FirstObj == undefined) {
                    this.FirstObj = dataA;
                }
                this.hasError = true;
            }
        } else {
            alert('Some Element not exist in checkIsEq');
        }
    }
    , setError: function (msg, obj) {
        this.ErrorMsg += msg + "<Br>";
        this.hasError = true;
        if (this.FirstObj == undefined) {
            this.FirstObj = obj;
        }
    }
    , popUpIfError: function () {
        var _hasError = this.hasError;
        if (this.hasError) {
            utility.showPopUp(this.ErrorMsg, 1, function () { ErrorHelper.FirstObj[0].focus(); ErrorHelper.init(); });
        }
        return _hasError;
    }
    , ErrorNotice: function ($obj, msg) {
        var Offset = $obj.offset();
        var ErrorNotice = '<span class="ErrorNotice">' + msg + '</span>';
        $('body').after(ErrorNotice);
        $('.ErrorNotice').css('top', Offset.top + 2);
        $('.ErrorNotice').css('left', Offset.left + 2);
        $('.ErrorNotice').fadeOut(2000, function () { $(this).remove(); });
    }
}

$(function () {
    PageInitial.InitialPopupAnchor();
    $('.ui-state-default').on({
        mouseenter: function () { $(this).addClass('ui-state-hover'); },
        mouseleave: function () { $(this).removeClass('ui-state-hover'); }
    });
    //#region Trim to remove extra space
    $(document).on("blur", "input:text", function () {
        $(this).val($.trim($(this).val()));
    });
    $(document).on("blur", "textarea", function () {
        $(this).val($.trim($(this).val().replace(/[ | ]*\n/g, '\n')));
    });
    //#endregion

    //#region binding default event.
    $('input[defaultValue], textarea[defaultValue]').on('focus', utility.CheckOnFocus).on('blur', utility.SetAsDefault).each(
    function () {
        $(this).val($(this).attr('defaultValue'))
    }
    );
    //#endregion

    //#region Highlight textbox / drop down if value changed
    $("input:text.highlight-if-change,select.highlight-if-change,textarea.highlight-if-change").each(function () {
        $(this).attr("orig-val", $(this).val()); // assign original value to "orig-val" attribute
    });

    $(document).on("keyup", "input:text[orig-val],select[orig-val],textarea[orig-val]", function () { // all input text box and drop down contains orig-val attribute
        var $this = $(this);
        var origValue = $this.attr("orig-val");
        var currValue = $this.val();
        if (origValue != currValue) { // check if value is different
            $this.addClass("val-changed"); // add class if remove
        }
        else {
            $this.removeClass("val-changed"); // remove class if same
        }
    });

    $(document).on("blur", "input:text[orig-val],select[orig-val],textarea[orig-val]", function () { // all input text box and drop down contains orig-val attribute
        var $this = $(this);
        var origValue = $this.attr("orig-val");
        var currValue = $this.val();

        if (origValue != currValue) { // check if value is different
            $this.addClass("val-changed"); // add class if remove
        }
        else {
            $this.removeClass("val-changed"); // remove class if same
        }
    });
    //#endregion

    //#region Uppercase/LowerCase textbox value
    $(document).on("keyup", "input:text.uppercase", function () {
        if (utility.getSelection() != '') return;
        $(this).val($(this).val().toUpperCase());
    });
    $(document).on("keyup", "input:text.lowercase", function () {
        if (utility.getSelection() != '') return;
        $(this).val($(this).val().toLowerCase());
    });
    //#endregion

    //#region Limit input box max length

    //#endregion //Format number and check integer and decimal input
    $(document).on("keyup", "input:text[extMaxLength], textarea[extMaxLength]", function (event) {
        var $this = $(this);
        var value = $this.val();
        var valueLength = value.replace(/[\r\n]/g, '').length;
        var diff = (value.replace(/[\r\n]/g, '@@').length - valueLength) / 2;
        var maxlength = parseInt($this.attr('extMaxLength'), 10);
        if (!isNaN(maxlength)) {
            if (valueLength > maxlength) {
                $this.val($this.val().substr(0, maxlength + diff));
                ErrorHelper.ErrorNotice($this, '字數限制：' + maxlength + '字');
            }
        }
    });
    //#region Format number and check integer and decimal input

    $(document).on("keydown", "input:text.decimal,input:text.decimal-format,input:text.decimal-1,input:text.decimal-2,input:text.decimal-3", function (event) {
        //alert(event.keyCode);
        var $this = $(this);
        var value = $this.val();

        // Allow: dot and only 1 dot is allowed, first character cannot be dot
        if (event.keyCode == 110 || event.keyCode == 190) {
            if (value.indexOf(".") != -1 || value == "") {
                event.preventDefault();
            }
            else {
                return;
            }
        }
        // Not allow shift to prevent @!$#%^&
        else if (event.shiftKey === true && event.keyCode >= 48 && event.keyCode <= 57) {
            event.preventDefault();
        }
        // Not allow enter 0 if textbox is empty
        else if ($this.val() == "" && (event.keyCode == 48 || event.keyCode == 96)) {
            event.preventDefault();
        }

        // Allow: backspace, delete, tab and escape
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
        // Allow: Ctrl+A, Ctrl+C, Ctrl+V
            (event.keyCode == 65 && event.ctrlKey === true) || (event.keyCode == 67 && event.ctrlKey === true) || (event.keyCode == 86 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        else {
            // Ensure that it is a number and stop the keypress
            if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }

        if ($this.hasClass("decimal-1") || $this.hasClass("decimal-2") || $this.hasClass("decimal-3")) {
            var value = $this.val();

            if (value.indexOf(".") != -1) {
                var currentNoOfDecimal = value.split(".")[1].length;
                var maxNoOfDecimal = 1;
                //alert("currentNoOfDecimal = " + currentNoOfDecimal + ", maxNoOfDecimal = " + maxNoOfDecimal);

                if ($this.hasClass("decimal-2")) {
                    maxNoOfDecimal = 2;
                }
                else if ($this.hasClass("decimal-3")) {
                    maxNoOfDecimal = 3;
                }

                if (currentNoOfDecimal == maxNoOfDecimal) {
                    event.preventDefault();
                }
            }
        }

        $(document).on("blur", "input:text.decimal,input:text.decimal-format,input:text.decimal-1,input:text.decimal-2,input:text.decimal-3", function () {
            var $this = $(this);

            if (isNaN($this.val())) {
                alert('xxxxxxxxxxxxxxxxxxx');
                dialog.error('錯誤', '請輸入數字');
                $this.val("").focus();
            }
        });

        $(document).on("focus", "input:text.decimal,input:text.decimal-format,input:text.decimal-1,input:text.decimal-2,input:text.decimal-3", function () {
            $(this).select();
        });

        $(document).on("blur", "input:text.decimal-format", function () {
            var $this = $(this);

            if ($this.val() != "") {
                $this.val(Utility.AddCommaToNumber($this.val()));
            }
        });

        $(document).on("keydown", "input:text.integer,input:text.integer-format", function (event) {
            // Not allow shift to prevent @!$#%^&
            if (event.shiftKey === true && event.keyCode >= 48 && event.keyCode <= 57) {
                event.preventDefault();
            }
            // Not allow enter 0 if textbox is empty
            //        else if ($(this).val() == "" && (event.keyCode == 48 || event.keyCode == 96)) {
            //            event.preventDefault();
            //        }

            // Allow: backspace, delete, tab and escape
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
            // Allow: Ctrl+A, Ctrl+C, Ctrl+V
            (event.keyCode == 65 && event.ctrlKey === true) || (event.keyCode == 67 && event.ctrlKey === true) || (event.keyCode == 86 && event.ctrlKey === true) ||
            // Allow: home, end, left, right
            (event.keyCode >= 35 && event.keyCode <= 39)) {
                // let it happen, don't do anything
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
        });

        $("input:text.integer,input:text.integer-format").mouseover(function (event) {
            var $this = $(this);

            if (isNaN($this.val())) {
                $this.val("");
            }
        });

        $(document).on("blur", "input:text.integer,input:text.integer-format", function () {
            var $this = $(this);

            if (isNaN($this.val())) {
                dialog.error('錯誤', '請輸入數字');
                $this.val("").focus();
            }
        });

        $(document).on("blur", "input:text.integer-format", function () {
            var $this = $(this);

            if ($this.val() != "") {
                $this.val(Utility.AddCommaToNumber($this.val()));
            }
        });

        $(document).on("focus", "input:text.integer,input:text.integer-format", function () {
            $(this).select();
        });
    });
    //#endregion //Format number and check integer and decimal input

    //regesiter logout event
    $('.logout').click(utility.logout);

    $('#__VIEWSTATE').remove();

    //#region Date and Time Picker
    var $inputDatePickerFrom = $("input:text.datepickerfrom");
    var $inputDatePickerTo = $("input:text.datepickerto");
    if ($inputDatePickerFrom.length != $inputDatePickerTo.length) {
        alert("DataRange is need has FROM and TO");
    } else if ($inputDatePickerFrom.length > 0) {
        $inputDatePickerFrom.datepicker({
            changeMonth: true,
            dateFormat: 'yyyy-mm-dd',
            onSelect: function (selectedDate) {
                $inputDatePickerTo.datepicker("option", "minDate", selectedDate);
            }
        });

        $inputDatePickerTo.datepicker({
            changeMonth: true,
            dateFormat: 'yyyy-mm-dd',
            onSelect: function (selectedDate) {
                $inputDatePickerFrom.datepicker("option", "maxDate", selectedDate);
            }
        });
    }

    /*
    var err = '<%=ViewData["errmsg"] %>';
    if (err.length > 0) {
    alert(err);
    if (parent != undefined) {
    parent.utility.closePopUpUrl();
    } else {
    history.go(-1);
    }
    }
    */
});

//jQuery extension
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
$.fn.isDefaultValue = function () {
    return (this.val() == this.attr('defaultValue'));
}