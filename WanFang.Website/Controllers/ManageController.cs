using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;


namespace WanFang.Website.Controllers
{
    public class ManageController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ManageController));

        public ManageController()
            : base(Permission.Public)
        {
            ViewData["MenuItem"] = 0;
        }

        public ActionResult Index(string id)
        {
            if (sessionData.trading != null)
            {
                return RedirectToAction("Welcome", "Manage");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult UserListing()
        {
            ViewData["MenuItem"] = 12;
            return View();
        }

    }
}