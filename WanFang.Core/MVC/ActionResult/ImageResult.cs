using Rest.Core.Utility;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;

namespace WanFang.Core.MVC
{
    public class ImageResult : ActionResult
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ImageResult));

        public ImageResult()
        {
        }

        public ImageResult(ControllerContext context, Bitmap bmp)
        {
            context.Controller.TempData.Clear();
            try
            {
                context.HttpContext.Response.ContentType = "image/gif";
                bmp.Save(context.HttpContext.Response.OutputStream, ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
                Log.Debug(ex.StackTrace);
            }

            bmp.Dispose();
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
        }
    }
}