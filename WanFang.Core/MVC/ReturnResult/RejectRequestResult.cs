using log4net;
using System.Text;
using System.Web.Mvc;

namespace WanFang.Core.MVC.ReturnResult
{
    public class RejectRequestResult
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RejectRequestResult));
        private static readonly string HomePageUrl = "/";

        public static void RejectRequest(ActionExecutingContext filterContext, RejectReason reason, SessionData sessionData)
        {
            string logoutUrl = "/LoginService/Logout";

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = GetNoPermisionJsonResult(reason, logoutUrl);
            }
            else
            {
                filterContext.Result = GetNoPermisionRedirectResult(reason, HomePageUrl);
            }
        }

        public static void RejectRequest(AuthorizationContext filterContext, RejectReason reason, SessionData sessionData)
        {
            string logoutUrl = "/LoginService/Logout";

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = GetNoPermisionJsonResult(reason, logoutUrl);
            }
            else
            {
                filterContext.Result = GetNoPermisionRedirectResult(reason, HomePageUrl);
            }
        }

        public static void RejectRequest(ExceptionContext filterContext, RejectReason reason, SessionData sessionData)
        {
            string logoutUrl = "/LoginService/Logout";

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = GetNoPermisionJsonResult(reason, logoutUrl);
            }
            else
            {
                filterContext.Result = GetNoPermisionRedirectResult(reason, HomePageUrl);
            }
        }

        private static ActionResult GetNoPermisionRedirectResult(RejectReason reason, string logoutUrl)
        {
            log.InfoFormat("Member Kicked Out. Reason: {0}. Redirect permanently(301) to {1}", reason.ToString(), logoutUrl);
            return new PermanentRedirectResult(logoutUrl, true);
        }

        private static ActionResult GetNoPermisionJsonResult(RejectReason reason, string logoutUrl)
        {
            object Reject = new RejectResult(reason, logoutUrl);

            return new JsonDataContractResult
            {
                Data = Reject,
                ContentType = "",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}