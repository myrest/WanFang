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
    public class Page7ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page7ServiceController));

        private static readonly HirCategory_Manager CHMan = new HirCategory_Manager();
        private static readonly HirDetail_Manager HdMan = new HirDetail_Manager();

        public Page7ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveHirCategory(HirCategory_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.CategoryName))
            {
                result.setErrorMessage("類別代號名稱不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                //var olddata = OQMan.GetBySN(data.HirCategoryId);
                //checkUploadfiles(data, olddata);
                if (data.HirCategoryId > 0)
                {
                    CHMan.Update(data);
                }
                else
                {
                    CHMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveHirDetail(HirDetail_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.IsActive == 1)
            {
                //審核專用
                var verdata = HdMan.GetBySN(data.HirDetailId);
                verdata.IsActive = 1;
                verdata.VerifiedDate = DateTime.Now;
                HdMan.Update(verdata);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            else
            {
                //一但有任何異動，自動下架
                data.IsActive = 0;
            }
            if (data.PublishDate == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (string.IsNullOrEmpty(data.CostName) || (data.CostName == "請選擇"))
            {
                result.setErrorMessage("職缺單位為必選");
            }
            if (string.IsNullOrEmpty(data.JobTitle))
            {
                result.setErrorMessage("職缺名稱不得為空白");
            }
            if (data.Nums == 0)
            {
                result.setErrorMessage("職缺數量不得為空白或為0");
            }
            if (string.IsNullOrEmpty(data.SchoolLimit))
            {
                result.setErrorMessage("學歷限制不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                //var olddata = HdMan.GetBySN(data.HirDetailId);
                //checkUploadfiles(data, olddata);
                if (data.HirDetailId > 0)
                {
                    HdMan.Update(data);
                }
                else
                {
                    HdMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}