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
    public class Page9ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page9ServiceController));
        private static readonly CostUnit_Manager CostUnitman = new CostUnit_Manager();
        private static readonly WebDownload_Manager DownloadMan = new WebDownload_Manager();
        private static readonly CostNews_Manager CostNewsMan = new CostNews_Manager();

        public Page9ServiceController()
            : base(Permission.Public)
        {
        }

        private string getDeptName(WS_Dept_type DeptType)
        {
            return EnumHelper.GetEnumDescription<WS_Dept_type>(DeptType);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveCostUnit(CostUnit_Info data)
        {
            data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.UnitName))
            {
                result.setErrorMessage("單元名稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.ContentBody))
            {
                result.setErrorMessage("內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = CostUnitman.GetBySN(data.CostUnitId);
                checkUploadfiles(data, olddata);
                if (data.CostUnitId > 0)
                {
                    CostUnitman.Update(data);
                }
                else
                {
                    CostUnitman.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(CostUnit_Info NewData, CostUnit_Info OldData)
        {
            if (OldData == null) OldData = new CostUnit_Info();
            string Prefix = string.Empty;
            Prefix = "CostUnitImage1";
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

            Prefix = "CostUnitImage2";
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

            Prefix = "CostUnitImage3";
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
        public JsonResult SaveDownLoad(WebDownload_Info data)
        {
            data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.DocumentName))
            {
                result.setErrorMessage("檔案名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = DownloadMan.GetBySN(data.WebDownLoadID);
                checkUploadfilesWDD(data, olddata);
                if (data.WebDownLoadID > 0)
                {
                    DownloadMan.Update(data);
                }
                else
                {
                    DownloadMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfilesWDD(WebDownload_Info NewData, WebDownload_Info OldData)
        {
            string Prefix = string.Empty;
            Prefix = "WebDownLoadFile1";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.File1 = string.Empty;
                }
                else
                {
                    NewData.File1 = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.File1 = OldData.File1;
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNews(CostNews_Info data)
        {
            data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.Subject))
            {
                result.setErrorMessage("發布主題不得為空白");
            }
            if (DateTime.MinValue == data.PublishDate)
            {
                result.setErrorMessage("發布日期格式錯誤，格式為 YYYY/MM/DD。");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = CostNewsMan.GetBySN(data.CostNewsId);
                checkUploadfilesNews(data, olddata);
                if (data.CostNewsId > 0)
                {
                    CostNewsMan.Update(data);
                }
                else
                {
                    CostNewsMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfilesNews(CostNews_Info NewData, CostNews_Info OldData)
        {
            if (OldData == null) OldData = new CostNews_Info() { };
            string Prefix = string.Empty;
            Prefix = "CostNewsImage1";
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

            Prefix = "CostNewsImage2";
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

            Prefix = "CostNewsImage3";
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

            Prefix = "CostNewsImage4";
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

            Prefix = "CostNewsUploadFile";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.UploadFile = string.Empty;
                }
                else
                {
                    NewData.UploadFile = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.UploadFile = OldData.UploadFile;
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