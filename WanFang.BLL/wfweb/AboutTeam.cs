using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.AboutTeam;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class AboutTeam_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(AboutTeam_Manager));
        #endregion

        #region Operation: Select
        public AboutTeam_Info GetBySN(long AboutTeamId)
        {
            return new AboutTeam_Repo().GetBySN(AboutTeamId);
        }

        public IEnumerable<AboutTeam_Info> GetAll()
        {
            return new AboutTeam_Repo().GetAll();
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter)
        {
            return new AboutTeam_Repo().GetByParam(Filter);
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter, Rest.Core.Paging Page)
        {
            return new AboutTeam_Repo().GetByParam(Filter, Page);
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter, string _orderby)
        {
            return new AboutTeam_Repo().GetByParam(Filter, _orderby);
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutTeam_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new AboutTeam_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutTeam_Info> GetByParameter(AboutTeam_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutTeam_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(AboutTeam_Info data)
        {
            long newID = 0;
            try
            {
                newID = new AboutTeam_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutTeamId, AboutTeam_Info data, IEnumerable<string> columns)
        {
            return new AboutTeam_Repo().Update(AboutTeamId, data, columns) > 0;
        }

        public bool Update(AboutTeam_Info data)
        {
            return new AboutTeam_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutTeamId)
        {
            return new AboutTeam_Repo().Delete(AboutTeamId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutTeamId)
        {
            return (GetBySN(AboutTeamId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}