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
    public class Page0ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page0ServiceController));

        private static readonly HomePage_Manager HomeMan = new HomePage_Manager();

        public Page0ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveHomePage(HomePage_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.Title))
            {
                result.setErrorMessage("標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.Link))
            {
                result.setErrorMessage("連結不得為空白");
            }
            if (data.DisplayDateTime == null || data.DisplayDateTime.Value == DateTime.MinValue)
            {
                result.setErrorMessage("顯示更新時間格式錯誤，YYYY/MM/DD hh:mm");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = HomeMan.GetAll().FirstOrDefault();
                if (olddata == null)
                {
                    HomeMan.Insert(data);
                }
                else
                {
                    data.HomePageId = data.HomePageId;
                    HomeMan.Update(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}