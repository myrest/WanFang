using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutCategory
{
    #region interface
    public interface IAboutCategory_Repo
    {
        AboutCategory_Info GetBySN(long AboutCategoryId);
        IEnumerable<AboutCategory_Info> GetAll();
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter);
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, Paging Page);
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string _orderby);
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string _orderby, Paging Page);
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(AboutCategory_Info data);
        int Update(long AboutCategoryId, AboutCategory_Info data, IEnumerable<string> columns);
        int Update(AboutCategory_Info data);
        int Delete(long AboutCategoryId);
    }
    #endregion

    #region Implementation
    public class AboutCategory_Repo
    {
        #region Operation: Select
        public AboutCategory_Info GetBySN(long AboutCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutCategory")
                .Append("WHERE AboutCategoryId=@0", AboutCategoryId);

                var result = db.SingleOrDefault<AboutCategory_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutCategory_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutCategory");
                var result = db.Query<AboutCategory_Info>(SQLStr);

                return result;
            }
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutCategory_Info> GetByParam(AboutCategory_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<AboutCategory_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<AboutCategory_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(AboutCategory_Info data)
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
        public int Update(long AboutCategoryId, AboutCategory_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutCategoryId, columns);
            }
        }

        public int Update(AboutCategory_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutCategory", "AboutCategoryId", null, AboutCategoryId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutCategory_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutCategory_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutCategory")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutCategoryId.HasValue)
                {
                    SQLStr.Append(" AND AboutCategoryId=@0", filter.AboutCategoryId.Value);
                }
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