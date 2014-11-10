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

        private ActionResult GetContent(string id, NormallContent_Filter filter, Rest.Core.Paging Page, string Catgoary)
        {
            filter.ContentName = Catgoary;
            if (!string.IsNullOrEmpty(filter.UnitName) && filter.UnitName.StartsWith("請輸入")) filter.UnitName = null;
            if (!string.IsNullOrEmpty(id)) filter = new NormallContent_Filter()
            {
                IsActive = Convert.ToInt32(false)
            };
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<NormallContent_Info> data = NContMan.GetByParameter(filter, page, null, "NormallContentId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View("~/Views/NormallContent/Content.aspx");
        }

        public ActionResult Page8Content(string id, NormallContent_Filter filter, Rest.Core.Paging Page)
        {
            ViewData["MenuItem"] = 8;
            ViewData["Header1"] = "健保專區圖文管理";
            ViewData["Header2"] = "健保專區管理";
            ViewData["EditPage"] = "EditPage8Content";
            ActionResult result = GetContent(id, filter, Page, ViewData["Header1"].ToString());
            return result;
        }

        public ActionResult EditPage8Content(string id)
        {
            ClearOldData("NormallContent");
            ViewData["MenuItem"] = 8;
            ViewData["Header1"] = "健保專區圖文管理";
            ViewData["Header2"] = "健保專區管理";
            ViewData["GoBack"] = "Page8Content";
            var model = NContMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View("~/Views/NormallContent/EditContent.aspx");
        }
    }
}