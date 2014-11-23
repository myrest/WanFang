using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.CostUnit
{
    #region interface
    public interface ICostUnit_Repo
    {
        CostUnit_Info GetBySN(long CostUnitId);
        IEnumerable<CostUnit_Info> GetAll();
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter);
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, Paging Page);
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string _orderby);
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string _orderby, Paging Page);
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(CostUnit_Info data);
        int Update(long CostUnitId, CostUnit_Info data, IEnumerable<string> columns);
        int Update(CostUnit_Info data);
        int Delete(long CostUnitId);
    }
    #endregion

    #region Implementation
    public class CostUnit_Repo
    {
        #region Operation: Select
        public CostUnit_Info GetBySN(long CostUnitId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_CostUnit")
                .Append("WHERE CostUnitId=@0", CostUnitId);

                var result = db.SingleOrDefault<CostUnit_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<CostUnit_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_CostUnit");
                var result = db.Query<CostUnit_Info>(SQLStr);

                return result;
            }
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostUnit_Info> GetByParam(CostUnit_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<CostUnit_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<CostUnit_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(CostUnit_Info data)
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
        public int Update(long CostUnitId, CostUnit_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, CostUnitId, columns);
            }
        }

        public int Update(CostUnit_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostUnitId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_CostUnit", "CostUnitId", null, CostUnitId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(CostUnit_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(CostUnit_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_CostUnit")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.CostUnitId.HasValue)
                {
                    SQLStr.Append(" AND CostUnitId=@0", filter.CostUnitId.Value);
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
                if (!string.IsNullOrEmpty(filter.UnitName))
                {
                    SQLStr.Append(" AND UnitName like @0", "%" + filter.UnitName + "%");
                }
                if (!string.IsNullOrEmpty(filter.ContentBody))
                {
                    SQLStr.Append(" AND ContentBody=@0", filter.ContentBody);
                }
                if (!string.IsNullOrEmpty(filter.Image1))
                {
                    SQLStr.Append(" AND Image1=@0", filter.Image1);
                }
                if (!string.IsNullOrEmpty(filter.Image2))
                {
                    SQLStr.Append(" AND Image2=@0", filter.Image2);
                }
                if (!string.IsNullOrEmpty(filter.Image3))
                {
                    SQLStr.Append(" AND Image3=@0", filter.Image3);
                }
                if (filter.IsHomePage.HasValue)
                {
                    SQLStr.Append(" AND IsHomePage=@0", filter.IsHomePage.Value);
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