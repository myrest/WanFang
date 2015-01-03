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
    public class Page2ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page2ServiceController));

        private static readonly DiaryData_Manager DiaryMan = new DiaryData_Manager();

        public Page2ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveDiaryData(DiaryData_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.DiaryType))
            {
                result.setErrorMessage("類別名稱為必選");
            }
            if (!string.IsNullOrEmpty(data.DiaryTypeCode) && data.DiaryTypeCode.Length > 1)
            {
                result.setErrorMessage("類別代碼限制長度為1");
            }
            if (data.PublishDate == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (string.IsNullOrEmpty(data.Subject))
            {
                result.setErrorMessage("發布主題不得為空白");
            }
            if (string.IsNullOrEmpty(data.ContentBody))
            {
                result.setErrorMessage("發布內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = DiaryMan.GetBySN(data.DiaryDataID);
                checkUploadfiles(data, olddata);
                data.Hit = olddata.Hit;
                if (data.DiaryDataID > 0)
                {
                    DiaryMan.Update(data);
                }
                else
                {
                    DiaryMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(DiaryData_Info NewData, DiaryData_Info OldData)
        {
            if (OldData == null) OldData = new DiaryData_Info();
            string Prefix = string.Empty;
            Prefix = "DiaryDataImage1";
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

            Prefix = "DiaryDataImage2";
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

            Prefix = "DiaryDataImage3";
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
            Prefix = "DiaryDataImage4";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image4 = string.Empty;
                }
                else
                {
                    NewData.Image4 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image4 = OldData.Image4;
            }
            Prefix = "DiaryDataFileDocument";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.FileDocument = string.Empty;
                }
                else
                {
                    NewData.FileDocument = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.FileDocument = OldData.FileDocument;
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