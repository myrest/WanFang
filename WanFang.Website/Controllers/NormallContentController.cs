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
    public class NormallContentController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(NormallContentController));
        private static readonly NormallContent_Manager NContMan = new NormallContent_Manager();

        public NormallContentController()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 1;
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

        public ActionResult Content(string id, NormallContent_Filter filter, Rest.Core.Paging Page)
        {
            ViewData["MenuItem"] = 8;
            if (!string.IsNullOrEmpty(filter.UnitName) && filter.UnitName.StartsWith("請輸入")) filter.UnitName = null;
            if (!string.IsNullOrEmpty(id)) filter = new NormallContent_Filter()
            {
                IsActive = Convert.ToInt32(false)
            };
            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<NormallContent_Info> data = NContMan.GetByParameter(filter, page, null, "AboutId, AboutCategoryId");
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            List<AboutCategory_Info> Categoary = AboutCateMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = data;
            ViewData["About"] = About;
            ViewData["Categoary"] = Categoary;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditNormallContent(string id)
        {
            ViewData["MenuItem"] = 8;
            var model = NContMan.GetBySN(Convert.ToInt32(id));
            List<About_Info> About = AboutMan.GetAll().OrderBy(x => x.SortNum).ToList();
            List<AboutCategory_Info> Categoary = AboutCateMan.GetAll().OrderBy(x => x.SortNum).ToList();
            ViewData["Model"] = model;
            ViewData["About"] = About;
            ViewData["Categoary"] = Categoary;
            return View(model);
        }
    }
}