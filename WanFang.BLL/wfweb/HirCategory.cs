using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.HirCategory;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class HirCategory_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(HirCategory_Manager));
        #endregion

        #region Operation: Select
        public HirCategory_Info GetBySN(long HirCategoryId)
        {
            return new HirCategory_Repo().GetBySN(HirCategoryId);
        }

        public IEnumerable<HirCategory_Info> GetAll()
        {
            return new HirCategory_Repo().GetAll();
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter)
        {
            return new HirCategory_Repo().GetByParam(Filter);
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter, Rest.Core.Paging Page)
        {
            return new HirCategory_Repo().GetByParam(Filter, Page);
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter, string _orderby)
        {
            return new HirCategory_Repo().GetByParam(Filter, _orderby);
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new HirCategory_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new HirCategory_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HirCategory_Info> GetByParameter(HirCategory_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new HirCategory_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(HirCategory_Info data)
        {
            long newID = 0;
            try
            {
                newID = new HirCategory_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long HirCategoryId, HirCategory_Info data, IEnumerable<string> columns)
        {
            return new HirCategory_Repo().Update(HirCategoryId, data, columns) > 0;
        }

        public bool Update(HirCategory_Info data)
        {
            return new HirCategory_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HirCategoryId)
        {
            return new HirCategory_Repo().Delete(HirCategoryId);
        }
        #endregion

        #region public functions
        public bool IsExist(long HirCategoryId)
        {
            return (GetBySN(HirCategoryId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}