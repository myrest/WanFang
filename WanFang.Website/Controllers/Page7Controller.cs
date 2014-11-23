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
    public class Page7Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page7Controller));

        private static readonly HirCategory_Manager CHMan = new HirCategory_Manager();
        private static readonly HirDetail_Manager HdMan = new HirDetail_Manager();

        public Page7Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 7;
        }

        public ActionResult HirCategory(HirCategory_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("人員募集管理");
            if (PermissionCheck != null) return PermissionCheck;

            //if (!string.IsNullOrEmpty(filter.op_title) && filter.op_title.StartsWith("請輸入")) filter.op_title = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            Page.ItemsPerPage = 9999;//不分頁
            List<HirCategory_Info> data = CHMan.GetByParameter(filter, page, null, "SortNum");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditHirCategory(string id)
        {
            var model = CHMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult HirDetail(HirDetail_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("人員募集管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.JobTitle) && filter.JobTitle.StartsWith("請")) filter.JobTitle = null;
            if (!string.IsNullOrEmpty(filter.CostName) && filter.CostName.StartsWith("請輸入")) filter.CostName = null;
            if (!string.IsNullOrEmpty(filter.HirName) && filter.HirName.StartsWith("請選擇")) filter.HirName = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<HirDetail_Info> data = HdMan.GetByParameter(filter, page, null, "PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditHirDetail(string id)
        {
            var model = HdMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}