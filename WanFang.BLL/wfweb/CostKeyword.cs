using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.CostKeyword;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class CostKeyword_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(CostKeyword_Manager));
        #endregion

        #region Operation: Select
        public CostKeyword_Info GetBySN(long CostKeywordId)
        {
            return new CostKeyword_Repo().GetBySN(CostKeywordId);
        }

        public IEnumerable<CostKeyword_Info> GetAll()
        {
            return new CostKeyword_Repo().GetAll();
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter)
        {
            return new CostKeyword_Repo().GetByParam(Filter);
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter, Rest.Core.Paging Page)
        {
            return new CostKeyword_Repo().GetByParam(Filter, Page);
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter, string _orderby)
        {
            return new CostKeyword_Repo().GetByParam(Filter, _orderby);
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new CostKeyword_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new CostKeyword_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<CostKeyword_Info> GetByParameter(CostKeyword_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new CostKeyword_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(CostKeyword_Info data)
        {
            long newID = 0;
            try
            {
                newID = new CostKeyword_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long CostKeywordId, CostKeyword_Info data, IEnumerable<string> columns)
        {
            return new CostKeyword_Repo().Update(CostKeywordId, data, columns) > 0;
        }

        public bool Update(CostKeyword_Info data)
        {
            return new CostKeyword_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long CostKeywordId)
        {
            return new CostKeyword_Repo().Delete(CostKeywordId);
        }
        #endregion

        #region public functions
        public bool IsExist(long CostKeywordId)
        {
            return (GetBySN(CostKeywordId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}