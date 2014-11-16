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
    public class ManageLoginServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ManageLoginServiceController));
        private static readonly User_Manager UserMan = new User_Manager();
        private static readonly LogLogin_Manager LogLoginMan = new LogLogin_Manager();

        public ManageLoginServiceController()
            : base(Permission.Public)
        {
        }

        private void MakeTrading(string LoginId)
        {
            Trading trading = new Trading() { };
            var user = UserMan.GetByParameter(new User_Filter()
            {
                LoginId = LoginId
            }).FirstOrDefault();

            trading.LoginId = LoginId;
            trading.UserName = user.UserName;
            trading.UserID = user.UserID;
            trading.IsVerifier = (user.IsVerifier == 1);
            if (user.PermissionType == 0)
            {
                trading.IsDeptOnly = true;
                if (!string.IsNullOrEmpty(user.DeptName))
                {
                    trading.Dept = EnumHelper.GetEnumByName<WS_Dept_type>(user.DeptName);
                }
                else
                {
                    throw new Exception("私領域權限未設定");
                }

                if (user.IsVerifier == 1)//具有審核權，也可以具有公領域權限
                {
                    if (user.Permission != null)
                    {
                        trading.Permissions = user.Permission.Split(",".ToArray()).ToList();
                    }
                }
            }
            else
            {
                trading.IsDeptOnly = false;
                if (user.Permission != null)
                {
                    trading.Permissions = user.Permission.Split(",".ToArray()).ToList();
                }
                else
                {
                    throw new Exception("公領域權限未設定");
                }
            }
            trading.UploadFiles = new System.Collections.Generic.Dictionary<string, string>() { };
            sessionData.trading = trading;
        }

        [HttpPost]
        public JsonResult Login(User_Info UserInfo)
        {
            bool LoginResult = UserMan.Login(UserInfo.LoginId, UserInfo.Password);
            var logresult = LogLoginMan.Insert(new LogLogin_Info()
            {
                CreateDateTime = DateTime.Now,
                IsPass = Convert.ToInt32(LoginResult),
                LoginId = UserInfo.LoginId,
                LoginIP = IPHelper.GetClientIpAddress(),
                Password = UserInfo.Password
            });
            ResultBase result = new ResultBase();
            if (LoginResult)
            {
                MakeTrading(UserInfo.LoginId);
                result.setMessage("Done");
            }
            else
            {
                result.setErrorMessage("帳號密碼錯誤。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Logout()
        {
            if (sessionData != null && sessionData.trading != null)
            {
                sessionData.Logout();
            }
            ResultBase r = new ResultBase();
            r.setMessage("您已登出。");
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}