using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.HirDetail;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class HirDetail_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(HirDetail_Manager));
        #endregion

        #region Operation: Select
        public HirDetail_Info GetBySN(long HirDetailId)
        {
            return new HirDetail_Repo().GetBySN(HirDetailId);
        }

        public IEnumerable<HirDetail_Info> GetAll()
        {
            return new HirDetail_Repo().GetAll();
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter)
        {
            return new HirDetail_Repo().GetByParam(Filter);
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter, Rest.Core.Paging Page)
        {
            return new HirDetail_Repo().GetByParam(Filter, Page);
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter, string _orderby)
        {
            return new HirDetail_Repo().GetByParam(Filter, _orderby);
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new HirDetail_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new HirDetail_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HirDetail_Info> GetByParameter(HirDetail_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new HirDetail_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(HirDetail_Info data)
        {
            long newID = 0;
            try
            {
                newID = new HirDetail_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long HirDetailId, HirDetail_Info data, IEnumerable<string> columns)
        {
            return new HirDetail_Repo().Update(HirDetailId, data, columns) > 0;
        }

        public bool Update(HirDetail_Info data)
        {
            return new HirDetail_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HirDetailId)
        {
            return new HirDetail_Repo().Delete(HirDetailId);
        }
        #endregion

        #region public functions
        public bool IsExist(long HirDetailId)
        {
            return (GetBySN(HirDetailId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}