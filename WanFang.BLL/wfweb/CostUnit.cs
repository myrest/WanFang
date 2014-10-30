using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.CostUnit;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class CostUnit_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(CostUnit_Manager));
        #endregion

        #region Operation: Select
        public CostUnit_Info GetBySN(long CostUnitId)
        {
            return new CostUnit_Repo().GetBySN(CostUnitId);
        }

        public IEnumerable<CostUnit_Info> GetAll()
        {
            return new CostUnit_Repo().GetAll();
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter)
        {
            return new CostUnit_Repo().GetByParam(Filter);
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter, Rest.Core.Paging Page)
        {
            return new CostUnit_Repo().GetByParam(Filter, Page);
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter, string _orderby)
        {
            return new CostUnit_Repo().GetByParam(Filter, _orderby);
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new CostUnit_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new CostUnit_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostUnit_Info> GetByParameter(CostUnit_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new CostUnit_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(CostUnit_Info data)
        {
            long newID = 0;
            try
            {
                newID = new CostUnit_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long CostUnitId, CostUnit_Info data, IEnumerable<string> columns)
        {
            return new CostUnit_Repo().Update(CostUnitId, data, columns) > 0;
        }

        public bool Update(CostUnit_Info data)
        {
            return new CostUnit_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostUnitId)
        {
            return new CostUnit_Repo().Delete(CostUnitId);
        }
        #endregion

        #region public functions
        public bool IsExist(long CostUnitId)
        {
            return (GetBySN(CostUnitId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}