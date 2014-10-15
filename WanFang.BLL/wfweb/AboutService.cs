using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.AboutService;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class AboutService_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(AboutService_Manager));
        #endregion

        #region Operation: Select
        public AboutService_Info GetBySN(long AboutServiceId)
        {
            return new AboutService_Repo().GetBySN(AboutServiceId);
        }

        public IEnumerable<AboutService_Info> GetAll()
        {
            return new AboutService_Repo().GetAll();
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter)
        {
            return new AboutService_Repo().GetByParam(Filter);
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter, Rest.Core.Paging Page)
        {
            return new AboutService_Repo().GetByParam(Filter, Page);
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter, string _orderby)
        {
            return new AboutService_Repo().GetByParam(Filter, _orderby);
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutService_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new AboutService_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutService_Info> GetByParameter(AboutService_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutService_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(AboutService_Info data)
        {
            long newID = 0;
            try
            {
                newID = new AboutService_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutServiceId, AboutService_Info data, IEnumerable<string> columns)
        {
            return new AboutService_Repo().Update(AboutServiceId, data, columns) > 0;
        }

        public bool Update(AboutService_Info data)
        {
            return new AboutService_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutServiceId)
        {
            return new AboutService_Repo().Delete(AboutServiceId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutServiceId)
        {
            return (GetBySN(AboutServiceId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}