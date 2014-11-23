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

using WanFang.Website.Models;
using System.IO;

namespace WanFang.Website.Controllers.Service
{
    public class NormallContentServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(NormallContentServiceController));

        private static readonly NormallContent_Manager NcMan = new NormallContent_Manager();

        public NormallContentServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNormallContent(NormallContent_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = NcMan.GetBySN(data.NormallContentId);
                verdata.IsActive = 1;
                NcMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }

            if (string.IsNullOrEmpty(data.UnitName))
            {
                result.setErrorMessage("單元名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = NcMan.GetBySN(data.NormallContentId);
                checkUploadfiles(data, olddata);
                if (data.NormallContentId > 0)
                {
                    NcMan.Update(data);
                }
                else
                {
                    NcMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(NormallContent_Info NewData, NormallContent_Info OldData)
        {
            if (OldData == null) OldData = new NormallContent_Info();
            string Prefix = string.Empty;
            Prefix = "NormallContentImage1";
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

            Prefix = "NormallContentImage2";
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

            Prefix = "NormallContentImage3";
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