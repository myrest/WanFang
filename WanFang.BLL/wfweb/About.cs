using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.About;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class About_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(About_Manager));
        #endregion

        #region Operation: Select
        public About_Info GetBySN(long AboutId)
        {
            return new About_Repo().GetBySN(AboutId);
        }

        public IEnumerable<About_Info> GetAll()
        {
            return new About_Repo().GetAll();
        }

        public List<About_Info> GetByParameter(About_Filter Filter)
        {
            return new About_Repo().GetByParam(Filter);
        }

        public List<About_Info> GetByParameter(About_Filter Filter, Rest.Core.Paging Page)
        {
            return new About_Repo().GetByParam(Filter, Page);
        }

        public List<About_Info> GetByParameter(About_Filter Filter, string _orderby)
        {
            return new About_Repo().GetByParam(Filter, _orderby);
        }

        public List<About_Info> GetByParameter(About_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new About_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<About_Info> GetByParameter(About_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new About_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<About_Info> GetByParameter(About_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new About_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(About_Info data)
        {
            long newID = 0;
            try
            {
                newID = new About_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutId, About_Info data, IEnumerable<string> columns)
        {
            return new About_Repo().Update(AboutId, data, columns) > 0;
        }

        public bool Update(About_Info data)
        {
            return new About_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutId)
        {
            return new About_Repo().Delete(AboutId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutId)
        {
            return (GetBySN(AboutId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}