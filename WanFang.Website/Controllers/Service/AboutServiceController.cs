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
    }
}