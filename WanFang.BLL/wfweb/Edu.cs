using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Edu;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Edu_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Edu_Manager));
        #endregion

        #region Operation: Select
        public Edu_Info GetBySN(long EduId)
        {
            return new Edu_Repo().GetBySN(EduId);
        }

        public IEnumerable<Edu_Info> GetAll()
        {
            return new Edu_Repo().GetAll();
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter)
        {
            return new Edu_Repo().GetByParam(Filter);
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter, Rest.Core.Paging Page)
        {
            return new Edu_Repo().GetByParam(Filter, Page);
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter, string _orderby)
        {
            return new Edu_Repo().GetByParam(Filter, _orderby);
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Edu_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Edu_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Edu_Info> GetByParameter(Edu_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Edu_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Edu_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Edu_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long EduId, Edu_Info data, IEnumerable<string> columns)
        {
            return new Edu_Repo().Update(EduId, data, columns) > 0;
        }

        public bool Update(Edu_Info data)
        {
            return new Edu_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long EduId)
        {
            return new Edu_Repo().Delete(EduId);
        }
        #endregion

        #region public functions
        public bool IsExist(long EduId)
        {
            return (GetBySN(EduId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}