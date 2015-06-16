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
    public class Page14Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page14Controller));

        private static readonly Report_Manager DiaryMan = new Report_Manager();

        public Page14Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 14;
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

        public ActionResult Report(Report_Filter filter, Rest.Core.Paging Page)
        {
            //var PermissionCheck = CheckPermission("最新消息管理");
            //if (PermissionCheck != null) return PermissionCheck;
            if (!filter.DaysOfPeroid.HasValue || filter.DaysOfPeroid.Value > 120)
            {
                filter.DaysOfPeroid = 30;
            }
            if (!string.IsNullOrEmpty(filter.ItemName) && filter.ItemName.StartsWith("請輸入")) filter.ItemName = null;
            if (!string.IsNullOrEmpty(filter.Url) && filter.Url.StartsWith("請輸入")) filter.Url = null;
            
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Report_Info> data = DiaryMan.GetByParameter(filter, page, null, "CreateDateTime desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditReport(string id)
        {
            //Clear old data.
            ClearOldData("Report");
            var model = DiaryMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}