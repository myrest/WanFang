using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;
using WanFang.BLL;
using System;


namespace WanFang.Website.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AboutController));
        private static readonly About_Manager AboutMan = new About_Manager();

        public AboutController()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 0;
        }

        public ActionResult Index(string id)
        {
            ViewData["MenuItem"] = 1;
            return View();
        }

        public ActionResult EditAbout(string id)
        {
            var model = AboutMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View(model);
        }
             
    }
}