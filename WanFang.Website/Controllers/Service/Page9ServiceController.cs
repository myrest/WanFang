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
        private static readonly Doc_Manager DocMan = new Doc_Manager();

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
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = CostUnitman.GetBySN(data.CostUnitId);
                verdata.IsActive = 1;
                CostUnitman.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            //限制只能修改該單元之資料
            data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            data.CostId = sessionData.trading.CostId;
            if (string.IsNullOrEmpty(data.UnitName))
            {
                result.setErrorMessage("單元名稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.ContentBody) && data.IsHomePage == 0)
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
                    result.setMessage(data.CostUnitId.ToString());
                }
                else
                {
                    var newId = CostUnitman.Insert(data);
                    result.setMessage(newId.ToString());
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveDoc(Doc_Info data)
        {
            if (data.conf_date == DateTime.MinValue)
            {
                DateTime newdt = DateTime.MinValue;
                DateTime.TryParse("1974/01/01", out newdt);
                data.conf_date = newdt;
            }
            //data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = DocMan.GetBySN(data.DocId);
                verdata.IsActive = 1;
                DocMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            if (string.IsNullOrEmpty(data.DeptName) || data.DeptName.StartsWith("請選擇"))
            {
                result.setErrorMessage("門診類別為必選");
            }
            if (string.IsNullOrEmpty(data.CostName) || data.CostName.StartsWith("請選擇"))
            {
                result.setErrorMessage("科別為必選");
            }
            if (string.IsNullOrEmpty(data.DocName))
            {
                result.setErrorMessage("醫師中文名字不得為空白");
            }
            if (string.IsNullOrEmpty(data.DocCode))
            {
                result.setErrorMessage("醫師員編不得為空白");
            }
            if (string.IsNullOrEmpty(data.MainMajor1))
            {
                result.setErrorMessage("主治項目不得為空白");
            }
            if (string.IsNullOrEmpty(data.school))
            {
                result.setErrorMessage("學歷不得為空白");
            }
            if (string.IsNullOrEmpty(data.career))
            {
                result.setErrorMessage("經歷不得為空白");
            }
            if (string.IsNullOrEmpty(data.ncareer))
            {
                result.setErrorMessage("現職不得為空白");
            }
            if (string.IsNullOrEmpty(data.school))
            {
                result.setErrorMessage("學歷不得為空白");
            }
            if (string.IsNullOrEmpty(data.otime))
            {
                //result.setErrorMessage("門診時段不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.Dept = data.DeptName;
                data.DeptName = getDeptName(EnumHelper.GetEnumByName<WS_Dept_type>(data.Dept));
                data.Cost = sessionData.trading.CostId;
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = DocMan.GetBySN(data.DocId);
                checkDocUploadfiles(data, olddata);
                if (string.IsNullOrEmpty(data.pic))
                {
                    result.setErrorMessage("醫師照片必需上傳");
                }
                else
                {
                    if (data.DocId > 0)
                    {
                        DocMan.Update(data);
                    }
                    else
                    {
                        DocMan.Insert(data);
                    }
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkDocUploadfiles(Doc_Info NewData, Doc_Info OldData)
        {
            if (OldData == null) OldData = new Doc_Info();
            string Prefix = string.Empty;
            Prefix = "DocPic";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.pic = string.Empty;
                }
                else
                {
                    NewData.pic = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.pic = OldData.pic;
            }
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
                if (data.IsActive == 1)
                {
                    //審核專用
                    var verdata = DocMan.GetBySN(data.WebDownLoadID);
                    verdata.IsActive = 1;
                    DocMan.Update(verdata);
                    return Json(result, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    //一但有任何異動，自動下架
                    data.IsActive = 0;
                }

                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = DownloadMan.GetBySN(data.WebDownLoadID);
                //check must has uploaded files.
                try
                {
                    checkUploadfilesWDD(data, olddata);
                    if (string.IsNullOrEmpty(data.File1))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    result.setErrorMessage("檔案必需上傳。");
                }
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
                if (data.IsActive == 1)
                {
                    //審核專用
                    var verdata = CostNewsMan.GetBySN(data.CostNewsId);
                    verdata.IsActive = 1;
                    CostNewsMan.Update(verdata);
                    return Json(result, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    //一但有任何異動，自動下架
                    data.IsActive = 0;
                }
                //限制只能修改該單元之資料
                data.DeptName = getDeptName(sessionData.trading.Dept.Value);
                data.CostId = sessionData.trading.CostId;

                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = CostNewsMan.GetBySN(data.CostNewsId);
                checkUploadfilesNews(data, olddata);
                if (data.CostNewsId > 0)
                {
                    CostNewsMan.Update(data);
                    result.setMessage(data.CostNewsId.ToString());
                }
                else
                {
                    var NewId = CostNewsMan.Insert(data);
                    result.setMessage(NewId.ToString());
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