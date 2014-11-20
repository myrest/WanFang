using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;
using WanFang.BLL;
using System;
using System.Linq;
using WanFang.Domain;
using System.Collections.Generic;


namespace WanFang.Website.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AboutController));
        private static readonly About_Manager AboutMan = new About_Manager();
        private static readonly AboutCategory_Manager AboutCateMan = new AboutCategory_Manager();
        private static readonly AboutContent_Manager AboutContMan = new AboutContent_Manager();
        private static readonly AboutTeam_Manager AboutTeamMan = new AboutTeam_Manager();
        private static readonly AboutService_Manager AboutSrv = new AboutService_Manager();

        public AboutController()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 1;
        }

        public ActionResult Index()
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            return View();
        }

        public ActionResult EditAbout(string id)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            var model = AboutMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View(model);
        }

        public ActionResult Categoary(AboutCategory_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            if (filter.Category == "請輸入系列名稱搜尋") filter.Category = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<AboutCategory_Info> data = AboutCateMan.GetByParameter(filter, page, null, "SortNum");
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = data;
            ViewData["About"] = About;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditAboutCategoary(string id)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            var model = AboutCateMan.GetBySN(Convert.ToInt32(id));
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = model;
            ViewData["About"] = About;
            return View(model);
        }

        public ActionResult Content(AboutContent_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            if (!string.IsNullOrEmpty(filter.UnitName) && filter.UnitName.StartsWith("請輸入")) filter.UnitName = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<AboutContent_Info> data = AboutContMan.GetByParameter(filter, page, null, "AboutId, AboutCategoryId");
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            List<AboutCategory_Info> Categoary = AboutCateMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = data;
            ViewData["About"] = About;
            ViewData["Categoary"] = Categoary;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditAboutContent(string id)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("Content")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = AboutContMan.GetBySN(Convert.ToInt32(id));
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            List<AboutCategory_Info> Categoary = AboutCateMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = model;
            ViewData["About"] = About;
            ViewData["Categoary"] = Categoary;
            return View(model);
        }

        public ActionResult Team(string id, AboutTeam_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            if (!string.IsNullOrEmpty(filter.UserName) && filter.UserName.StartsWith("請輸入")) filter.UserName = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<AboutTeam_Info> data = AboutTeamMan.GetByParameter(filter, page, null, "SortNum");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditAboutTeam(string id)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("Team")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = AboutTeamMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View(model);
        }

        public ActionResult AboutService(AboutService_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            if (!string.IsNullOrEmpty(filter.UnitName) && filter.UnitName.StartsWith("請輸入")) filter.UnitName = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<AboutService_Info> data = AboutSrv.GetByParameter(filter, page, null, "SortNum");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditAboutService(string id)
        {
            var PermissionCheck = CheckPermission("關於萬芳管理");
            if (PermissionCheck != null) return PermissionCheck;
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("AboutService")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = AboutSrv.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View(model);
        }

    }
}