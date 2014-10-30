using System.Web.Mvc;
using WanFang.Core.MVC.BaseController;
using Rest.Core.Utility;
using WanFang.Core.Constancy;
using WanFang.BLL;
using WanFang.Domain;
using System.Collections.Generic;
using System;
using WanFang.Domain.Webservice;


namespace WanFang.Website.Controllers
{
    public class ManageController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ManageController));

        public ManageController()
            : base(Permission.Public)
        {
            ViewData["MenuItem"] = 0;
        }

        public ActionResult Index(string id)
        {
            if (sessionData.trading != null)
            {
                return RedirectToAction("Welcome", "Manage");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult UserListing(User_Filter filter, Rest.Core.Paging Page)
        {
            ViewData["MenuItem"] = 12;
            if (filter.LoginId == "請輸入帳號搜尋") filter.LoginId = null;
            ViewData["Filter"] = filter;

            User_Manager man = new User_Manager();
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<User_Info> data = man.GetByParameter(filter, page, null, "LoginId");
            ViewData["Model"] = data;
            ViewData["Page"] = page;

            return View();
        }

        public ActionResult EditUser(string id)
        {
            User_Manager man = new User_Manager();
            var model = man.GetBySN(Convert.ToInt32(id));

            WebService_Manage service = new WanFang.BLL.WebService_Manage();
            //List<CostInformation> Cost = service.GetALLCostcerter();
            var Dept = service.GetAllDept();

            ViewData["Model"] = model;
            ViewData["AllDept"] = Dept;
            return View(model);
        }
    }
}