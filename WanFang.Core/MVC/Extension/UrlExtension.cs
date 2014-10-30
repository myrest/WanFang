using System;
using System.Web.Mvc;

namespace WanFang.Core.MVC.Extensions
{
    public static class UrlExtension
    {
        private static readonly string VersionNumber = DateTime.Now.Second.ToString();

        public static string CdnContent(this UrlHelper url, string contentPath)
        {
            //return string.Concat(CdnManager.CDNServer + "CDN" + contentPath, "?v=", AppConfigManager.SystemSetting.StaticFileVersionNumber);
            return string.Concat("/CDN" + contentPath, "?v=", VersionNumber);
        }

        public static string CultureRoute(this UrlHelper url, string culture, string controllerName, string actionName)
        {
            return url.Action(actionName, controllerName, new { culture = culture });//(culture, new { controller = controllerName, action = actionName });
        }

        public static string CultureRoute(this UrlHelper url, string culture, string controllerName, string actionName, string id)
        {
            return url.Action(actionName, controllerName, new { culture = culture, id = id });//(culture, new { controller = controllerName, action = actionName });
        }

        #region 上下架設定
        public static string GenerIsActive(bool isActive, bool TextOnly = false)
        {
            if (TextOnly)
            {
                return (isActive) ? "上架" : "下架";
            }
            else
            {
                string rtn = "<select name=\"IsActive\">";
                rtn += "<option value=\"1\" " + (isActive ? " selected " : "") + ">上架</option>";
                rtn += "<option value=\"0\" " + (!isActive ? " selected " : "") + ">下架</option>";
                rtn += "</select>";
                return rtn;
            }
        }

        public static string GenerIsActive(int isActive, bool TextOnly = false)
        {
            return GenerIsActive((isActive > 0), TextOnly);
        }

        public static string GenerFilterIsActive(int? isActive)
        {
            bool? active = null;
            if (isActive.HasValue)
            {
                active = (isActive.Value > 0);
            }
            return GenerFilterIsActive(active);
        }

        public static string GenerFilterIsActive(bool? isActive)
        {
            string rtn = "<select name=\"IsActive\">";
            rtn += "<option value=\"\" " + (!isActive.HasValue ? " selected " : "") + ">全部顯示</option>";
            rtn += "<option value=\"1\" " + (isActive.HasValue && isActive.Value ? " selected " : "") + ">上架</option>";
            rtn += "<option value=\"0\" " + (isActive.HasValue && !isActive.Value ? " selected " : "") + ">下架</option>";
            rtn += "</select>";
            return rtn;

        }
        #endregion

        #region 檔案處理
        public static string PreviewImage(string ImageFileName, string TargetID)
        {
            string rtn = string.Empty;
            if (!string.IsNullOrEmpty(ImageFileName))
            {
                rtn = "---[<a class=\"previewimage\" target=\"_blank\" href=\"" + ImageFileName + "\">預覽</a>][<a href=\"javascript:void(0);\" class=\"deleteimage clickable \" target=\"" + TargetID + "\">刪</a>]";
            }
            else
            {
                rtn = "---[<a class=\"previewimage\" target=\"_blank\">預覽</a>][<a class=\"deleteimage\" target=\"" + TargetID + "\">刪</a>]";
            }
            return rtn;
        }
        #endregion
    }
}