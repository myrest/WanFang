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
    public class Page10Controller : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page10Controller));

        private static readonly Op_Qa_Manager QAMan = new Op_Qa_Manager();
        private static readonly Question_Manager QMan = new Question_Manager();
        private static readonly Nhi_Qa_Manager NQMan = new Nhi_Qa_Manager();

        public Page10Controller()
            : base(Permission.Private)
        {
            ViewData["MenuItem"] = 10;
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

        public ActionResult Op_Qa(Op_Qa_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("詢問台管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.op_title) && filter.op_title.StartsWith("請輸入")) filter.op_title = null;
            if (filter != null && !string.IsNullOrEmpty(filter.op_type) && filter.op_type.StartsWith("請選擇")) filter.op_type = null;

            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Op_Qa_Info> data = QAMan.GetByParameter(filter, page, null, "Op_QaId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditOp_Qa(string id)
        {
            //Clear old data.
            ClearOldData("Op_Qa");
            var model = QAMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult Question(Question_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("詢問台管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.Q_question) && filter.Q_question.StartsWith("請輸入")) filter.Q_question = null;
            if (filter != null && !string.IsNullOrEmpty(filter.Q_type) && filter.Q_type.StartsWith("請選擇")) filter.Q_type = null;
            if (filter != null && !string.IsNullOrEmpty(filter.CostName) && filter.CostName.StartsWith("請選擇")) filter.CostName = null;
            if (filter != null && !string.IsNullOrEmpty(filter.Dept) && filter.Dept.StartsWith("請選擇")) filter.Dept = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Question_Info> data = QMan.GetByParameter(filter, page, null, "QuestionId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditQuestion(string id)
        {
            //Clear old data.
            ClearOldData("Question");
            var model = QMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult Nhi_Qa(Nhi_Qa_Filter filter, Rest.Core.Paging Page)
        {
            var PermissionCheck = CheckPermission("詢問台管理");
            if (PermissionCheck != null) return PermissionCheck;

            if (!string.IsNullOrEmpty(filter.nhi_title) && filter.nhi_title.StartsWith("請輸入")) filter.nhi_title = null;
            ViewData["Filter"] = filter;
            Rest.Core.Paging page = new Rest.Core.Paging() { };
            if (Page.CurrentPage > 0) page.CurrentPage = Page.CurrentPage;
            List<Nhi_Qa_Info> data = NQMan.GetByParameter(filter, page, null, "Nhi_QaId desc");
            ViewData["Model"] = data;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult EditNhi_Qa(string id)
        {
            //Clear old data.
            ClearOldData("Nhi_Qa");
            var model = NQMan.GetBySN(Convert.ToInt32(id));
            ViewData["Model"] = model;
            return View();
        }
    }
}