using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Nhi_Qa;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Nhi_Qa_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Nhi_Qa_Manager));
        #endregion

        #region Operation: Select
        public Nhi_Qa_Info GetBySN(long Nhi_QaId)
        {
            return new Nhi_Qa_Repo().GetBySN(Nhi_QaId);
        }

        public IEnumerable<Nhi_Qa_Info> GetAll()
        {
            return new Nhi_Qa_Repo().GetAll();
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter);
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter, Rest.Core.Paging Page)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter, Page);
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter, string _orderby)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter, _orderby);
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_Qa_Info> GetByParameter(Nhi_Qa_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_Qa_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Nhi_Qa_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Nhi_Qa_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long Nhi_QaId, Nhi_Qa_Info data, IEnumerable<string> columns)
        {
            return new Nhi_Qa_Repo().Update(Nhi_QaId, data, columns) > 0;
        }

        public bool Update(Nhi_Qa_Info data)
        {
            return new Nhi_Qa_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long Nhi_QaId)
        {
            return new Nhi_Qa_Repo().Delete(Nhi_QaId);
        }
        #endregion

        #region public functions
        public bool IsExist(long Nhi_QaId)
        {
            return (GetBySN(Nhi_QaId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}