using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutService
{
    #region interface
    public interface IAboutService_Repo
    {
        AboutService_Info GetBySN(long AboutServiceId);
        IEnumerable<AboutService_Info> GetAll();
        List<AboutService_Info> GetByParam(AboutService_Filter Filter);
        List<AboutService_Info> GetByParam(AboutService_Filter Filter, Paging Page);
        List<AboutService_Info> GetByParam(AboutService_Filter Filter, string _orderby);
        List<AboutService_Info> GetByParam(AboutService_Filter Filter, string _orderby, Paging Page);
        List<AboutService_Info> GetByParam(AboutService_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<AboutService_Info> GetByParam(AboutService_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(AboutService_Info data);
        int Update(long AboutServiceId, AboutService_Info data, IEnumerable<string> columns);
        int Update(AboutService_Info data);
        int Delete(long AboutServiceId);
    }
    #endregion

    #region Implementation
    public class AboutService_Repo
    {
        #region Operation: Select
        public AboutService_Info GetBySN(long AboutServiceId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutService")
                .Append("WHERE AboutServiceId=@0", AboutServiceId);

                var result = db.SingleOrDefault<AboutService_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutService_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutService");
                var result = db.Query<AboutService_Info>(SQLStr);

                return result;
            }
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutService_Info> GetByParam(AboutService_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<AboutService_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<AboutService_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(AboutService_Info data)
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
        public int Update(long AboutServiceId, AboutService_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutServiceId, columns);
            }
        }

        public int Update(AboutService_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutServiceId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutService", "AboutServiceId", null, AboutServiceId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutService_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutService_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutService")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutServiceId.HasValue)
                {
                    SQLStr.Append(" AND AboutServiceId=@0", filter.AboutServiceId.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    SQLStr.Append(" AND Description=@0", filter.Description);
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