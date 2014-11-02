using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.TeamIntroduce;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class TeamIntroduce_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(TeamIntroduce_Manager));
        #endregion

        #region Operation: Select
        public TeamIntroduce_Info GetBySN(long TeamIntroduceId)
        {
            return new TeamIntroduce_Repo().GetBySN(TeamIntroduceId);
        }

        public IEnumerable<TeamIntroduce_Info> GetAll()
        {
            return new TeamIntroduce_Repo().GetAll();
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter);
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter, Rest.Core.Paging Page)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter, Page);
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter, string _orderby)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter, _orderby);
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<TeamIntroduce_Info> GetByParameter(TeamIntroduce_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new TeamIntroduce_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(TeamIntroduce_Info data)
        {
            long newID = 0;
            try
            {
                newID = new TeamIntroduce_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long TeamIntroduceId, TeamIntroduce_Info data, IEnumerable<string> columns)
        {
            return new TeamIntroduce_Repo().Update(TeamIntroduceId, data, columns) > 0;
        }

        public bool Update(TeamIntroduce_Info data)
        {
            return new TeamIntroduce_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TeamIntroduceId)
        {
            return new TeamIntroduce_Repo().Delete(TeamIntroduceId);
        }
        #endregion

        #region public functions
        public bool IsExist(long TeamIntroduceId)
        {
            return (GetBySN(TeamIntroduceId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}