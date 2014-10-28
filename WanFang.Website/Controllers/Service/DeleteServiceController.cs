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
    }
}