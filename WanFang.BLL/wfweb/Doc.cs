using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Doc;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Doc_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Doc_Manager));
        #endregion

        #region Operation: Select
        public Doc_Info GetBySN(long DocId)
        {
            return new Doc_Repo().GetBySN(DocId);
        }

        public IEnumerable<Doc_Info> GetAll()
        {
            return new Doc_Repo().GetAll();
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter)
        {
            return new Doc_Repo().GetByParam(Filter);
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter, Rest.Core.Paging Page)
        {
            return new Doc_Repo().GetByParam(Filter, Page);
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter, string _orderby)
        {
            return new Doc_Repo().GetByParam(Filter, _orderby);
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Doc_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Doc_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Doc_Info> GetByParameter(Doc_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Doc_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Doc_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Doc_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long DocId, Doc_Info data, IEnumerable<string> columns)
        {
            return new Doc_Repo().Update(DocId, data, columns) > 0;
        }

        public bool Update(Doc_Info data)
        {
            return new Doc_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long DocId)
        {
            return new Doc_Repo().Delete(DocId);
        }
        #endregion

        #region public functions
        public bool IsExist(long DocId)
        {
            return (GetBySN(DocId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}