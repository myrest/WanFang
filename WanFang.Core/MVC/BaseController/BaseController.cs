using CWB.Web.Configuration;

using WanFang.Core.MVC.ReturnResult;
using Rest.Core.Utility;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WanFang.Core.Constancy;

namespace WanFang.Core.MVC.BaseController
{
    public class BaseController : Controller
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(BaseController));

        protected Permission ControllerPermision { get; set; }

        protected SessionData sessionData = new SessionData();

        protected BaseController(Permission permission)
        {
            ControllerPermision = permission;
        }

        protected ActionResult CheckPermission(string UnitName)
        {
            if (!sessionData.trading.Permissions.Contains(UnitName))
            {
                return View("~/Views/Manage/PermissionDeny.aspx");
            }
            return null;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = Json("Got Server Error, Please check with Administrator. Thansk!", JsonRequestBehavior.AllowGet);
            filterContext.ExceptionHandled = true;
            Log.Exception(filterContext.Exception);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewData["Verify"] = false;//Is Has verify 
            ViewData["EditForVerifier"] = false;//Is verify for edit.
            ViewData["IsDeptOnly"] = true;
            ViewData["Permission"] = string.Empty;
            if (sessionData != null && sessionData.trading != null && sessionData.trading.IsVerifier)
            {
                ViewData["Verify"] = true;
                string EditForVerifier = filterContext.RequestContext.HttpContext.Request["Verify"];
                if (!string.IsNullOrEmpty(EditForVerifier))
                {
                    ViewData["EditForVerifier"] = true;
                }
            }

            if (sessionData != null && sessionData.trading != null)
            {
                ViewData["IsDeptOnly"] = sessionData.trading.IsDeptOnly;
                ViewData["Permission"] = sessionData.trading.Permissions;
            }
            base.OnResultExecuting(filterContext);
            //add P3P header to make sure the pages inside other frames able to use cookies
            filterContext.HttpContext.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            throw new HttpException(404, "");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetOmitVaryStar(true);
            ViewData["_v"] = AppConfigManager.SystemSetting.StaticFileVersionNumber;
            if (sessionData != null && sessionData.trading != null)
            {
                ViewData["_UserID"] = sessionData.trading.UserID;
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (ControllerPermision != Permission.Public)
            {
                if (sessionData.trading != null)
                {
                    if (string.IsNullOrEmpty(sessionData.trading.LoginId))
                    {
                        Log.Debug("Session Lost");
                        RejectRequestResult.RejectRequest(filterContext, RejectReason.SessionLost, sessionData);
                    }
                }
                else
                {
                    Log.Debug("Session Lost");
                    RejectRequestResult.RejectRequest(filterContext, RejectReason.SessionLost, sessionData);
                }
            }
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonDataContractResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}