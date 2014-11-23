using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Nhi_Qa
{
    #region interface
    public interface INhi_Qa_Repo
    {
        Nhi_Qa_Info GetBySN(long Nhi_QaId);
        IEnumerable<Nhi_Qa_Info> GetAll();
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter);
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, Paging Page);
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string _orderby);
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string _orderby, Paging Page);
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Nhi_Qa_Info data);
        int Update(long Nhi_QaId, Nhi_Qa_Info data, IEnumerable<string> columns);
        int Update(Nhi_Qa_Info data);
        int Delete(long Nhi_QaId);
    }
    #endregion

    #region Implementation
    public class Nhi_Qa_Repo
    {
        #region Operation: Select
        public Nhi_Qa_Info GetBySN(long Nhi_QaId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Nhi_Qa")
                .Append("WHERE Nhi_QaId=@0", Nhi_QaId);

                var result = db.SingleOrDefault<Nhi_Qa_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Nhi_Qa_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Nhi_Qa");
                var result = db.Query<Nhi_Qa_Info>(SQLStr);

                return result;
            }
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_Qa_Info> GetByParam(Nhi_Qa_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Nhi_Qa_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Nhi_Qa_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Nhi_Qa_Info data)
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
        public int Update(long Nhi_QaId, Nhi_Qa_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, Nhi_QaId, columns);
            }
        }

        public int Update(Nhi_Qa_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long Nhi_QaId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Nhi_Qa", "Nhi_QaId", null, Nhi_QaId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_Qa_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_Qa_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Nhi_Qa")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.Nhi_QaId.HasValue)
                {
                    SQLStr.Append(" AND Nhi_QaId=@0", filter.Nhi_QaId.Value);
                }
                if (!string.IsNullOrEmpty(filter.nhi_title))
                {
                    SQLStr.Append(" AND nhi_title like @0", "%" + filter.nhi_title + "%");
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    SQLStr.Append(" AND Description=@0", filter.Description);
                }
                if (!string.IsNullOrEmpty(filter.nhi_con))
                {
                    SQLStr.Append(" AND nhi_con=@0", filter.nhi_con);
                }
                if (filter.nhi_date.HasValue)
                {
                    SQLStr.Append(" AND nhi_date=@0", filter.nhi_date.Value);
                }
                if (filter.hit.HasValue)
                {
                    SQLStr.Append(" AND hit=@0", filter.hit.Value);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
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