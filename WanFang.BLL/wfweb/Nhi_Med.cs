using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Nhi_Med;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Nhi_Med_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Nhi_Med_Manager));
        #endregion

        #region Operation: Select
        public Nhi_Med_Info GetBySN(long MedicationID)
        {
            return new Nhi_Med_Repo().GetBySN(MedicationID);
        }

        public IEnumerable<Nhi_Med_Info> GetAll()
        {
            return new Nhi_Med_Repo().GetAll();
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter)
        {
            return new Nhi_Med_Repo().GetByParam(Filter);
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter, Rest.Core.Paging Page)
        {
            return new Nhi_Med_Repo().GetByParam(Filter, Page);
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter, string _orderby)
        {
            return new Nhi_Med_Repo().GetByParam(Filter, _orderby);
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_Med_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Nhi_Med_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_Med_Info> GetByParameter(Nhi_Med_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Nhi_Med_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Nhi_Med_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Nhi_Med_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long MedicationID, Nhi_Med_Info data, IEnumerable<string> columns)
        {
            return new Nhi_Med_Repo().Update(MedicationID, data, columns) > 0;
        }

        public bool Update(Nhi_Med_Info data)
        {
            return new Nhi_Med_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long MedicationID)
        {
            return new Nhi_Med_Repo().Delete(MedicationID);
        }
        #endregion

        #region public functions
        public bool IsExist(long MedicationID)
        {
            return (GetBySN(MedicationID) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}