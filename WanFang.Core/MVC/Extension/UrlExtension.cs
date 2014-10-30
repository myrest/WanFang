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

        #region �W�U�[�]�w
        public static string GenerIsActive(bool isActive, bool TextOnly = false)
        {
            if (TextOnly)
            {
                return (isActive) ? "�W�[" : "�U�[";
            }
            else
            {
                string rtn = "<select name=\"IsActive\">";
                rtn += "<option value=\"1\" " + (isActive ? " selected " : "") + ">�W�[</option>";
                rtn += "<option value=\"0\" " + (!isActive ? " selected " : "") + ">�U�[</option>";
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
            rtn += "<option value=\"\" " + (!isActive.HasValue ? " selected " : "") + ">�������</option>";
            rtn += "<option value=\"1\" " + (isActive.HasValue && isActive.Value ? " selected " : "") + ">�W�[</option>";
            rtn += "<option value=\"0\" " + (isActive.HasValue && !isActive.Value ? " selected " : "") + ">�U�[</option>";
            rtn += "</select>";
            return rtn;

        }
        #endregion

        #region �ɮ׳B�z
        public static string PreviewImage(string ImageFileName, string TargetID)
        {
            string rtn = string.Empty;
            if (!string.IsNullOrEmpty(ImageFileName))
            {
                rtn = "---[<a class=\"previewimage\" target=\"_blank\" href=\"" + ImageFileName + "\">�w��</a>][<a href=\"javascript:void(0);\" class=\"deleteimage clickable \" target=\"" + TargetID + "\">�R</a>]";
            }
            else
            {
                rtn = "---[<a class=\"previewimage\" target=\"_blank\">�w��</a>][<a class=\"deleteimage\" target=\"" + TargetID + "\">�R</a>]";
            }
            return rtn;
        }
        #endregion
    }
}