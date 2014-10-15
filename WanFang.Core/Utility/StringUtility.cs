using CWB.Web.Configuration;
using System;

namespace WanFang.Core.Utility
{
    public class StringUtility
    {
        private enum IconPathType
        {
            Temp,
            PersonIcon,
            TeamLogo,
            Best,
            GAP,
            Result,
            Scenario,
            Analytics
        }

        public static string ConvertPicturePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return default(string);
            }
            else
            {
                return ConvertImagePath(IconPathType.PersonIcon, fileName);
            }
        }

        public static string ConvertTempPath(string fileName)
        {
            return ConvertImagePath(IconPathType.Temp, fileName);
        }

        public static string ConvertTeamLogoPath(string fileName)
        {
            return ConvertImagePath(IconPathType.TeamLogo, fileName);
        }

        public static string ConvertGAPPath(string fileName)
        {
            return ConvertImagePath(IconPathType.GAP, fileName);
        }

        public static string ConvertBestPath(string fileName)
        {
            return ConvertImagePath(IconPathType.Best, fileName);
        }

        public static string ConvertResultPath(string fileName)
        {
            return ConvertImagePath(IconPathType.Result, fileName);
        }

        public static string ConvertScenarioPath(string fileName)
        {
            return ConvertImagePath(IconPathType.Scenario, fileName);
        }

        private static string ConvertImagePath(IconPathType IconType, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string FolderName = GetConfigPath(IconType);
                string rtn = fileName;
                //check the personal icon is come from out site link.
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (!fileName.StartsWith("http") && string.Compare("/pic/NoIcon.jpg", fileName, true) != 0)
                    {
                        rtn = string.Format("{0}/{1}", FolderName, fileName);
                        rtn += "?" + DateTime.Now.Millisecond;
                    }
                }
                return rtn;
            }
            else
            {
                return string.Empty;
            }
        }

        private static string GetConfigPath(IconPathType IconType)
        {
            switch (IconType)
            {
                case IconPathType.Temp:
                    return AppConfigManager.SystemSetting.FileUpLoadTempFolder;

                case IconPathType.PersonIcon:
                    return AppConfigManager.SystemSetting.FileUpLoadIcon;

                case IconPathType.TeamLogo:
                    return AppConfigManager.SystemSetting.FileUpLoadTeamLogo;

                case IconPathType.Best:
                    return AppConfigManager.SystemSetting.FileUpLoadBest;

                case IconPathType.GAP:
                    return AppConfigManager.SystemSetting.FileUpLoadBestGAP;

                case IconPathType.Result:
                    return AppConfigManager.SystemSetting.FileUpLoadResult;

                case IconPathType.Scenario:
                    return AppConfigManager.SystemSetting.FileUpLoadScenario;

                case IconPathType.Analytics:
                    return AppConfigManager.SystemSetting.FileUploadAnalytics;

                default:
                    throw new Exception("IconType not deside using which setting.");
            }
        }

        public static string ConvertNewLineToBR(string Words)
        {
            if (!string.IsNullOrEmpty(Words))
            {
                Words = Words.Replace(Environment.NewLine, "<br>").Replace("\n", "<br>").Replace("\r", "<br>");
            }
            return Words;
        }
    }
}