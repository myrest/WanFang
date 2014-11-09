using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Op_Qa;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Op_Qa_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Op_Qa_Manager));
        #endregion

        #region Operation: Select
        public Op_Qa_Info GetBySN(long Op_QaId)
        {
            return new Op_Qa_Repo().GetBySN(Op_QaId);
        }

        public IEnumerable<Op_Qa_Info> GetAll()
        {
            return new Op_Qa_Repo().GetAll();
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter)
        {
            return new Op_Qa_Repo().GetByParam(Filter);
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter, Rest.Core.Paging Page)
        {
            return new Op_Qa_Repo().GetByParam(Filter, Page);
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter, string _orderby)
        {
            return new Op_Qa_Repo().GetByParam(Filter, _orderby);
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Op_Qa_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Op_Qa_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Op_Qa_Info> GetByParameter(Op_Qa_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Op_Qa_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Op_Qa_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Op_Qa_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long Op_QaId, Op_Qa_Info data, IEnumerable<string> columns)
        {
            return new Op_Qa_Repo().Update(Op_QaId, data, columns) > 0;
        }

        public bool Update(Op_Qa_Info data)
        {
            return new Op_Qa_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long Op_QaId)
        {
            return new Op_Qa_Repo().Delete(Op_QaId);
        }
        #endregion

        #region public functions
        public bool IsExist(long Op_QaId)
        {
            return (GetBySN(Op_QaId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}