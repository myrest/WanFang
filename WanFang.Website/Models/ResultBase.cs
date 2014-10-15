using Rest.Core.Utility;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace WanFang.Website.Models
{
    [DataContract]
    public class ResultBase
    {
        [DataMember(Name = "code")]
        public int JsonReturnCode { get; set; }

        [DataMember(Name = "msg")]
        public string Message { get; set; }

        public ResultBase()
        {
            JsonReturnCode = -1;
        }

        public void setException(Exception ex, string csName)
        {
            SysLog Log = SysLog.GetLogger(csName);
            Message = ex.Message;
            Log.Exception(ex);
        }

        public void setException(Exception ex, SysLog Log)
        {
            Message = ex.Message;
            Log.Exception(ex);
        }

        public void setException(string ErrMsg, string csName)
        {
            SysLog Log = SysLog.GetLogger(csName);
            Message = ErrMsg;
            Log.Exception(ErrMsg);
        }

        public void setMessage(string msg)
        {
            JsonReturnCode = 1;
            Message = msg;
        }

        public void setErrorMessage(string msg)
        {
            JsonReturnCode = -1;
            Message = msg;
        }
    }

    [DataContract]
    public class ResultModel<T> : ResultBase
        where T : class
    {
        [DataMember(Name = "d")]
        public List<T> Items { get; set; }
    }

}