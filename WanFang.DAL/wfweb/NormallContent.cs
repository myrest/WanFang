using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.NormallContent
{
    #region interface
    public interface INormallContent_Repo
    {
        NormallContent_Info GetBySN(long NormallContentId);
        IEnumerable<NormallContent_Info> GetAll();
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter);
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, Paging Page);
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string _orderby);
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string _orderby, Paging Page);
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(NormallContent_Info data);
        int Update(long NormallContentId, NormallContent_Info data, IEnumerable<string> columns);
        int Update(NormallContent_Info data);
        int Delete(long NormallContentId);
    }
    #endregion

    #region Implementation
    public class NormallContent_Repo
    {
        #region Operation: Select
        public NormallContent_Info GetBySN(long NormallContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_NormallContent")
                .Append("WHERE NormallContentId=@0", NormallContentId);

                var result = db.SingleOrDefault<NormallContent_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<NormallContent_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_NormallContent");
                var result = db.Query<NormallContent_Info>(SQLStr);

                return result;
            }
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<NormallContent_Info> GetByParam(NormallContent_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<NormallContent_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<NormallContent_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(NormallContent_Info data)
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
        public int Update(long NormallContentId, NormallContent_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, NormallContentId, columns);
            }
        }

        public int Update(NormallContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NormallContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_NormallContent", "NormallContentId", null, NormallContentId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(NormallContent_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(NormallContent_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_NormallContent")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.NormallContentId.HasValue)
                {
                    SQLStr.Append(" AND NormallContentId=@0", filter.NormallContentId.Value);
                }
                if (!string.IsNullOrEmpty(filter.ContentName))
                {
                    SQLStr.Append(" AND ContentName=@0", filter.ContentName);
                }
                if (!string.IsNullOrEmpty(filter.UnitName))
                {
                    SQLStr.Append(" AND UnitName like @0", "%" + filter.UnitName + "%");
                }
                if (filter.OpenType.HasValue)
                {
                    SQLStr.Append(" AND OpenType=@0", filter.OpenType.Value);
                }
                if (!string.IsNullOrEmpty(filter.OpenUrl))
                {
                    SQLStr.Append(" AND OpenUrl=@0", filter.OpenUrl);
                }
                if (filter.UrlTarget.HasValue)
                {
                    SQLStr.Append(" AND UrlTarget=@0", filter.UrlTarget.Value);
                }
                if (!string.IsNullOrEmpty(filter.Content1))
                {
                    SQLStr.Append(" AND Content1=@0", filter.Content1);
                }
                if (!string.IsNullOrEmpty(filter.Content2))
                {
                    SQLStr.Append(" AND Content2=@0", filter.Content2);
                }
                if (!string.IsNullOrEmpty(filter.Content3))
                {
                    SQLStr.Append(" AND Content3=@0", filter.Content3);
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
                if (filter.Position1.HasValue)
                {
                    SQLStr.Append(" AND Position1=@0", filter.Position1.Value);
                }
                if (filter.Position2.HasValue)
                {
                    SQLStr.Append(" AND Position2=@0", filter.Position2.Value);
                }
                if (filter.Position3.HasValue)
                {
                    SQLStr.Append(" AND Position3=@0", filter.Position3.Value);
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