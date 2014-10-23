using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.LogLogin
{
    #region interface
    public interface ILogLogin_Repo
    {
        LogLogin_Info GetBySN(long LogLoginId);
        IEnumerable<LogLogin_Info> GetAll();
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter);
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, Paging Page);
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string _orderby);
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string _orderby, Paging Page);
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(LogLogin_Info data);
        int Update(long LogLoginId, LogLogin_Info data, IEnumerable<string> columns);
        int Update(LogLogin_Info data);
        int Delete(long LogLoginId);
    }
    #endregion

    #region Implementation
    public class LogLogin_Repo
    {
        #region Operation: Select
        public LogLogin_Info GetBySN(long LogLoginId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_LogLogin")
                .Append("WHERE LogLoginId=@0", LogLoginId);

                var result = db.SingleOrDefault<LogLogin_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<LogLogin_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_LogLogin");
                var result = db.Query<LogLogin_Info>(SQLStr);

                return result;
            }
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<LogLogin_Info> GetByParam(LogLogin_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<LogLogin_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<LogLogin_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(LogLogin_Info data)
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
        public int Update(long LogLoginId, LogLogin_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, LogLoginId, columns);
            }
        }

        public int Update(LogLogin_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long LogLoginId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("LogLogin", "LogLoginId", null, LogLoginId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(LogLogin_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(LogLogin_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_LogLogin")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.LogLoginId.HasValue)
                {
                    SQLStr.Append(" AND LogLoginId=@0", filter.LogLoginId.Value);
                }
                if (!string.IsNullOrEmpty(filter.LoginId))
                {
                    SQLStr.Append(" AND LoginId=@0", filter.LoginId);
                }
                if (!string.IsNullOrEmpty(filter.Password))
                {
                    SQLStr.Append(" AND Password=@0", filter.Password);
                }
                if (filter.IsPass.HasValue)
                {
                    SQLStr.Append(" AND IsPass=@0", filter.IsPass.Value);
                }
                if (filter.CreateDateTime.HasValue)
                {
                    SQLStr.Append(" AND CreateDateTime=@0", filter.CreateDateTime.Value);
                }
                if (!string.IsNullOrEmpty(filter.LoginIP))
                {
                    SQLStr.Append(" AND LoginIP=@0", filter.LoginIP);
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