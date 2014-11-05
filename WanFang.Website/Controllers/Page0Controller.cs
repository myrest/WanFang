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
    public class Page0Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page0Controller));

        private static readonly HomePage_Manager HomeMan = new HomePage_Manager();

        public Page0Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 0;
        }

        public ActionResult EditHomePage()
        {
            var model = HomeMan.GetAll().FirstOrDefault();
            if (model == null)
            {
                model = new HomePage_Info() { };
            }
            ViewData["Model"] = model;
            return View();
        }
    }
}