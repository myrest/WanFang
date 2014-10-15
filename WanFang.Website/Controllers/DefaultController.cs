using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;


namespace WanFang.Website.Controllers
{
    public class DefaultController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(DefaultController));

        public DefaultController()
            : base(Permission.Public)
        {
        }

        public ActionResult Index(string id)
        {
            if (sessionData.trading != null)
            {
                return RedirectToAction("Manage", "Welcome");
            }
            else
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewData["TopicGroupId"] = "";
                }
                else
                {
                    ViewData["TopicGroupId"] = id;
                }
                return View();
            }
        }
    }
}