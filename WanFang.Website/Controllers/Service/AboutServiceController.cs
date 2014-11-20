using System;
using System.Linq;
using System.Web.Mvc;
using CWB.Web.Configuration;
using Rest.Core.Utility;
using WanFang.BLL;
using WanFang.Core;
using WanFang.Core.Constancy;
using WanFang.Core.MVC.BaseController;
using WanFang.Core.Utility;
using WanFang.Domain;
using WanFang.Domain.Constancy;
using WanFang.Website.Models;
using System.IO;

namespace WanFang.Website.Controllers.Service
{
    public class AboutServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AboutServiceController));
        private static readonly About_Manager AboutMan = new About_Manager();
        private static readonly AboutCategory_Manager AboutCatMan = new AboutCategory_Manager();
        private static readonly AboutContent_Manager AboutContMan = new AboutContent_Manager();
        private static readonly AboutTeam_Manager AboutTeamMan = new AboutTeam_Manager();
        private static readonly AboutService_Manager AboutSrv = new AboutService_Manager();

        public AboutServiceController()
            : base(Permission.Public)
        {
        }

        [HttpPost]
        public JsonResult SaveAbout(About_Info data)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.Category.Trim().Length == 0)
            {
                result.setErrorMessage("名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                data.Category = data.Category.Trim();
                if (data.AboutId > 0)
                {
                    AboutMan.Update(data);
                }
                else
                {
                    AboutMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult SaveAboutCategoary(AboutCategory_Info data)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.Category.Trim().Length == 0)
            {
                result.setErrorMessage("名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                data.Category = data.Category.Trim();
                if (data.AboutCategoryId > 0)
                {
                    AboutCatMan.Update(data);
                }
                else
                {
                    AboutCatMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveAboutContent(AboutContent_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");

            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = AboutContMan.GetBySN(data.AboutContentId);
                verdata.IsActive = 1;
                AboutContMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            //check is there are any data under the categoary.
            if (data.UnitName == null || data.UnitName.Trim().Length == 0)
            {
                result.setErrorMessage("單元名稱不得為空白");
            }
            if (data.AboutId == 0)
            {
                result.setErrorMessage("類別為必選");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;

                if (data.AboutContentId > 0)
                {
                    var olddata = AboutContMan.GetBySN(data.AboutContentId);
                    checkUploadfiles(data, olddata);
                    AboutContMan.Update(data);
                }
                else
                {
                    checkUploadfiles(data, new AboutContent_Info() { });
                    AboutContMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(AboutContent_Info NewData, AboutContent_Info OldData)
        {
            string Prefix = string.Empty;
            Prefix = "ContentImage1";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image1 = string.Empty;
                }
                else
                {
                    NewData.Image1 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image1 = OldData.Image1;
            }

            Prefix = "ContentImage2";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image2 = string.Empty;
                }
                else
                {
                    NewData.Image2 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image2 = OldData.Image2;
            }

            Prefix = "ContentImage3";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image3 = string.Empty;
                }
                else
                {
                    NewData.Image3 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image3 = OldData.Image3;
            }

        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveAboutTeam(AboutTeam_Info data)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = AboutTeamMan.GetBySN(data.AboutTeamId);
                verdata.IsActive = 1;
                AboutTeamMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }

            if (data.SortNum == null)
            {
                result.setErrorMessage("順序不得為空白");
            }
            if (string.IsNullOrEmpty(data.StrName))
            {
                result.setErrorMessage("職稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.UserName))
            {
                result.setErrorMessage("姓名不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;

                if (data.AboutTeamId > 0)
                {
                    var olddata = AboutTeamMan.GetBySN(data.AboutTeamId);
                    checkUploadfilesTeam(data, olddata);
                    AboutTeamMan.Update(data);
                }
                else
                {
                    checkUploadfilesTeam(data, new AboutTeam_Info() { });
                    AboutTeamMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfilesTeam(AboutTeam_Info NewData, AboutTeam_Info OldData)
        {
            string Prefix = string.Empty;
            Prefix = "TeamPhoto1";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Photo1 = string.Empty;
                }
                else
                {
                    NewData.Photo1 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Photo1 = OldData.Photo1;
            }

            Prefix = "TeamPhoto2";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Photo2 = string.Empty;
                }
                else
                {
                    NewData.Photo2 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Photo2 = OldData.Photo2;
            }
        }


        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveAboutService(AboutService_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");

            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = AboutSrv.GetBySN(data.AboutServiceId);
                verdata.IsActive = 1;
                AboutSrv.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            //check is there are any data under the categoary.
            if (data.UnitName == null || data.UnitName.Trim().Length == 0)
            {
                result.setErrorMessage("單元名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;

                if (data.AboutServiceId > 0)
                {
                    var olddata = AboutSrv.GetBySN(data.AboutServiceId);
                    checkSrvUploadfiles(data, olddata);

                    AboutSrv.Update(data);
                }
                else
                {
                    checkSrvUploadfiles(data, new AboutService_Info() { });
                    AboutSrv.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkSrvUploadfiles(AboutService_Info NewData, AboutService_Info OldData)
        {
            string Prefix = string.Empty;
            Prefix = "AboutServiceImage1";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image1 = string.Empty;
                }
                else
                {
                    NewData.Image1 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image1 = OldData.Image1;
            }

            Prefix = "AboutServiceImage2";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image2 = string.Empty;
                }
                else
                {
                    NewData.Image2 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image2 = OldData.Image2;
            }

            Prefix = "AboutServiceImage3";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image3 = string.Empty;
                }
                else
                {
                    NewData.Image3 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image3 = OldData.Image3;
            }

        }

        private string CopyFile(string Source)
        {
            string NewName = "/Upload/" + Path.GetFileName(Source);
            Source = string.Format("{0}/{1}", Server.MapPath("~/"), Source);
            string Target = string.Format("{0}{1}", Server.MapPath("~/"), NewName);
            if (System.IO.File.Exists(Source))
            {
                FileInfo f = new FileInfo(Source);
                f.MoveTo(Target);
            }
            return NewName;
        }
    }
}