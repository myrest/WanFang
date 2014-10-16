using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Guide;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Guide_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Guide_Manager));
        #endregion

        #region Operation: Select
        public Guide_Info GetBySN(long GuideId)
        {
            return new Guide_Repo().GetBySN(GuideId);
        }

        public IEnumerable<Guide_Info> GetAll()
        {
            return new Guide_Repo().GetAll();
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter)
        {
            return new Guide_Repo().GetByParam(Filter);
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter, Rest.Core.Paging Page)
        {
            return new Guide_Repo().GetByParam(Filter, Page);
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter, string _orderby)
        {
            return new Guide_Repo().GetByParam(Filter, _orderby);
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Guide_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Guide_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Guide_Info> GetByParameter(Guide_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Guide_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Guide_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Guide_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long GuideId, Guide_Info data, IEnumerable<string> columns)
        {
            return new Guide_Repo().Update(GuideId, data, columns) > 0;
        }

        public bool Update(Guide_Info data)
        {
            return new Guide_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long GuideId)
        {
            return new Guide_Repo().Delete(GuideId);
        }
        #endregion

        #region public functions
        public bool IsExist(long GuideId)
        {
            return (GetBySN(GuideId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}