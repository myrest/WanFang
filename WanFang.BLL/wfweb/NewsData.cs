using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.NewsData;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class NewsData_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(NewsData_Manager));
        #endregion

        #region Operation: Select
        public NewsData_Info GetBySN(long NewsId)
        {
            return new NewsData_Repo().GetBySN(NewsId);
        }

        public IEnumerable<NewsData_Info> GetAll()
        {
            return new NewsData_Repo().GetAll();
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter)
        {
            return new NewsData_Repo().GetByParam(Filter);
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter, Rest.Core.Paging Page)
        {
            return new NewsData_Repo().GetByParam(Filter, Page);
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter, string _orderby)
        {
            return new NewsData_Repo().GetByParam(Filter, _orderby);
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new NewsData_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new NewsData_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<NewsData_Info> GetByParameter(NewsData_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new NewsData_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(NewsData_Info data)
        {
            long newID = 0;
            try
            {
                newID = new NewsData_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long NewsId, NewsData_Info data, IEnumerable<string> columns)
        {
            return new NewsData_Repo().Update(NewsId, data, columns) > 0;
        }

        public bool Update(NewsData_Info data)
        {
            return new NewsData_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NewsId)
        {
            return new NewsData_Repo().Delete(NewsId);
        }
        #endregion

        #region public functions
        public bool IsExist(long NewsId)
        {
            return (GetBySN(NewsId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}