using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Nhi_p;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Nhi_p_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Nhi_p_Manager));
        #endregion

        #region Operation: Select
        public Nhi_p_Info GetBySN(long nhi_pId)
        {
            return new Nhi_p_Repo().GetBySN(nhi_pId);
        }

        public IEnumerable<Nhi_p_Info> GetAll()
        {
            return new Nhi_p_Repo().GetAll();
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter)
        {
            return new Nhi_p_Repo().GetByParam(Filter);
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter, Rest.Core.Paging Page)
        {
            return new Nhi_p_Repo().GetByParam(Filter, Page);
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter, string _orderby)
        {
            return new Nhi_p_Repo().GetByParam(Filter, _orderby);
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_p_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Nhi_p_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_p_Info> GetByParameter(Nhi_p_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_p_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Nhi_p_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Nhi_p_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long nhi_pId, Nhi_p_Info data, IEnumerable<string> columns)
        {
            return new Nhi_p_Repo().Update(nhi_pId, data, columns) > 0;
        }

        public bool Update(Nhi_p_Info data)
        {
            return new Nhi_p_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long nhi_pId)
        {
            return new Nhi_p_Repo().Delete(nhi_pId);
        }
        #endregion

        #region public functions
        public bool IsExist(long nhi_pId)
        {
            return (GetBySN(nhi_pId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}