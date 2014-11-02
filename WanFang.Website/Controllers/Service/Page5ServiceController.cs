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
    public class Page5ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page5ServiceController));
        private static readonly Doc_Manager DocMan = new Doc_Manager();

        public Page5ServiceController()
            : base(Permission.Public)
        {
        }

        private string getDeptName(WS_Dept_type DeptType)
        {
            return EnumHelper.GetEnumDescription<WS_Dept_type>(DeptType);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveDoc(Doc_Info data)
        {
            //data.DeptName = getDeptName(sessionData.trading.Dept.Value);
            ResultBase result = new ResultBase();
            result.setMessage("Done");
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
                result.setErrorMessage("門診時段不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.Dept = data.DeptName;
                data.DeptName = getDeptName(EnumHelper.GetEnumByName<WS_Dept_type>(data.Dept));
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = DocMan.GetBySN(data.DocId);
                checkUploadfiles(data, olddata);
                if (string.IsNullOrEmpty(data.pic))
                {
                    result.setErrorMessage("醫師照片必需上傳");
                }
                if (data.DocId > 0)
                {
                    DocMan.Update(data);
                }
                else
                {
                    DocMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(Doc_Info NewData, Doc_Info OldData)
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

        private string CopyFile(string Source)
        {
            string NewName = "/Upload/" + Path.GetFileName(Source);
            Source = string.Format("{0}/{1}", Server.MapPath("~/"), Source);
            string Target = string.Format("{0}{1}", Server.MapPath("~/"), NewName);
            FileInfo f = new FileInfo(Source);
            f.MoveTo(Target);
            return NewName;
        }
    }
}