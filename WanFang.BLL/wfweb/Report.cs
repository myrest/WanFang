using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Report;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Report_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Report_Manager));
        #endregion

        #region Operation: Select
        public Report_Info GetBySN(long ReportID)
        {
            return new Report_Repo().GetBySN(ReportID);
        }

        public IEnumerable<Report_Info> GetAll()
        {
            return new Report_Repo().GetAll();
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter)
        {
            return new Report_Repo().GetByParam(Filter);
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter, Rest.Core.Paging Page)
        {
            return new Report_Repo().GetByParam(Filter, Page);
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter, string _orderby)
        {
            return new Report_Repo().GetByParam(Filter, _orderby);
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Report_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Report_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Report_Info> GetByParameter(Report_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Report_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Report_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Report_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long ReportID, Report_Info data, IEnumerable<string> columns)
        {
            return new Report_Repo().Update(ReportID, data, columns) > 0;
        }

        public bool Update(Report_Info data)
        {
            return new Report_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long ReportID)
        {
            return new Report_Repo().Delete(ReportID);
        }
        #endregion

        #region public functions
        public bool IsExist(long ReportID)
        {
            return (GetBySN(ReportID) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}