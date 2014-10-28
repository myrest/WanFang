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
using System.Web;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace WanFang.Website.Controllers.Service
{
    public class FileUploadServiceController : BaseController
    {
        //限制300kb
        private static readonly long MaxLengthLimitKB = 300;
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(FileUploadServiceController));

        public FileUploadServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase Uploadfile, string PrefixInfo)
        {
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, PrefixInfo);
            if (result.JsonReturnCode > 0)
            {
                if (sessionData.trading.UploadFiles.Any(x => x.Key == PrefixInfo))
                {
                    sessionData.trading.UploadFiles[PrefixInfo] = result.TempFileName;
                }
                else
                {
                    sessionData.trading.UploadFiles.Add(PrefixInfo, result.TempFileName);
                }
            }
            else
            {
                //todo:need remove old file.
                if (sessionData.trading.UploadFiles.Any(x => x.Key == PrefixInfo))
                {
                    sessionData.trading.UploadFiles.Remove(PrefixInfo);
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private UploadFileResult CheckAndSaveUploadFile(HttpPostedFileBase Uploadfile, string PreFix)
        {
            //This must be get the Topic SN from SessionData.
            UploadFileResult result = new UploadFileResult() { };
            if (Uploadfile != null)
            {
                try
                {
                    string FileName = PreFix + DateTime.Now.ToString("yyyyMMddHHmmssf") + Path.GetExtension(Uploadfile.FileName);
                    result.FileName = Uploadfile.FileName;//User's uploaded file name.
                    result.FileType = Uploadfile.ContentType;
                    result.FileSize = ConvertFileSize(Uploadfile.ContentLength);
                    result.TempFileName = FileName;//Server given name.

                    Uploadfile.SaveAs(string.Format("{0}{1}/{2}", Server.MapPath("~/"), "UploadTemp", FileName));
                    result.setMessage("Done");
                }
                catch (Exception ex)
                {
                    result.setException(ex, "CheckAndSaveUploadFile");
                }
            }
            return result;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            int MaxLength = 10;
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            string result = sBuilder.ToString();
            if (result.Length > MaxLength)
            {
                result = result.Substring(0, MaxLength);
            }
            return result;
        }

        private string ConvertFileSize(decimal FileSize)
        {
            decimal k = 1024;
            decimal m = k * 1024;
            if (FileSize > k * MaxLengthLimitKB)
            {
                throw new Exception(string.Format("上傳檔案大小超過限制{0}KB", MaxLengthLimitKB));
            }
            else
            {
                if (FileSize < k)
                {
                    return string.Format("{0}B", FileSize);
                }
                else if (FileSize < m)
                {
                    return string.Format("{0}K", Math.Round(FileSize / k, 1));
                }
                else
                {
                    return string.Format("{0}M", Math.Round(FileSize / m, 1));
                }
            }
        }
    }
}