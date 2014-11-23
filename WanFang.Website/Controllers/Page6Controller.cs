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
    public class Page6Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page6Controller));
        private static readonly NewsData_Manager NewsDataMan = new NewsData_Manager();
        private static readonly Edu_Manager EduMan = new Edu_Manager();

        public Page6Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 6;
        }

        public ActionResult NewsData(NewsData_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("衛教園區管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (filter.Title == "請輸入標題搜尋") filter.Title = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<NewsData_Info> data = NewsDataMan.GetByParameter(filter, page, null, "PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
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

        public ActionResult EditNewsData(string id)
        {
            //Clear old data.
            ClearOldData("NewsDataImage");
            var model = NewsDataMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;

            WebService_Manage service = new WanFang.BLL.WebService_Manage();
            var Dept = service.GetAllDept();
            ViewData["AllDept"] = Dept;
            
            return View();
        }

        public ActionResult Edu(Edu_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("衛教園區管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (filter.Title == "請輸入衛教標題搜尋") filter.Title = null;
            if (filter != null && !string.IsNullOrEmpty(filter.EduType) && filter.EduType.StartsWith("請選擇")) filter.EduType = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Edu_Info> data = EduMan.GetByParameter(filter, page, null, "EduDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditEdu(string id)
        {
            //Clear old information
            if (sessionData.trading.UploadFiles != null && sessionData.trading.UploadFiles.Count > 0)
            {
                //Clear old information
                sessionData.trading.UploadFiles.Where(x => x.Key.StartsWith("Edu")).ToList().ForEach(x =>
                {
                    sessionData.trading.UploadFiles.Remove(x.Key);
                });
            }

            var model = EduMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}