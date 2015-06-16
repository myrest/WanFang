using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Report
{
    #region interface
    public interface IReport_Repo
    {
        Report_Info GetBySN(long ReportID);
        IEnumerable<Report_Info> GetAll();
        List<Report_Info> GetByParam(Report_Filter Filter);
        List<Report_Info> GetByParam(Report_Filter Filter, Paging Page);
        List<Report_Info> GetByParam(Report_Filter Filter, string _orderby);
        List<Report_Info> GetByParam(Report_Filter Filter, string _orderby, Paging Page);
        List<Report_Info> GetByParam(Report_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Report_Info> GetByParam(Report_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Report_Info data);
        int Update(long ReportID, Report_Info data, IEnumerable<string> columns);
        int Update(Report_Info data);
        int Delete(long ReportID);
    }
    #endregion

    #region Implementation
    public class Report_Repo
    {
        #region Operation: Select
        public Report_Info GetBySN(long ReportID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Report")
                .Append("WHERE ReportID=@0", ReportID);

                var result = db.SingleOrDefault<Report_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Report_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Report");
                var result = db.Query<Report_Info>(SQLStr);

                return result;
            }
        }

        public List<Report_Info> GetByParam(Report_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Report_Info> GetByParam(Report_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Report_Info> GetByParam(Report_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Report_Info> GetByParam(Report_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Report_Info> GetByParam(Report_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Report_Info> GetByParam(Report_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Report_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Report_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Report_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = 0;
                var result = db.Insert(data);
                if (result != null)
                {
                    long.TryParse(result.ToString(), out NewID);
                }
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long ReportID, Report_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, ReportID, columns);
            }
        }

        public int Update(Report_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long ReportID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Report", "ReportID", null, ReportID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Report_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Report_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Report")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.ReportID.HasValue)
                {
                    SQLStr.Append(" AND ReportID=@0", filter.ReportID.Value);
                }
                if (!string.IsNullOrEmpty(filter.IP))
                {
                    SQLStr.Append(" AND IP like @0", "%" + filter.IP + "%");
                }
                if (!string.IsNullOrEmpty(filter.Url))
                {
                    SQLStr.Append(" AND Url like @0", "%" + filter.Url + "%");
                }
                if (!string.IsNullOrEmpty(filter.Reff))
                {
                    SQLStr.Append(" AND Reff like @0", "%" + filter.Reff + "%");
                }
                if (!string.IsNullOrEmpty(filter.ItemName))
                {
                    SQLStr.Append(" AND ItemName like @0", "%" + filter.ItemName + "%");
                }
                if (filter.CreateDateTime.HasValue)
                {
                    SQLStr.Append(" AND CreateDateTime=@0", filter.CreateDateTime.Value);
                }
                if (filter.DaysOfPeroid.HasValue)
                {
                    SQLStr.Append(" AND CreateDateTime >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()) - @0, 0)", filter.DaysOfPeroid.Value);
                }
                if (_orderby != "")
                    SQLStr.OrderBy(_orderby);

            }
            return SQLStr;
        }

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {
            return string.Join(", ", fieldNames);
        }
        #endregion
    }
    #endregion

}