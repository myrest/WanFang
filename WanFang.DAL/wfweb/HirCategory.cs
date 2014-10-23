using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.HirCategory
{
    #region interface
    public interface IHirCategory_Repo
    {
        HirCategory_Info GetBySN(long HirCategoryId);
        IEnumerable<HirCategory_Info> GetAll();
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter);
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, Paging Page);
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string _orderby);
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string _orderby, Paging Page);
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(HirCategory_Info data);
        int Update(long HirCategoryId, HirCategory_Info data, IEnumerable<string> columns);
        int Update(HirCategory_Info data);
        int Delete(long HirCategoryId);
    }
    #endregion

    #region Implementation
    public class HirCategory_Repo
    {
        #region Operation: Select
        public HirCategory_Info GetBySN(long HirCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_HirCategory")
                .Append("WHERE HirCategoryId=@0", HirCategoryId);

                var result = db.SingleOrDefault<HirCategory_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<HirCategory_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_HirCategory");
                var result = db.Query<HirCategory_Info>(SQLStr);

                return result;
            }
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HirCategory_Info> GetByParam(HirCategory_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<HirCategory_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<HirCategory_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(HirCategory_Info data)
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
        public int Update(long HirCategoryId, HirCategory_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, HirCategoryId, columns);
            }
        }

        public int Update(HirCategory_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HirCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("HirCategory", "HirCategoryId", null, HirCategoryId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(HirCategory_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(HirCategory_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_HirCategory")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.HirCategoryId.HasValue)
                {
                    SQLStr.Append(" AND HirCategoryId=@0", filter.HirCategoryId.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (!string.IsNullOrEmpty(filter.CategoryName))
                {
                    SQLStr.Append(" AND CategoryName=@0", filter.CategoryName);
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