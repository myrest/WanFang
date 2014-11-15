using System;
using System.Linq;
using System.Web.Mvc;
using CWB.Web.Configuration;
using Rest.Core.Utility;
using WanFang.BLL;
using WanFang.Core;
using WanFang.Core.Constancy;
using WanFang.Core.MVC.BaseController;
using WanFang.Core.Utility;
using WanFang.Domain;
using WanFang.Domain.Constancy;
using WanFang.Website.Models;
using System.IO;

namespace WanFang.Website.Controllers.Service
{
    public class Page10ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page10ServiceController));

        private static readonly Op_Qa_Manager OQMan = new Op_Qa_Manager();
        private static readonly Question_Manager QMan = new Question_Manager();
        private static readonly Nhi_Qa_Manager NQMan = new Nhi_Qa_Manager();

        public Page10ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveOp_Qa(Op_Qa_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = OQMan.GetBySN(data.Op_QaId);
                verdata.IsActive = 1;
                OQMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            if (string.IsNullOrEmpty(data.op_title))
            {
                result.setErrorMessage("問題標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.op_content))
            {
                result.setErrorMessage("回覆內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = OQMan.GetBySN(data.Op_QaId);
                //checkUploadfiles(data, olddata);
                if (data.Op_QaId > 0)
                {
                    //Keep the existing data.
                    data.hit = olddata.hit;
                    OQMan.Update(data);
                }
                else
                {
                    OQMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveQuestion(Question_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.Q_time == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (string.IsNullOrEmpty(data.DeptName))
            {
                result.setErrorMessage("診別不得為空白");
            }
            if (string.IsNullOrEmpty(data.Q_title))
            {
                result.setErrorMessage("提問標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.Q_question))
            {
                result.setErrorMessage("問題內容不得為空白");
            }
            if (string.IsNullOrEmpty(data.Q_ans))
            {
                result.setErrorMessage("回覆內容不得為空白");
            }
            if (string.IsNullOrEmpty(data.Q_edit))
            {
                result.setErrorMessage("回覆者不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = OQMan.GetBySN(data.QuestionId);
                //checkUploadfiles(data, olddata);
                if (data.QuestionId > 0)
                {
                    //Keep the existing data.
                    data.hit = olddata.hit;
                    QMan.Update(data);
                }
                else
                {
                    QMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNhi_Qa(Nhi_Qa_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.nhi_date == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (string.IsNullOrEmpty(data.nhi_title))
            {
                result.setErrorMessage("問題標題不得為空白");
            }
            if (string.IsNullOrEmpty(data.Description))
            {
                result.setErrorMessage("清單頁簡述不得為空白");
            }
            if (string.IsNullOrEmpty(data.nhi_con))
            {
                result.setErrorMessage("回覆內容不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                //var olddata = OQMan.GetBySN(data.Nhi_QaId);
                //checkUploadfiles(data, olddata);
                if (data.Nhi_QaId > 0)
                {
                    NQMan.Update(data);
                    
                }
                else
                {
                    NQMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

    }
}