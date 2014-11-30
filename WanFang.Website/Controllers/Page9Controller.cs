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

        private void ClearOldData(string Prefix)
        {
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith(Prefix)).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
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
                WanFang.BLL.CostUnit_Manager man = new WanFang.BLL.CostUnit_Manager();
                CostUnit_Filter filter = new CostUnit_Filter() { }; 
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                }

                var data = man.GetByParameter(filter, null, null, "SortNum");
                ViewData["Model"] = data;
                return View();
            }
        }

        public ActionResult EditCostUnit(string id)
        {
            ClearOldData("CostUnitImage");
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
            ClearOldData("WebDownLoad");
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
            ClearOldData("CostNews");

            var model = CostNewsMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

    }
}