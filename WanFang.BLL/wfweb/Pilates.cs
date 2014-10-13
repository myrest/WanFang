using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Pilates;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Pilates_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Pilates_Manager));
        #endregion

        #region Operation: Select
        public Pilates_Info GetBySN(long PilatesId)
        {
            return new Pilates_Repo().GetBySN(PilatesId);
        }

        public IEnumerable<Pilates_Info> GetAll()
        {
            return new Pilates_Repo().GetAll();
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter)
        {
            return new Pilates_Repo().GetByParam(Filter);
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter, Rest.Core.Paging Page)
        {
            return new Pilates_Repo().GetByParam(Filter, Page);
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter, string _orderby)
        {
            return new Pilates_Repo().GetByParam(Filter, _orderby);
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Pilates_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Pilates_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Pilates_Info> GetByParameter(Pilates_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Pilates_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Pilates_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Pilates_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long PilatesId, Pilates_Info data, IEnumerable<string> columns)
        {
            return new Pilates_Repo().Update(PilatesId, data, columns) > 0;
        }

        public bool Update(Pilates_Info data)
        {
            return new Pilates_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long PilatesId)
        {
            return new Pilates_Repo().Delete(PilatesId);
        }
        #endregion

        #region public functions
        public bool IsExist(long PilatesId)
        {
            return (GetBySN(PilatesId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}