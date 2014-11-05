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
    public class Page3Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page3Controller));

        private static readonly Pilates_Manager PilatesMan = new Pilates_Manager();

        public Page3Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 3;
        }

        public ActionResult Pilates(Pilates_Filter filter, Rest.Core.Paging Page)
        {
            if (!string.IsNullOrEmpty(filter.RegSubject) && filter.RegSubject.StartsWith("請輸入")) filter.RegSubject = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Pilates_Info> data = PilatesMan.GetByParameter(filter, page, null, "PilatesId, PublishDate desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditPilates(string id)
        {
            var model = PilatesMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}