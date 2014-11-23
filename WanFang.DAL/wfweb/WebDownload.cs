using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.WebDownload
{
    #region interface
    public interface IWebDownload_Repo
    {
        WebDownload_Info GetBySN(long WebDownLoadID);
        IEnumerable<WebDownload_Info> GetAll();
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter);
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, Paging Page);
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string _orderby);
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string _orderby, Paging Page);
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(WebDownload_Info data);
        int Update(long WebDownLoadID, WebDownload_Info data, IEnumerable<string> columns);
        int Update(WebDownload_Info data);
        int Delete(long WebDownLoadID);
    }
    #endregion

    #region Implementation
    public class WebDownload_Repo
    {
        #region Operation: Select
        public WebDownload_Info GetBySN(long WebDownLoadID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_WebDownload")
                .Append("WHERE WebDownLoadID=@0", WebDownLoadID);

                var result = db.SingleOrDefault<WebDownload_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<WebDownload_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_WebDownload");
                var result = db.Query<WebDownload_Info>(SQLStr);

                return result;
            }
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<WebDownload_Info> GetByParam(WebDownload_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<WebDownload_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<WebDownload_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(WebDownload_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = 0;
                var result = db.Insert(data);
                if (result != null)
                {
                    long.TryParse(result.ToString(), out NewID);
                }
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long WebDownLoadID, WebDownload_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, WebDownLoadID, columns);
            }
        }

        public int Update(WebDownload_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long WebDownLoadID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_WebDownload", "WebDownLoadID", null, WebDownLoadID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(WebDownload_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(WebDownload_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_WebDownload")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.WebDownLoadID.HasValue)
                {
                    SQLStr.Append(" AND WebDownLoadID=@0", filter.WebDownLoadID.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.File1))
                {
                    SQLStr.Append(" AND File1=@0", filter.File1);
                }
                if (!string.IsNullOrEmpty(filter.DocumentName))
                {
                    SQLStr.Append(" AND DocumentName=@0", filter.DocumentName);
                }
                if (filter.IsActive.HasValue)
                {
                    SQLStr.Append(" AND IsActive=@0", filter.IsActive.Value);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdator))
                {
                    SQLStr.Append(" AND LastUpdator=@0", filter.LastUpdator);
                }
                if (_orderby != "")
                    SQLStr.OrderBy(_orderby);

            }
            return SQLStr;
        }

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {
            return string.Join(", ", fieldNames);
        }
        #endregion
    }
    #endregion

}