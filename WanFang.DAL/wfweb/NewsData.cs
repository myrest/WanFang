using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.NewsData
{
    #region interface
    public interface INewsData_Repo
    {
        NewsData_Info GetBySN(long NewsId);
        IEnumerable<NewsData_Info> GetAll();
        List<NewsData_Info> GetByParam(NewsData_Filter Filter);
        List<NewsData_Info> GetByParam(NewsData_Filter Filter, Paging Page);
        List<NewsData_Info> GetByParam(NewsData_Filter Filter, string _orderby);
        List<NewsData_Info> GetByParam(NewsData_Filter Filter, string _orderby, Paging Page);
        List<NewsData_Info> GetByParam(NewsData_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<NewsData_Info> GetByParam(NewsData_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(NewsData_Info data);
        int Update(long NewsId, NewsData_Info data, IEnumerable<string> columns);
        int Update(NewsData_Info data);
        int Delete(long NewsId);
    }
    #endregion

    #region Implementation
    public class NewsData_Repo
    {
        #region Operation: Select
        public NewsData_Info GetBySN(long NewsId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_NewsData")
                .Append("WHERE NewsId=@0", NewsId);

                var result = db.SingleOrDefault<NewsData_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<NewsData_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_NewsData");
                var result = db.Query<NewsData_Info>(SQLStr);

                return result;
            }
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<NewsData_Info> GetByParam(NewsData_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<NewsData_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<NewsData_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(NewsData_Info data)
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
        public int Update(long NewsId, NewsData_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, NewsId, columns);
            }
        }

        public int Update(NewsData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NewsId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_NewsData", "NewsId", null, NewsId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(NewsData_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(NewsData_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_NewsData")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.NewsId.HasValue)
                {
                    SQLStr.Append(" AND NewsId=@0", filter.NewsId.Value);
                }
                if (filter.PublishDate.HasValue)
                {
                    SQLStr.Append(" AND PublishDate=@0", filter.PublishDate.Value);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.DeptCode))
                {
                    SQLStr.Append(" AND DeptCode=@0", filter.DeptCode);
                }
                if (!string.IsNullOrEmpty(filter.CostId))
                {
                    SQLStr.Append(" AND CostId like @0", filter.CostId);
                }
                if (!string.IsNullOrEmpty(filter.Cost))
                {
                    SQLStr.Append(" AND Cost=@0", filter.Cost);
                }
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    SQLStr.Append(" AND Title like @0", "%" + filter.Title + "%");
                }
                if (!string.IsNullOrEmpty(filter.Author))
                {
                    SQLStr.Append(" AND Author=@0", filter.Author);
                }
                if (!string.IsNullOrEmpty(filter.Keyword))
                {
                    SQLStr.Append(" AND Keyword=@0", filter.Keyword);
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
                if (filter.IsShowOnTeam.HasValue)
                {
                    SQLStr.Append(" AND IsShowOnTeam=@0", filter.IsShowOnTeam.Value);
                }
                if (filter.IsPrivate.HasValue)
                {
                    SQLStr.Append(" AND IsPrivate=@0", filter.IsPrivate.Value);
                }
                if (filter.Hit.HasValue)
                {
                    SQLStr.Append(" AND Hit=@0", filter.Hit.Value);
                }
                if (filter.IsActive.HasValue)
                {
                    SQLStr.Append(" AND IsActive=@0", filter.IsActive.Value);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
                }
                if (!string.IsNullOrEmpty(filter.LastUpadtor))
                {
                    SQLStr.Append(" AND LastUpadtor=@0", filter.LastUpadtor);
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