using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutTeam
{
    #region interface
    public interface IAboutTeam_Repo
    {
        AboutTeam_Info GetBySN(long AboutTeamId);
        IEnumerable<AboutTeam_Info> GetAll();
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter);
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, Paging Page);
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string _orderby);
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string _orderby, Paging Page);
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(AboutTeam_Info data);
        int Update(long AboutTeamId, AboutTeam_Info data, IEnumerable<string> columns);
        int Update(AboutTeam_Info data);
        int Delete(long AboutTeamId);
    }
    #endregion

    #region Implementation
    public class AboutTeam_Repo
    {
        #region Operation: Select
        public AboutTeam_Info GetBySN(long AboutTeamId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutTeam")
                .Append("WHERE AboutTeamId=@0", AboutTeamId);

                var result = db.SingleOrDefault<AboutTeam_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutTeam_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutTeam");
                var result = db.Query<AboutTeam_Info>(SQLStr);

                return result;
            }
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutTeam_Info> GetByParam(AboutTeam_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<AboutTeam_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<AboutTeam_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(AboutTeam_Info data)
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
        public int Update(long AboutTeamId, AboutTeam_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutTeamId, columns);
            }
        }

        public int Update(AboutTeam_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutTeamId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutTeam", "AboutTeamId", null, AboutTeamId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutTeam_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutTeam_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutTeam")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutTeamId.HasValue)
                {
                    SQLStr.Append(" AND AboutTeamId=@0", filter.AboutTeamId.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (!string.IsNullOrEmpty(filter.StrName))
                {
                    SQLStr.Append(" AND StrName=@0", filter.StrName);
                }
                if (!string.IsNullOrEmpty(filter.UserName))
                {
                    SQLStr.Append(" AND UserName like @0", "%" + filter.UserName + "%");
                }
                if (!string.IsNullOrEmpty(filter.Introduction))
                {
                    SQLStr.Append(" AND Introduction=@0", filter.Introduction);
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    SQLStr.Append(" AND Description=@0", filter.Description);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody))
                {
                    SQLStr.Append(" AND ContentBody=@0", filter.ContentBody);
                }
                if (!string.IsNullOrEmpty(filter.Photo1))
                {
                    SQLStr.Append(" AND Photo1=@0", filter.Photo1);
                }
                if (!string.IsNullOrEmpty(filter.Photo2))
                {
                    SQLStr.Append(" AND Photo2=@0", filter.Photo2);
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