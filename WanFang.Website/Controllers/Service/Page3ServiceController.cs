﻿using System;
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
    public class Page3ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page3ServiceController));

        private static readonly Pilates_Manager PilatesMan = new Pilates_Manager();

        public Page3ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SavePilates(Pilates_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.RegID))
            {
                result.setErrorMessage("課程代號為必選");
            }
            if (data.PublishDate == DateTime.MinValue)
            {
                result.setErrorMessage("開課日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (string.IsNullOrEmpty(data.RegName))
            {
                result.setErrorMessage("課程名稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.ContentBody))
            {
                result.setErrorMessage("發布內容不得為空白");
            }
            if (string.IsNullOrEmpty(data.TimeStart))
            {
                result.setErrorMessage("上課開始時間不得為空白");
            }
            if (string.IsNullOrEmpty(data.TimeEnd))
            {
                result.setErrorMessage("上課結束時間不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = PilatesMan.GetBySN(data.PilatesId);
                if (data.PilatesId > 0)
                {
                    PilatesMan.Update(data);
                }
                else
                {
                    PilatesMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}