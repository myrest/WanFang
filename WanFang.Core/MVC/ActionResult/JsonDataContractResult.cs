using Rest.Core.Utility;
using System;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace WanFang.Core.MVC
{
    public class JsonDataContractResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Get is not allowed");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                // Use the DataContractJsonSerializer instead of the JavaScriptSerializer
                DataContractJsonSerializer serializer = JsonSerializerHelper.GetSerializer(Data.GetType());
                serializer.WriteObject(response.OutputStream, Data);
            }
        }
    }
}