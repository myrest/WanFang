using System;
using System.Web.Mvc;

namespace WanFang.Core.MVC
{
    public class PermanentRedirectResult : ActionResult
    {
        private string _url;
        private int _statusCode;

        public PermanentRedirectResult(string url)
        {
            _url = url;
            _statusCode = 301;
        }

        public PermanentRedirectResult(string url, bool isTempRedirect)
        {
            _url = url;
            if (isTempRedirect)
            {
                _statusCode = 302;
            }
            else
            {
                _statusCode = 301;
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context can not null or empty");
            }
            if (context.IsChildAction)
            {
                throw new InvalidOperationException("Cannot Redirect In ChildAction");
            }
            context.Controller.TempData.Clear();
            context.HttpContext.Response.StatusCode = _statusCode;
            context.HttpContext.Response.ExpiresAbsolute = DateTime.Now;
            context.HttpContext.Response.RedirectLocation = _url;
        }
    }
}