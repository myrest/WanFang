using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.TeamIntroduce
{
    #region interface
    public interface ITeamIntroduce_Repo
    {
        TeamIntroduce_Info GetBySN(long TeamIntroduceId);
        IEnumerable<TeamIntroduce_Info> GetAll();
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter);
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, Paging Page);
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string _orderby);
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string _orderby, Paging Page);
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(TeamIntroduce_Info data);
        int Update(long TeamIntroduceId, TeamIntroduce_Info data, IEnumerable<string> columns);
        int Update(TeamIntroduce_Info data);
        int Delete(long TeamIntroduceId);
    }
    #endregion

    #region Implementation
    public class TeamIntroduce_Repo
    {
        #region Operation: Select
        public TeamIntroduce_Info GetBySN(long TeamIntroduceId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_TeamIntroduce")
                .Append("WHERE TeamIntroduceId=@0", TeamIntroduceId);

                var result = db.SingleOrDefault<TeamIntroduce_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<TeamIntroduce_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_TeamIntroduce");
                var result = db.Query<TeamIntroduce_Info>(SQLStr);

                return result;
            }
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<TeamIntroduce_Info> GetByParam(TeamIntroduce_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<TeamIntroduce_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<TeamIntroduce_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(TeamIntroduce_Info data)
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
        public int Update(long TeamIntroduceId, TeamIntroduce_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, TeamIntroduceId, columns);
            }
        }

        public int Update(TeamIntroduce_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TeamIntroduceId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_TeamIntroduce", "TeamIntroduceId", null, TeamIntroduceId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(TeamIntroduce_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(TeamIntroduce_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_TeamIntroduce")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.TeamIntroduceId.HasValue)
                {
                    SQLStr.Append(" AND TeamIntroduceId=@0", filter.TeamIntroduceId.Value);
                }
                if (!string.IsNullOrEmpty(filter.Dept))
                {
                    SQLStr.Append(" AND Dept=@0", filter.Dept);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.CostId))
                {
                    SQLStr.Append(" AND CostId=@0", filter.CostId);
                }
                if (!string.IsNullOrEmpty(filter.WebMenuCode))
                {
                    SQLStr.Append(" AND WebMenuCode=@0", filter.WebMenuCode);
                }
                if (!string.IsNullOrEmpty(filter.WebMenuName))
                {
                    SQLStr.Append(" AND WebMenuName=@0", filter.WebMenuName);
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    SQLStr.Append(" AND Description=@0", filter.Description);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody))
                {
                    SQLStr.Append(" AND ContentBody like @0", "%" + filter.ContentBody + "%");
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