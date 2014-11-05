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
    public class Page4Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page4Controller));

        private static readonly Guide_Manager GuideMan = new Guide_Manager();

        public Page4Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 4;
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

        public ActionResult Guide(Guide_Filter filter, Rest.Core.Paging Page)
        {
            if (!string.IsNullOrEmpty(filter.ItemName) && filter.ItemName.StartsWith("請輸入")) filter.ItemName = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Guide_Info> data = GuideMan.GetByParameter(filter, page, null, "GuideId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditGuide(string id)
        {
            //Clear old data.
            ClearOldData("Guide");
            var model = GuideMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}