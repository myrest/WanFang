using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;
using WanFang.BLL;
using System;
using System.Linq;
using WanFang.Domain;
using System.Collections.Generic;
using WanFang.Domain.Constancy;


namespace WanFang.Website.Controllers
{
    public class Page11Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page11Controller));

        private static readonly Footer_Manager FooterMan = new Footer_Manager();

        public Page11Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 11;
        }

        public ActionResult EditFooter()
        {
            var PermissionCheck = CheckPermission("表尾資料管理");
            if (PermissionCheck != null) return PermissionCheck;

            var model = FooterMan.GetAll().FirstOrDefault();
            if (model == null)
            {
                model = new Footer_Info() { };
            }
            ViewData["Model"] = model;
            return View();
        }
    }
}