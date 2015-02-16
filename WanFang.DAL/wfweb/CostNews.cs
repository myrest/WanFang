using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.CostNews
{
    #region interface
    public interface ICostNews_Repo
    {
        CostNews_Info GetBySN(long CostNewsId);
        IEnumerable<CostNews_Info> GetAll();
        List<CostNews_Info> GetByParam(CostNews_Filter Filter);
        List<CostNews_Info> GetByParam(CostNews_Filter Filter, Paging Page);
        List<CostNews_Info> GetByParam(CostNews_Filter Filter, string _orderby);
        List<CostNews_Info> GetByParam(CostNews_Filter Filter, string _orderby, Paging Page);
        List<CostNews_Info> GetByParam(CostNews_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<CostNews_Info> GetByParam(CostNews_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(CostNews_Info data);
        int Update(long CostNewsId, CostNews_Info data, IEnumerable<string> columns);
        int Update(CostNews_Info data);
        int Delete(long CostNewsId);
    }
    #endregion

    #region Implementation
    public class CostNews_Repo
    {
        #region Operation: Select
        public CostNews_Info GetBySN(long CostNewsId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_CostNews")
                .Append("WHERE CostNewsId=@0", CostNewsId);

                var result = db.SingleOrDefault<CostNews_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<CostNews_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_CostNews");
                var result = db.Query<CostNews_Info>(SQLStr);

                return result;
            }
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostNews_Info> GetByParam(CostNews_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<CostNews_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<CostNews_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(CostNews_Info data)
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
        public int Update(long CostNewsId, CostNews_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, CostNewsId, columns);
            }
        }

        public int Update(CostNews_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostNewsId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_CostNews", "CostNewsId", null, CostNewsId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(CostNews_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(CostNews_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_CostNews")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.CostNewsId.HasValue)
                {
                    SQLStr.Append(" AND CostNewsId=@0", filter.CostNewsId.Value);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.CostId))
                {
                    SQLStr.Append(" AND CostId=@0", filter.CostId);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (filter.PublishDate.HasValue)
                {
                    SQLStr.Append(" AND PublishDate=@0", filter.PublishDate.Value);
                }
                if (!string.IsNullOrEmpty(filter.Subject))
                {
                    SQLStr.Append(" AND Subject=@0", filter.Subject);
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
                if (!string.IsNullOrEmpty(filter.Image4))
                {
                    SQLStr.Append(" AND Image4=@0", filter.Image4);
                }
                if (filter.IsActive.HasValue)
                {
                    SQLStr.Append(" AND IsActive=@0", filter.IsActive.Value);
                }
                if (!string.IsNullOrEmpty(filter.UploadFile))
                {
                    SQLStr.Append(" AND UploadFile=@0", filter.UploadFile);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdator))
                {
                    SQLStr.Append(" AND LastUpdator=@0", filter.LastUpdator);
                }
                if (filter.VerifiedDate.HasValue)
                {
                    SQLStr.Append(" AND VerifiedDate=@0", filter.VerifiedDate.Value);
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