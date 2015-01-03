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
    public class Page6ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page6ServiceController));
        private static readonly NewsData_Manager NewsDataMan = new NewsData_Manager();
        private static readonly Edu_Manager EduMan = new Edu_Manager();

        public Page6ServiceController()
            : base(Permission.Public)
        {
        }

        private string getDeptName(WS_Dept_type DeptType)
        {
            return EnumHelper.GetEnumDescription<WS_Dept_type>(DeptType);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNewsData(NewsData_Info data)
        {
            //data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.Title))
            {
                result.setErrorMessage("標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.Author))
            {
                result.setErrorMessage("發表者不得為空白");
            }
            if (string.IsNullOrEmpty(data.Keyword))
            {
                result.setErrorMessage("後台關鍵字不得為空白");
            }
            if (string.IsNullOrEmpty(data.ContentBody))
            {
                result.setErrorMessage("內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                if (data.IsActive == 1)
                {
                    //審核專用
                    var verdata = NewsDataMan.GetBySN(data.NewsId);
                    verdata.IsActive = 1;
                    NewsDataMan.Update(verdata);
                    return Json(result, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    //一但有任何異動，自動下架
                    data.IsActive = 0;
                }
                data.LastUpdate = DateTime.Now;
                data.LastUpadtor = sessionData.trading.LoginId;
                var olddata = NewsDataMan.GetBySN(data.NewsId);
                checkUploadfiles(data, olddata);
                if (data.DeptName.Length == 1)
                {
                    //DeptName is real DeptCode
                    data.DeptCode = data.DeptName;
                    //Get DeptName from DeptCode
                    data.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(EnumHelper.GetEnumByName<WS_Dept_type>(data.DeptCode));
                }
                else
                {
                    //Get DeptCode from DeptName
                    var allenum = Enum.GetValues(typeof(WS_Dept_type)).Cast<WS_Dept_type>();
                    var deptobj = allenum.Where(x=> EnumHelper.GetEnumDescription<WS_Dept_type>(x) == data.DeptName).FirstOrDefault();
                    if (deptobj != null)
                    {
                        data.DeptCode = deptobj.ToString();
                    }
                }
                //get costid from costname
                WS_Dept_type depttype = EnumHelper.GetEnumByName<WS_Dept_type>(data.DeptCode);
                var CostObject = new WebService_Manage().GetAllDetailCostcerter(depttype).Where(x => data.Cost.Trim() == x.CostName.Trim()).FirstOrDefault();
                if (CostObject != null)
                {
                    data.CostId = CostObject.CostCode;
                    if (data.NewsId > 0)
                    {
                        NewsDataMan.Update(data);
                        result.setMessage(data.NewsId.ToString());
                    }
                    else
                    {
                        var newId = NewsDataMan.Insert(data);
                        result.setMessage(newId.ToString());
                    }
                }
                else
                {
                    result.setException(new Exception(string.Format("查無科別代碼({0})", data.Cost)), "SaveNewsData");
                }

            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(NewsData_Info NewData, NewsData_Info OldData)
        {
            if (OldData == null) OldData = new NewsData_Info();
            string Prefix = string.Empty;
            Prefix = "NewsDataImage1";
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

            Prefix = "NewsDataImage2";
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

            Prefix = "NewsDataImage3";
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

            Prefix = "NewsDataImage4";
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
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveEdu(Edu_Info data)
        {
            //data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.Title))
            {
                result.setErrorMessage("衛教標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.Teacher))
            {
                result.setErrorMessage("衛教主講者不得為空白");
            }
            if (string.IsNullOrEmpty(data.Place))
            {
                result.setErrorMessage("衛教地點不得為空白");
            }
            if (string.IsNullOrEmpty(data.DateStart))
            {
                result.setErrorMessage("衛教起始時間不得為空白");
            }
            if (string.IsNullOrEmpty(data.DateEnd))
            {
                result.setErrorMessage("衛教結束時間不得為空白");
            }
            if (data.EduDate == DateTime.MinValue)
            {
                result.setErrorMessage("衛教日期格式錯誤，格式為 YYYY/MM/DD");
            }
            string timesample = "2000/01/01 {0}";
            DateTime temptime;
            if (!DateTime.TryParse(string.Format(timesample, data.DateStart), out temptime))
            {
                result.setErrorMessage("無效的衛教起始時間");
            }
            if (!DateTime.TryParse(string.Format(timesample, data.DateEnd), out temptime))
            {
                result.setErrorMessage("無效的衛教結束時間");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                if (data.EduId > 0)
                {
                    EduMan.Update(data);
                }
                else
                {
                    EduMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
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