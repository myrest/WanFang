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
    public class Page2Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page2Controller));

        private static readonly DiaryData_Manager DiaryMan = new DiaryData_Manager();

        public Page2Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 2;
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

        public ActionResult DiaryData(DiaryData_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("最新消息管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.Subject) && filter.Subject.StartsWith("請輸入")) filter.Subject = null;
            if (!string.IsNullOrEmpty(filter.DiaryType) && filter.DiaryType.StartsWith("全部顯示")) filter.DiaryType = null;
            
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<DiaryData_Info> data = DiaryMan.GetByParameter(filter, page, null, "DiaryType, PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditDiaryData(string id)
        {
            //Clear old data.
            ClearOldData("DiaryData");
            var model = DiaryMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}