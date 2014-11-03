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
    public class Page5Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page5Controller));
        private static readonly Doc_Manager DocMan = new Doc_Manager();
        private static readonly CostKeyword_Manager CostKeyMan = new CostKeyword_Manager();
        private static readonly TeamIntroduce_Manager TeamMan = new TeamIntroduce_Manager();
        
        
        private static readonly NewsData_Manager NewsDataMan = new NewsData_Manager();
        private static readonly Edu_Manager EduMan = new Edu_Manager();

        public Page5Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 5;
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
            if (filter.DocName == "請輸入醫師中文名字或醫師員編搜尋") filter.DocName = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Doc_Info> data = DocMan.GetByParameter(filter, page, null, "seq_id desc, DocId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditDoc(string id)
        {
            //Clear old data.
            ClearOldData("DocPic");
            var model = DocMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult CostKeyword(CostKeyword_Filter filter, Rest.Core.Paging Page)
        {
            if (filter.KeyWord == "請輸入關鍵字搜尋") filter.KeyWord = null;
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

        public ActionResult EditCostKeyword(string id)
        {
            var model = CostKeyMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult TeamIntroduce(TeamIntroduce_Filter filter, Rest.Core.Paging Page)
        {
            if (filter.WebMenuName.StartsWith("請輸入")) filter.WebMenuName = null;
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<TeamIntroduce_Info> data = TeamMan.GetByParameter(filter, page, null, "DocId desc");
            WebService_Manage service = new WanFang.BLL.WebService_Manage();
            var Dept = service.GetAllDept();
            ViewData["AllDept"] = Dept;
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditTeamIntroduce(string id)
        {
            //Clear old data.
            ClearOldData("TeamIntroduceImage");
            var model = NewsDataMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;

            WebService_Manage service = new WanFang.BLL.WebService_Manage();
            var Dept = service.GetAllDept();
            ViewData["AllDept"] = Dept;

            return View();
        }

    }
}