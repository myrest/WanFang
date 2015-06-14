using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;
using System.Web;
using System.IO;
using System.Linq;
using WanFang.Website.Models;


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

        public void uploadnow(HttpPostedFileWrapper upload)
        {
            string CostImagePath = GetCostUploadPath();
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath(CostImagePath), ImageName);
                upload.SaveAs(path);
            }
        }

        public ActionResult UploadPartial()
        {
            string CostImagePath = GetCostUploadPath();
            var appData = Server.MapPath(CostImagePath);
            var images = Directory.GetFiles(appData).Select(x => new ImagesViewModel
            {
                Url = CostImagePath + "/" + Path.GetFileName(x)
            }).ToList();
            ViewData["Model"] = images;
            return View();
        }

        private string GetCostUploadPath()
        {
            string costid = string.Empty;
            string CostImagePath = string.Empty;
            string RelatedPath = string.Empty;
            if (sessionData != null && sessionData.trading != null && !string.IsNullOrEmpty(sessionData.trading.CostId))
            {
                costid = sessionData.trading.CostId;
            }
            else
            {
                costid = "Global";
            }
            RelatedPath = "/Upload/" + costid;
            CostImagePath = Server.MapPath(RelatedPath);
            if (!Directory.Exists(CostImagePath))
            {
                Directory.CreateDirectory(CostImagePath);
            }
            return RelatedPath;
        }

    }
}