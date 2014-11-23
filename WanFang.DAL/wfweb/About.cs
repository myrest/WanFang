using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.About
{
    #region interface
    public interface IAbout_Repo
    {
        About_Info GetBySN(long AboutId);
        IEnumerable<About_Info> GetAll();
        List<About_Info> GetByParam(About_Filter Filter);
        List<About_Info> GetByParam(About_Filter Filter, Paging Page);
        List<About_Info> GetByParam(About_Filter Filter, string _orderby);
        List<About_Info> GetByParam(About_Filter Filter, string _orderby, Paging Page);
        List<About_Info> GetByParam(About_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<About_Info> GetByParam(About_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(About_Info data);
        int Update(long AboutId, About_Info data, IEnumerable<string> columns);
        int Update(About_Info data);
        int Delete(long AboutId);
    }
    #endregion

    #region Implementation
    public class About_Repo
    {
        #region Operation: Select
        public About_Info GetBySN(long AboutId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_About")
                .Append("WHERE AboutId=@0", AboutId);

                var result = db.SingleOrDefault<About_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<About_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_About");
                var result = db.Query<About_Info>(SQLStr);

                return result;
            }
        }

        public List<About_Info> GetByParam(About_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<About_Info> GetByParam(About_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<About_Info> GetByParam(About_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<About_Info> GetByParam(About_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<About_Info> GetByParam(About_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<About_Info> GetByParam(About_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<About_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<About_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(About_Info data)
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
        public int Update(long AboutId, About_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutId, columns);
            }
        }

        public int Update(About_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_About", "AboutId", null, AboutId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(About_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(About_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_About")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutId.HasValue)
                {
                    SQLStr.Append(" AND AboutId=@0", filter.AboutId.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (!string.IsNullOrEmpty(filter.Category))
                {
                    SQLStr.Append(" AND Category=@0", filter.Category);
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