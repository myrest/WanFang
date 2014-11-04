using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutContent
{
    #region interface
    public interface IAboutContent_Repo
    {
        AboutContent_Info GetBySN(long AboutContentId);
        IEnumerable<AboutContent_Info> GetAll();
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter);
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page);
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby);
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby, Paging Page);
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(AboutContent_Info data);
        int Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns);
        int Update(AboutContent_Info data);
        int Delete(long AboutContentId);
    }
    #endregion

    #region Implementation
    public class AboutContent_Repo
    {
        #region Operation: Select
        public AboutContent_Info GetBySN(long AboutContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutContent")
                .Append("WHERE AboutContentId=@0", AboutContentId);

                var result = db.SingleOrDefault<AboutContent_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutContent_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutContent");
                var result = db.Query<AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<AboutContent_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<AboutContent_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(AboutContent_Info data)
        {
            if (data.AboutCategoryId.Value == 0)
            {
                data.AboutCategoryId = null;
            }
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
        public int Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns)
        {
            if (data.AboutCategoryId.Value == 0)
            {
                data.AboutCategoryId = null;
            }
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutContentId, columns);
            }
        }

        public int Update(AboutContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutContent", "AboutContentId", null, AboutContentId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutContent")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutContentId.HasValue)
                {
                    SQLStr.Append(" AND AboutContentId=@0", filter.AboutContentId.Value);
                }
                if (filter.AboutId.HasValue)
                {
                    SQLStr.Append(" AND AboutId=@0", filter.AboutId.Value);
                }
                if (filter.AboutCategoryId.HasValue)
                {
                    SQLStr.Append(" AND AboutCategoryId=@0", filter.AboutCategoryId.Value);
                }
                if (!string.IsNullOrEmpty(filter.UnitName))
                {
                    SQLStr.Append(" AND UnitName=@0", filter.UnitName);
                }
                if (filter.OpenType.HasValue)
                {
                    SQLStr.Append(" AND OpenType=@0", filter.OpenType.Value);
                }
                if (!string.IsNullOrEmpty(filter.OpenUrl))
                {
                    SQLStr.Append(" AND OpenUrl=@0", filter.OpenUrl);
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