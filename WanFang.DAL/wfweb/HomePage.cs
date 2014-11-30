using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.HomePage
{
    #region interface
    public interface IHomePage_Repo
    {
        HomePage_Info GetBySN(long HomePageId);
        IEnumerable<HomePage_Info> GetAll();
        List<HomePage_Info> GetByParam(HomePage_Filter Filter);
        List<HomePage_Info> GetByParam(HomePage_Filter Filter, Paging Page);
        List<HomePage_Info> GetByParam(HomePage_Filter Filter, string _orderby);
        List<HomePage_Info> GetByParam(HomePage_Filter Filter, string _orderby, Paging Page);
        List<HomePage_Info> GetByParam(HomePage_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<HomePage_Info> GetByParam(HomePage_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(HomePage_Info data);
        int Update(long HomePageId, HomePage_Info data, IEnumerable<string> columns);
        int Update(HomePage_Info data);
        int Delete(long HomePageId);
    }
    #endregion

    #region Implementation
    public class HomePage_Repo
    {
        #region Operation: Select
        public HomePage_Info GetBySN(long HomePageId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_HomePage")
                .Append("WHERE HomePageId=@0", HomePageId);

                var result = db.SingleOrDefault<HomePage_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<HomePage_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_HomePage");
                var result = db.Query<HomePage_Info>(SQLStr);

                return result;
            }
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HomePage_Info> GetByParam(HomePage_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<HomePage_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<HomePage_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(HomePage_Info data)
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
        public int Update(long HomePageId, HomePage_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, HomePageId, columns);
            }
        }

        public int Update(HomePage_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HomePageId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_HomePage", "HomePageId", null, HomePageId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(HomePage_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(HomePage_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_HomePage")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.HomePageId.HasValue)
                {
                    SQLStr.Append(" AND HomePageId=@0", filter.HomePageId.Value);
                }
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    SQLStr.Append(" AND Title=@0", filter.Title);
                }
                if (!string.IsNullOrEmpty(filter.Link))
                {
                    SQLStr.Append(" AND Link=@0", filter.Link);
                }
                if (filter.DisplayDateTime.HasValue)
                {
                    SQLStr.Append(" AND DisplayDateTime=@0", filter.DisplayDateTime.Value);
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