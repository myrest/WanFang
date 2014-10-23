using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;


namespace WanFang.Website.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AboutController));

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
    }
}