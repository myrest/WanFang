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
            if (sessionData.trading != null && sessionData.trading.Dept != null && sessionData.trading.Dept.HasValue)
            {
                ViewData["Dept"] = sessionData.trading.Dept.Value;//WS_Dept_type
                ViewData["DeptName"] = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                ViewData["CostName"] = sessionData.trading.CostName;
            }
        }

        public ActionResult NewsData(NewsData_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("衛教園區管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (filter.Title == "請輸入標題搜尋") filter.Title = null;
            if (filter.DeptName == "請選擇") filter.DeptName = null;
            //公領域
            filter.IsPrivate = 0;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<NewsData_Info> data = NewsDataMan.GetByParameter(filter, page, null, "PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            ViewData["DeptName"] = filter.DeptName;//不預設搜尋條件
            return View();
        }

        public ActionResult NewsDataPrivate(NewsData_Filter filter, Rest.Core.Paging Page)
        {
            ViewData["MenuItem"] = 9;
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                if (filter.Title == "請輸入標題搜尋") filter.Title = null;
                if (filter.DeptName == "請選擇") filter.DeptName = null;
                //私領域
                filter.IsPrivate = 1;
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.Cost = sessionData.trading.CostName;
                }
                else
                {
                    ViewData["DeptName"] = filter.DeptName;//不預設搜尋條件
                }
                ViewData["Filter"] = filter;

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<NewsData_Info> data = NewsDataMan.GetByParameter(filter, page, null, "PublishDate desc");
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                return View("~/Views/Page6/NewsData.aspx");
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

        public ActionResult EditNewsData(string id, string IsPrivate)
        {
            //Clear old data.
            ClearOldData("NewsDataImage");
            var model = NewsDataMan.GetBySN(Convert.ToInt32(id));
            if (IsPrivate == "1")
            {
                ViewData["MenuItem"] = 9;
                //私領域預設直接載入該診別
                ViewData["DeptType"] = sessionData.trading.Dept.Value;
                if (model == null)
                {
                    model = new NewsData_Info();
                    model.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    model.Cost = sessionData.trading.CostName;
                }
            }
            else
            {
                //公領域直接載入該診別
                ViewData["DeptType"] = null;
            }
            ViewData["IsPrivate"] = (IsPrivate == "1");
            ViewData["Model"] = model;
            
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