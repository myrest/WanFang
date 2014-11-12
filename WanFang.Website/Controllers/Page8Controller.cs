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
    public class Page8Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page8Controller));

        private static readonly Nhi_p_Manager Nhi_pMan = new Nhi_p_Manager();
        private static readonly Nhi_Med_Manager MedMan = new Nhi_Med_Manager();

        public Page8Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 8;
        }

        private void ClearOldData(string Prefix)
        {
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith(Prefix)).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }
        }

        public ActionResult Nhi_p(Nhi_p_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("健保專區管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.nhi_cname) && filter.nhi_cname.StartsWith("請輸入")) filter.nhi_cname = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Nhi_p_Info> data = Nhi_pMan.GetByParameter(filter, page, null, "nhi_date desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditNhi_p(string id)
        {
            //Clear old data.
            ClearOldData("Nhi_p");
            var model = Nhi_pMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult Nhi_Med(Nhi_Med_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("健保專區管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.CodeOld) && filter.CodeOld.StartsWith("請輸入")) filter.CodeOld = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Nhi_Med_Info> data = MedMan.GetByParameter(filter, page, null, "PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditNhi_Med(string id)
        {
            //Clear old data.
            ClearOldData("Nhi_Med");
            var model = MedMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}