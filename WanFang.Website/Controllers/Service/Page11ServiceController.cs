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
    public class Page11ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page11ServiceController));

        private static readonly Footer_Manager HomeMan = new Footer_Manager();

        public Page11ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveFooter(Footer_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.FooterText))
            {
                result.setErrorMessage("表尾資料不得為空白");
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
                    data.FooterId = data.FooterId;
                    HomeMan.Update(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}