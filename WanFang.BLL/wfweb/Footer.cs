using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Footer;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Footer_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Footer_Manager));
        #endregion

        #region Operation: Select
        public Footer_Info GetBySN(long FooterId)
        {
            return new Footer_Repo().GetBySN(FooterId);
        }

        public IEnumerable<Footer_Info> GetAll()
        {
            return new Footer_Repo().GetAll();
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter)
        {
            return new Footer_Repo().GetByParam(Filter);
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter, Rest.Core.Paging Page)
        {
            return new Footer_Repo().GetByParam(Filter, Page);
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter, string _orderby)
        {
            return new Footer_Repo().GetByParam(Filter, _orderby);
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Footer_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Footer_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Footer_Info> GetByParameter(Footer_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Footer_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Footer_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Footer_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long FooterId, Footer_Info data, IEnumerable<string> columns)
        {
            return new Footer_Repo().Update(FooterId, data, columns) > 0;
        }

        public bool Update(Footer_Info data)
        {
            return new Footer_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long FooterId)
        {
            return new Footer_Repo().Delete(FooterId);
        }
        #endregion

        #region public functions
        public bool IsExist(long FooterId)
        {
            return (GetBySN(FooterId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}