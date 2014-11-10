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
    public class Page8ServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(Page8ServiceController));

        private static readonly Nhi_p_Manager Nhi_pMan = new Nhi_p_Manager();
        private static readonly Nhi_Med_Manager MedMan = new Nhi_Med_Manager();

        public Page8ServiceController()
            : base(Permission.Public)
        {
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNhi_p(Nhi_p_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.nhi_code))
            {
                result.setErrorMessage("特材類型為必選");
            }
            if (string.IsNullOrEmpty(data.nhi_type))
            {
                result.setErrorMessage("品項名稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.nhi_cname))
            {
                result.setErrorMessage("中文品名不得為空白");
            }
            if (string.IsNullOrEmpty(data.nhi_ename))
            {
                result.setErrorMessage("英文品名 / 許可證號不得為空白");
            }
            if (string.IsNullOrEmpty(data.fee_code))
            {
                result.setErrorMessage("院內代碼不得為空白");
            }
            if (string.IsNullOrEmpty(data.HealthCode))
            {
                result.setErrorMessage("健保代碼不得為空白");
            }
            if (string.IsNullOrEmpty(data.mark_name))
            {
                result.setErrorMessage("品項代碼 / 廠牌名稱不得為空白");
            }
            if (string.IsNullOrEmpty(data.unit))
            {
                result.setErrorMessage("計價單位不得為空白");
            }
            if (string.IsNullOrEmpty(data.nhi_cost))
            {
                result.setErrorMessage("健保金額不得為空白");
            }
            if (string.IsNullOrEmpty(data.self_cost))
            {
                result.setErrorMessage("自費金額不得為空白");
            }
            if (string.IsNullOrEmpty(data.price_dif))
            {
                result.setErrorMessage("自付差額不得為空白");
            }
            if (string.IsNullOrEmpty(data.warnings))
            {
                result.setErrorMessage("警語不得為空白");
            }
            if (data.nhi_date == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = Nhi_pMan.GetBySN(data.nhi_pId);
                //checkUploadfiles(data, olddata);
                if (data.nhi_pId > 0)
                {
                    data.hit = olddata.hit;
                    Nhi_pMan.Update(data);
                }
                else
                {
                    Nhi_pMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SaveNhi_Med(Nhi_Med_Info data)
        {
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (string.IsNullOrEmpty(data.PNameOld))
            {
                result.setErrorMessage("中文品名_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.PCodeOld))
            {
                result.setErrorMessage("院內碼_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.CodeOld))
            {
                result.setErrorMessage("健保代碼_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.ScientificNameOld))
            {
                result.setErrorMessage("學品名_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.PNameAndNumOld))
            {
                result.setErrorMessage("商品名/含量_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.CompanyNameOld))
            {
                result.setErrorMessage("藥商名稱 _舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.SuitOld))
            {
                result.setErrorMessage("適應症 _舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.UsageOld))
            {
                result.setErrorMessage("用法用量_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.SideEffectOld))
            {
                result.setErrorMessage("副作用_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.NotificationOld))
            {
                result.setErrorMessage("禁忌及其他注意事項_舊不得為空白");
            }
            if (string.IsNullOrEmpty(data.PName))
            {
                result.setErrorMessage("中文品名_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.PCode))
            {
                result.setErrorMessage("院內碼_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.Code))
            {
                result.setErrorMessage("健保代碼_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.ScientificName))
            {
                result.setErrorMessage("學品名_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.PNameEng))
            {
                result.setErrorMessage("商品名/含量_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.CompanyName))
            {
                result.setErrorMessage("藥商名稱 _新不得為空白");
            }
            if (string.IsNullOrEmpty(data.Suit))
            {
                result.setErrorMessage("適應症 _新不得為空白");
            }
            if (string.IsNullOrEmpty(data.Usage))
            {
                result.setErrorMessage("用法用量_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.SideEffect))
            {
                result.setErrorMessage("副作用_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.Notification))
            {
                result.setErrorMessage("禁忌及其他注意事項_新不得為空白");
            }
            if (string.IsNullOrEmpty(data.ModifiedContent))
            {
                result.setErrorMessage("異動內容不得為空白");
            }
            if (data.PublishDate == DateTime.MinValue)
            {
                result.setErrorMessage("發布日期格式錯誤，正確格式為YYYY/MM/DD");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                var olddata = MedMan.GetBySN(data.MedicationID);
                checkUploadfiles(data, olddata);
                if (string.IsNullOrEmpty(data.ImageOld))
                {
                    result.setErrorMessage("[藥品照片_舊]必需上傳");
                }
                if (string.IsNullOrEmpty(data.Image))
                {
                    result.setErrorMessage("[藥品照片_新]必需上傳");
                }
                if (data.MedicationID > 0)
                {
                    data.HitOld = olddata.HitOld;
                    MedMan.Update(data);
                }
                else
                {
                    MedMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private void checkUploadfiles(Nhi_Med_Info NewData, Nhi_Med_Info OldData)
        {
            if (OldData == null) OldData = new Nhi_Med_Info();
            string Prefix = string.Empty;
            Prefix = "Nhi_MedImageOld";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.ImageOld = string.Empty;
                }
                else
                {
                    NewData.ImageOld = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.ImageOld = OldData.ImageOld;
            }

            Prefix = "Nhi_MedImage";
            if (sessionData.trading.UploadFiles.Keys.Contains(Prefix))
            {
                if (string.Compare("DELETE", sessionData.trading.UploadFiles[Prefix], true) == 0)
                {
                    NewData.Image = string.Empty;
                }
                else
                {
                    NewData.Image = CopyFile(sessionData.trading.UploadFiles[Prefix]);
                }
            }
            else
            {
                NewData.Image = OldData.Image;
            }
        }

        private string CopyFile(string Source)
        {
            string NewName = "/Upload/" + Path.GetFileName(Source);
            Source = string.Format("{0}/{1}", Server.MapPath("~/"), Source);
            string Target = string.Format("{0}{1}", Server.MapPath("~/"), NewName);
            if (System.IO.File.Exists(Source))
            {
                FileInfo f = new FileInfo(Source);
                f.MoveTo(Target);
            }
            return NewName;
        }

    }
}