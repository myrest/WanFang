using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.WebDownload;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class WebDownload_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(WebDownload_Manager));
        #endregion

        #region Operation: Select
        public WebDownload_Info GetBySN(long WebDownLoadID)
        {
            return new WebDownload_Repo().GetBySN(WebDownLoadID);
        }

        public IEnumerable<WebDownload_Info> GetAll()
        {
            return new WebDownload_Repo().GetAll();
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter)
        {
            return new WebDownload_Repo().GetByParam(Filter);
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter, Rest.Core.Paging Page)
        {
            return new WebDownload_Repo().GetByParam(Filter, Page);
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter, string _orderby)
        {
            return new WebDownload_Repo().GetByParam(Filter, _orderby);
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new WebDownload_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new WebDownload_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<WebDownload_Info> GetByParameter(WebDownload_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new WebDownload_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(WebDownload_Info data)
        {
            long newID = 0;
            try
            {
                newID = new WebDownload_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long WebDownLoadID, WebDownload_Info data, IEnumerable<string> columns)
        {
            return new WebDownload_Repo().Update(WebDownLoadID, data, columns) > 0;
        }

        public bool Update(WebDownload_Info data)
        {
            return new WebDownload_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long WebDownLoadID)
        {
            return new WebDownload_Repo().Delete(WebDownLoadID);
        }
        #endregion

        #region public functions
        public bool IsExist(long WebDownLoadID)
        {
            return (GetBySN(WebDownLoadID) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}