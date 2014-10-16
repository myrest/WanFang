using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Guide
{
    #region interface
    public interface IGuide_Repo
    {
        Guide_Info GetBySN(long GuideId);
        IEnumerable<Guide_Info> GetAll();
        List<Guide_Info> GetByParam(Guide_Filter Filter);
        List<Guide_Info> GetByParam(Guide_Filter Filter, Paging Page);
        List<Guide_Info> GetByParam(Guide_Filter Filter, string _orderby);
        List<Guide_Info> GetByParam(Guide_Filter Filter, string _orderby, Paging Page);
        List<Guide_Info> GetByParam(Guide_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Guide_Info> GetByParam(Guide_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Guide_Info data);
        int Update(long GuideId, Guide_Info data, IEnumerable<string> columns);
        int Update(Guide_Info data);
        int Delete(long GuideId);
    }
    #endregion

    #region Implementation
    public class Guide_Repo
    {
        #region Operation: Select
        public Guide_Info GetBySN(long GuideId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Guide")
                .Append("WHERE GuideId=@0", GuideId);

                var result = db.SingleOrDefault<Guide_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Guide_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Guide");
                var result = db.Query<Guide_Info>(SQLStr);

                return result;
            }
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Guide_Info> GetByParam(Guide_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Guide_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Guide_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Guide_Info data)
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
        public int Update(long GuideId, Guide_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, GuideId, columns);
            }
        }

        public int Update(Guide_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long GuideId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("Guide", "GuideId", null, GuideId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Guide_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Guide_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Guide")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.GuideId.HasValue)
                {
                    SQLStr.Append(" AND GuideId=@0", filter.GuideId.Value);
                }
                if (!string.IsNullOrEmpty(filter.ItemName))
                {
                    SQLStr.Append(" AND ItemName=@0", filter.ItemName);
                }
                if (filter.DisplayType.HasValue)
                {
                    SQLStr.Append(" AND DisplayType=@0", filter.DisplayType.Value);
                }
                if (!string.IsNullOrEmpty(filter.Link))
                {
                    SQLStr.Append(" AND Link=@0", filter.Link);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody1))
                {
                    SQLStr.Append(" AND ContentBody1=@0", filter.ContentBody1);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody2))
                {
                    SQLStr.Append(" AND ContentBody2=@0", filter.ContentBody2);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody3))
                {
                    SQLStr.Append(" AND ContentBody3=@0", filter.ContentBody3);
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
                if (_orderby != "")
                    SQLStr.Append("ORDER BY @0", _orderby);

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