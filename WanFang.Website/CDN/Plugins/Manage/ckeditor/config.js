/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	
    config.skin = 'moonocolor';
    config.resize_enabled = false;
    config.toolbarCanCollapse = false;

    config.toolbar = [
        ['Source', 'Preview'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
        ['Undo', 'Redo', '-', 'SelectAll', 'RemoveFormat'],
        ['Image', 'Flash', 'Table', 'Rule'],
        ['Link', 'Unlink', 'Anchor', '-', 'Smiley', 'SpecialChar'],
        ['FitWindow', 'ShowBlocks'],
        '/',
        ['Styles', 'Font', 'FontSize'],
        ['TextColor', 'BGColor'],
        ['Bold', 'Italic', 'Underline', 'StrikeThrough', '-', 'Subscript', 'Superscript'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock']
    ];

    config.pasteFromWordRemoveFontStyles = false;
    config.pasteFromWordRemoveStyles = false;

    config.stylesSet = 'stylecss';
    //config.contentsCss = ['/css/style.css'];
    //config.contentsCss = 'contents.css';

    config.filebrowserBrowseUrl = '../ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '../ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '../ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '../ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    config.filebrowserWindowWidth = '800';
    config.filebrowserWindowHeight = '500';
    config.indentOffset = 12;

    config.font_defaultLabel = 'Arial';
    config.font_names = 'Arial;Arial Black;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana;新細明體;細明體;標楷體;微軟正黑體';
	
};
