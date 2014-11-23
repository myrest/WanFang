using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.CostKeyword
{
    #region interface
    public interface ICostKeyword_Repo
    {
        CostKeyword_Info GetBySN(long CostKeywordId);
        IEnumerable<CostKeyword_Info> GetAll();
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter);
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, Paging Page);
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string _orderby);
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string _orderby, Paging Page);
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(CostKeyword_Info data);
        int Update(long CostKeywordId, CostKeyword_Info data, IEnumerable<string> columns);
        int Update(CostKeyword_Info data);
        int Delete(long CostKeywordId);
    }
    #endregion

    #region Implementation
    public class CostKeyword_Repo
    {
        #region Operation: Select
        public CostKeyword_Info GetBySN(long CostKeywordId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_CostKeyword")
                .Append("WHERE CostKeywordId=@0", CostKeywordId);

                var result = db.SingleOrDefault<CostKeyword_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<CostKeyword_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_CostKeyword");
                var result = db.Query<CostKeyword_Info>(SQLStr);

                return result;
            }
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostKeyword_Info> GetByParam(CostKeyword_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<CostKeyword_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<CostKeyword_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(CostKeyword_Info data)
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
        public int Update(long CostKeywordId, CostKeyword_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, CostKeywordId, columns);
            }
        }

        public int Update(CostKeyword_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostKeywordId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_CostKeyword", "CostKeywordId", null, CostKeywordId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(CostKeyword_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(CostKeyword_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_CostKeyword")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.CostKeywordId.HasValue)
                {
                    SQLStr.Append(" AND CostKeywordId=@0", filter.CostKeywordId.Value);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.KeyWord))
                {
                    SQLStr.Append(" AND KeyWord like @0", "%" + filter.KeyWord + "%");
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