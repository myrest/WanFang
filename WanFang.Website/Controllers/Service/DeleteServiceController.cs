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

namespace WanFang.Website.Controllers.Service
{
    public class DeleteServiceController : BaseController
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(DeleteServiceController));
        private static readonly About_Manager AboutMan = new About_Manager();
        private static readonly AboutCategory_Manager AboutCatMan = new AboutCategory_Manager();
        private static readonly AboutContent_Manager AboutContMan = new AboutContent_Manager();
        private static readonly AboutTeam_Manager AboutTeamMan = new AboutTeam_Manager();

        private static readonly User_Manager UserMan = new User_Manager();
        private static readonly WebDownload_Manager WebDownloadman = new WebDownload_Manager();
        private static readonly CostUnit_Manager CostUnitMan = new CostUnit_Manager();
        private static readonly CostNews_Manager CostNewsman = new CostNews_Manager();

        private static readonly Doc_Manager DocMan = new Doc_Manager();
        private static readonly CostKeyword_Manager CostKeyMan = new CostKeyword_Manager();

        public DeleteServiceController()
            : base(Permission.Public)
        {
        }

        [HttpPost]
        public JsonResult DeleteAbout(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    var catdata = AboutCatMan.GetByParameter(new AboutCategory_Filter()
                    {
                        AboutId = sn
                    });
                    if (catdata != null && catdata.Count > 0)
                    {
                        result.setErrorMessage("其下有[萬芳系列]資料，無法刪除。");
                        break;
                    }
                    var condata = AboutContMan.GetByParameter(new AboutContent_Filter()
                    {
                        AboutId = sn
                    });
                    if (condata != null && condata.Count > 0)
                    {
                        result.setErrorMessage("其下有[萬芳圖文]資料，無法刪除。");
                        break;
                    }
                    AboutMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteAboutCategoary(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    var condata = AboutContMan.GetByParameter(new AboutContent_Filter()
                    {
                        AboutId = sn
                    });
                    if (condata != null && condata.Count > 0)
                    {
                        result.setErrorMessage("其下有[萬芳圖文]資料，無法刪除。");
                        break;
                    }
                    AboutCatMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteAboutContent(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    AboutContMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteAboutTeam(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    AboutTeamMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    UserMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteDownLoad(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    WebDownloadman.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteCostUnit(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    CostUnitMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteNews(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    CostNewsman.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteDoc(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    DocMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteCostKeyword(string[] id)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (id != null)
            {
                foreach (string x in id)
                {
                    int sn = Convert.ToInt32(x);
                    CostKeyMan.Delete(sn);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}