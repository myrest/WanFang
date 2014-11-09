using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.NormallContent;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class NormallContent_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(NormallContent_Manager));
        #endregion

        #region Operation: Select
        public NormallContent_Info GetBySN(long NormallContentId)
        {
            return new NormallContent_Repo().GetBySN(NormallContentId);
        }

        public IEnumerable<NormallContent_Info> GetAll()
        {
            return new NormallContent_Repo().GetAll();
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter)
        {
            return new NormallContent_Repo().GetByParam(Filter);
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter, Rest.Core.Paging Page)
        {
            return new NormallContent_Repo().GetByParam(Filter, Page);
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter, string _orderby)
        {
            return new NormallContent_Repo().GetByParam(Filter, _orderby);
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new NormallContent_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new NormallContent_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<NormallContent_Info> GetByParameter(NormallContent_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new NormallContent_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(NormallContent_Info data)
        {
            long newID = 0;
            try
            {
                newID = new NormallContent_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long NormallContentId, NormallContent_Info data, IEnumerable<string> columns)
        {
            return new NormallContent_Repo().Update(NormallContentId, data, columns) > 0;
        }

        public bool Update(NormallContent_Info data)
        {
            return new NormallContent_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NormallContentId)
        {
            return new NormallContent_Repo().Delete(NormallContentId);
        }
        #endregion

        #region public functions
        public bool IsExist(long NormallContentId)
        {
            return (GetBySN(NormallContentId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}