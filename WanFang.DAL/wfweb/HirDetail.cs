using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.HirDetail
{
    #region interface
    public interface IHirDetail_Repo
    {
        HirDetail_Info GetBySN(long HirDetailId);
        IEnumerable<HirDetail_Info> GetAll();
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter);
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, Paging Page);
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string _orderby);
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string _orderby, Paging Page);
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(HirDetail_Info data);
        int Update(long HirDetailId, HirDetail_Info data, IEnumerable<string> columns);
        int Update(HirDetail_Info data);
        int Delete(long HirDetailId);
    }
    #endregion

    #region Implementation
    public class HirDetail_Repo
    {
        #region Operation: Select
        public HirDetail_Info GetBySN(long HirDetailId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_HirDetail")
                .Append("WHERE HirDetailId=@0", HirDetailId);

                var result = db.SingleOrDefault<HirDetail_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<HirDetail_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_HirDetail");
                var result = db.Query<HirDetail_Info>(SQLStr);

                return result;
            }
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HirDetail_Info> GetByParam(HirDetail_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<HirDetail_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<HirDetail_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(HirDetail_Info data)
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
        public int Update(long HirDetailId, HirDetail_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, HirDetailId, columns);
            }
        }

        public int Update(HirDetail_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HirDetailId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_HirDetail", "HirDetailId", null, HirDetailId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(HirDetail_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(HirDetail_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_HirDetail")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.HirDetailId.HasValue)
                {
                    SQLStr.Append(" AND HirDetailId=@0", filter.HirDetailId.Value);
                }
                if (filter.HirCategoryId.HasValue)
                {
                    SQLStr.Append(" AND HirCategoryId=@0", filter.HirCategoryId.Value);
                }
                if (!string.IsNullOrEmpty(filter.HirName))
                {
                    SQLStr.Append(" AND HirName=@0", filter.HirName);
                }
                if (!string.IsNullOrEmpty(filter.Dept))
                {
                    SQLStr.Append(" AND Dept=@0", filter.Dept);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.JobTitle))
                {
                    SQLStr.Append(" AND (JobTitle like @0 or CostName like @0 )", "%" + filter.JobTitle + "%");
                }
                if (filter.Nums.HasValue)
                {
                    SQLStr.Append(" AND Nums=@0", filter.Nums.Value);
                }
                if (!string.IsNullOrEmpty(filter.SchoolLimit))
                {
                    SQLStr.Append(" AND SchoolLimit=@0", filter.SchoolLimit);
                }
                if (!string.IsNullOrEmpty(filter.Condition))
                {
                    SQLStr.Append(" AND Condition=@0", filter.Condition);
                }
                if (filter.PublishDate.HasValue)
                {
                    SQLStr.Append(" AND PublishDate=@0", filter.PublishDate.Value);
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