using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.CostNews;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class CostNews_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(CostNews_Manager));
        #endregion

        #region Operation: Select
        public CostNews_Info GetBySN(long CostNewsId)
        {
            return new CostNews_Repo().GetBySN(CostNewsId);
        }

        public IEnumerable<CostNews_Info> GetAll()
        {
            return new CostNews_Repo().GetAll();
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter)
        {
            return new CostNews_Repo().GetByParam(Filter);
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter, Rest.Core.Paging Page)
        {
            return new CostNews_Repo().GetByParam(Filter, Page);
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter, string _orderby)
        {
            return new CostNews_Repo().GetByParam(Filter, _orderby);
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new CostNews_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new CostNews_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostNews_Info> GetByParameter(CostNews_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new CostNews_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(CostNews_Info data)
        {
            long newID = 0;
            try
            {
                newID = new CostNews_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long CostNewsId, CostNews_Info data, IEnumerable<string> columns)
        {
            return new CostNews_Repo().Update(CostNewsId, data, columns) > 0;
        }

        public bool Update(CostNews_Info data)
        {
            return new CostNews_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostNewsId)
        {
            return new CostNews_Repo().Delete(CostNewsId);
        }
        #endregion

        #region public functions
        public bool IsExist(long CostNewsId)
        {
            return (GetBySN(CostNewsId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}