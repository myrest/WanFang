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
    public class Page9Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page9Controller));
        private static readonly CostUnit_Manager CostUman = new CostUnit_Manager();
        private static readonly WebDownload_Manager Downloadman = new WebDownload_Manager();
        private static readonly CostNews_Manager CostNewsMan = new CostNews_Manager();

        public Page9Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 9;
            if (sessionData.trading.Dept.HasValue)
            {
                ViewData["Dept"] = sessionData.trading.Dept.Value;//WS_Dept_type
                ViewData["DeptName"] = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
            }
        }

        public ActionResult Index()
        {
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EditCostUnit(string id)
        {
            var model = CostUman.GetBySN(Convert.ToInt32(id));
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                ViewData["Model"] = model;
                return View();
            }
        }

        public ActionResult DownLoad(WebDownload_Filter filter, Rest.Core.Paging Page)
        {
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                if (filter.DocumentName == "請輸入檔案名稱搜尋") filter.DocumentName = null;
                ViewData["Filter"] = filter;

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<WebDownload_Info> data = Downloadman.GetByParameter(filter, page, null, "SortNum");
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                return View();
            }
        }

        public ActionResult EditDownLoad(string id)
        {
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("WebDownLoad")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = Downloadman.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult News(CostNews_Filter filter, Rest.Core.Paging Page)
        {
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                if (filter.Subject == "請輸入發布主題搜尋") filter.Subject = null;
                ViewData["Filter"] = filter;

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<CostNews_Info> data = CostNewsMan.GetByParameter(filter, page, null, "PublishDate desc");
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                return View();
            }
        }

        public ActionResult EditNews(string id)
        {
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("CostNews")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = CostNewsMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        /*
        public ActionResult Categoary(AboutCategory_Filter filter, Rest.Core.Paging Page)
        {
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
            var model = AboutCateMan.GetBySN(Convert.ToInt32(id));
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = model;
            ViewData["About"] = About;
            return View(model);
        }

        public ActionResult Content(string id, AboutContent_Filter filter, Rest.Core.Paging Page)
        {
            if (filter.UnitName == "請輸入單元名稱搜尋") filter.UnitName = null;
            if (!string.IsNullOrEmpty(id)) filter = new AboutContent_Filter()
            {
                IsActive = Convert.ToInt32(false)
            };
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
            if (filter.UserName == "請輸入姓名搜尋") filter.UserName = null;
            if (!string.IsNullOrEmpty(id)) filter = new AboutTeam_Filter()
            {
                IsActive = Convert.ToInt32(false)
            };
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
        */

    }
}