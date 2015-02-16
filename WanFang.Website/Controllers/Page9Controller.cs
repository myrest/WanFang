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
        private static readonly Doc_Manager DocMan = new Doc_Manager();
        private static readonly CostKeyword_Manager CostKeyMan = new CostKeyword_Manager();

        public Page9Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 9;
            if (sessionData.trading != null && sessionData.trading.Dept != null && sessionData.trading.Dept.HasValue)
            {
                ViewData["Dept"] = sessionData.trading.Dept.Value;//WS_Dept_type
                ViewData["DeptName"] = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                ViewData["CostName"] = sessionData.trading.CostName;
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

        public ActionResult Doc(Doc_Filter filter, Rest.Core.Paging Page)
        {
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                if (filter.DocName == "請輸入醫師中文名字或醫師員編搜尋") filter.DocName = null;
                if (filter.CostName == "請選擇") filter.CostName = null;
                if (filter.DeptName == "請選擇") filter.DeptName = null;
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.CostName = sessionData.trading.CostName;
                }
                if (filter.DeptName != null && filter.DeptName.Length == 1)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(EnumHelper.GetEnumByName<WS_Dept_type>(filter.DeptName));
                }

                ViewData["Filter"] = filter;

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<Doc_Info> data = DocMan.GetByParameter(filter, page, null, "seq_id desc, DocId desc");
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                return View();
            }
        }

        public ActionResult EditDoc(string id)
        {
            //Clear old data.
            ClearOldData("DocPic");
            var model = DocMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult Index(CostUnit_Filter filter)
        {
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                WanFang.BLL.CostUnit_Manager man = new WanFang.BLL.CostUnit_Manager();
                if (filter.UnitName == "請輸入單元名稱搜尋") filter.UnitName = null;
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.CostName = sessionData.trading.CostName;
                }
                Rest.Core.Paging page = new Rest.Core.Paging() { ItemsPerPage = 9999 };
                string sortingby = "SortNum";
                if (sessionData.trading.IsVerifier)
                {
                    sortingby = "DeptName, CostName, SortNum";
                }
                var data = man.GetByParameter(filter, page, null, sortingby);
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
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.CostName = sessionData.trading.CostName;
                }

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
                if (!string.IsNullOrEmpty(filter.Subject) && filter.Subject.StartsWith("請輸入")) filter.Subject = null;
                ViewData["Filter"] = filter;
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.CostName = sessionData.trading.CostName;
                }

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<CostNews_Info> data = CostNewsMan.GetByParameter(filter, page, null, "PublishDate desc");
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                ViewData["Filter"] = filter;
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

        public ActionResult CostKeyword(CostKeyword_Filter filter, Rest.Core.Paging Page)
        {
            //var PermissionCheck = CheckPermission("團隊介紹管理");
            //if (PermissionCheck != null) return PermissionCheck;
            if (!sessionData.trading.Dept.HasValue)
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            else
            {
                if (filter != null && !string.IsNullOrEmpty(filter.KeyWord) && filter.KeyWord.StartsWith("請輸入")) filter.KeyWord = null;
                if (filter != null && !string.IsNullOrEmpty(filter.CostName) && filter.CostName.StartsWith("請選擇")) filter.CostName = null;
                if (filter != null && !string.IsNullOrEmpty(filter.DeptName) && filter.DeptName.StartsWith("請選擇")) filter.DeptName = null;
                if (!sessionData.trading.IsVerifier)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(sessionData.trading.Dept.Value);
                    filter.CostName = sessionData.trading.CostName;
                }
                if (filter.DeptName != null && filter.DeptName.Length == 1)
                {
                    filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(EnumHelper.GetEnumByName<WS_Dept_type>(filter.DeptName));
                }

                ViewData["Filter"] = filter;

                Rest.Core.Paging page = new Rest.Core.Paging() { };
                if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
                List<CostKeyword_Info> data = CostKeyMan.GetByParameter(filter, page, null, "CostKeywordId desc");

                WebService_Manage service = new WanFang.BLL.WebService_Manage();
                var Dept = service.GetAllDept();
                ViewData["AllDept"] = Dept;
                ViewData["Model"] = data;
                ViewData["Page"] = page;
                return View();
            }
        }

        public ActionResult EditCostKeyword(string id)
        {
            var model = CostKeyMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}