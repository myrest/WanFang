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
    public class ManageServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ManageServiceController));
        private static readonly User_Manager UserMan = new User_Manager();

        public ManageServiceController()
            : base(Permission.Public)
        {
        }

        [HttpPost]
        public JsonResult GetDeptInfo(string CostCode)
        {
            WanFang.BLL.WebService_Manage service = new WanFang.BLL.WebService_Manage();
            WS_Dept_type depttype = EnumHelper.GetEnumByName<WS_Dept_type>(CostCode);
            var Dept = service.GetAllDetailCostcerter(depttype);

            WS_DeptModel result = new WS_DeptModel();
            result.DeptList = Dept;
            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult SaveUser(User_Info data)
        {
            //check is there are any data under the categoary.
            ResultBase result = new ResultBase();
            result.setMessage("Done");
            if (data.LoginId.Trim().Length == 0)
            {
                result.setErrorMessage("登入帳號不得為空白");
            }
            if (data.UserID == 0 && string.IsNullOrEmpty(data.Password))
            {
                result.setErrorMessage("密碼不得為空白");
            }
            if (result.JsonReturnCode > -1)
            {
                data.LastUpdate = DateTime.Now;
                data.LastUpdator = sessionData.trading.LoginId;
                if (data.UserID > 0)
                {
                    var oldUser = UserMan.GetBySN(data.UserID);
                    if (string.IsNullOrEmpty(data.Password))
                    {
                        data.Password = oldUser.Password;
                        data.LoginId = oldUser.LoginId;
                    }
                    else
                    {
                        data.Password = Encrypt.EncryptPassword(data.Password, data.LoginId);
                    }
                    UserMan.Update(data);
                }
                else
                {
                    UserMan.Insert(data);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}