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
        private static readonly TeamIntroduce_Manager TeamMan = new TeamIntroduce_Manager();

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
        public JsonResult SaveTeamIntroduce(TeamIntroduce_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = TeamMan.GetBySN(data.TeamIntroduceId);
                verdata.IsActive = 1;
                verdata.VerifiedDate = DateTime.Now;
                TeamMan.Update(verdata);
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
            if (string.IsNullOrEmpty(data.WebMenuCode))
            {
                result.setErrorMessage("網頁選單代號不得為空白");
            }
            if (string.IsNullOrEmpty(data.WebMenuName))
            {
                result.setErrorMessage("內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.Dept = data.DeptName;
                data.DeptName = getDeptName(EnumHelper.GetEnumByName<WS_Dept_type>(data.Dept));
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = TeamMan.GetBySN(data.TeamIntroduceId);
                checkUploadfilesTeamIntro(data, olddata);
                if (data.TeamIntroduceId > 0)
                {
                    TeamMan.Update(data);
                }
                else
                {
                    TeamMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfilesTeamIntro(TeamIntroduce_Info NewData, TeamIntroduce_Info OldData)
        {
            if (OldData == null) OldData = new TeamIntroduce_Info();
            string Prefix = string.Empty;
            Prefix = "TeamIntroduceImage1";
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
            Prefix = "TeamIntroduceImage2";
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
            Prefix = "TeamIntroduceImage3";
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
            Prefix = "TeamIntroduceImage4";
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