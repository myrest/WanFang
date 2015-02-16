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

        public ActionResult TeamIntroduce(TeamIntroduce_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("團隊介紹管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.ContentBody) && filter.ContentBody.StartsWith("請輸入")) filter.ContentBody = null;
            if (filter != null && !string.IsNullOrEmpty(filter.CostName) && filter.CostName.StartsWith("請選擇")) filter.CostName = null;
            if (filter != null && !string.IsNullOrEmpty(filter.DeptName) && filter.DeptName.StartsWith("請選擇")) filter.DeptName = null;
            if (!string.IsNullOrEmpty(filter.DeptName))
            {
                filter.DeptName = EnumHelper.GetEnumDescription<WS_Dept_type>(EnumHelper.GetEnumByName<WS_Dept_type>(filter.DeptName));
            }

            ViewData["Filter"] = filter;

            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<TeamIntroduce_Info> data = TeamMan.GetByParameter(filter, page, null, "TeamIntroduceId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditTeamIntroduce(string id)
        {
            //Clear old data.
            ClearOldData("TeamIntroduceImage");
            var model = TeamMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

    }
}