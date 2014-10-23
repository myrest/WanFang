using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Edu
{
    #region interface
    public interface IEdu_Repo
    {
        Edu_Info GetBySN(long EduId);
        IEnumerable<Edu_Info> GetAll();
        List<Edu_Info> GetByParam(Edu_Filter Filter);
        List<Edu_Info> GetByParam(Edu_Filter Filter, Paging Page);
        List<Edu_Info> GetByParam(Edu_Filter Filter, string _orderby);
        List<Edu_Info> GetByParam(Edu_Filter Filter, string _orderby, Paging Page);
        List<Edu_Info> GetByParam(Edu_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Edu_Info> GetByParam(Edu_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Edu_Info data);
        int Update(long EduId, Edu_Info data, IEnumerable<string> columns);
        int Update(Edu_Info data);
        int Delete(long EduId);
    }
    #endregion

    #region Implementation
    public class Edu_Repo
    {
        #region Operation: Select
        public Edu_Info GetBySN(long EduId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Edu")
                .Append("WHERE EduId=@0", EduId);

                var result = db.SingleOrDefault<Edu_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Edu_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Edu");
                var result = db.Query<Edu_Info>(SQLStr);

                return result;
            }
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Edu_Info> GetByParam(Edu_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Edu_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Edu_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Edu_Info data)
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
        public int Update(long EduId, Edu_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, EduId, columns);
            }
        }

        public int Update(Edu_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long EduId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Edu", "EduId", null, EduId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Edu_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Edu_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Edu")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.EduId.HasValue)
                {
                    SQLStr.Append(" AND EduId=@0", filter.EduId.Value);
                }
                if (!string.IsNullOrEmpty(filter.EduType))
                {
                    SQLStr.Append(" AND EduType=@0", filter.EduType);
                }
                if (filter.EduDate.HasValue)
                {
                    SQLStr.Append(" AND EduDate=@0", filter.EduDate.Value);
                }
                if (!string.IsNullOrEmpty(filter.DateStart))
                {
                    SQLStr.Append(" AND DateStart=@0", filter.DateStart);
                }
                if (!string.IsNullOrEmpty(filter.DateEnd))
                {
                    SQLStr.Append(" AND DateEnd=@0", filter.DateEnd);
                }
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    SQLStr.Append(" AND Title=@0", filter.Title);
                }
                if (!string.IsNullOrEmpty(filter.Place))
                {
                    SQLStr.Append(" AND Place=@0", filter.Place);
                }
                if (!string.IsNullOrEmpty(filter.Teacher))
                {
                    SQLStr.Append(" AND Teacher=@0", filter.Teacher);
                }
                if (!string.IsNullOrEmpty(filter.Notes))
                {
                    SQLStr.Append(" AND Notes=@0", filter.Notes);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdate))
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdator))
                {
                    SQLStr.Append(" AND LastUpdator=@0", filter.LastUpdator);
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