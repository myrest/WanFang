using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Op_Qa
{
    #region interface
    public interface IOp_Qa_Repo
    {
        Op_Qa_Info GetBySN(long Op_QaId);
        IEnumerable<Op_Qa_Info> GetAll();
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter);
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, Paging Page);
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string _orderby);
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string _orderby, Paging Page);
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Op_Qa_Info data);
        int Update(long Op_QaId, Op_Qa_Info data, IEnumerable<string> columns);
        int Update(Op_Qa_Info data);
        int Delete(long Op_QaId);
    }
    #endregion

    #region Implementation
    public class Op_Qa_Repo
    {
        #region Operation: Select
        public Op_Qa_Info GetBySN(long Op_QaId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Op_Qa")
                .Append("WHERE Op_QaId=@0", Op_QaId);

                var result = db.SingleOrDefault<Op_Qa_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Op_Qa_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Op_Qa");
                var result = db.Query<Op_Qa_Info>(SQLStr);

                return result;
            }
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Op_Qa_Info> GetByParam(Op_Qa_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Op_Qa_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Op_Qa_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Op_Qa_Info data)
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
        public int Update(long Op_QaId, Op_Qa_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, Op_QaId, columns);
            }
        }

        public int Update(Op_Qa_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long Op_QaId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Op_Qa", "Op_QaId", null, Op_QaId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Op_Qa_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Op_Qa_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Op_Qa")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.Op_QaId.HasValue)
                {
                    SQLStr.Append(" AND Op_QaId=@0", filter.Op_QaId.Value);
                }
                if (!string.IsNullOrEmpty(filter.op_type))
                {
                    SQLStr.Append(" AND op_type=@0", filter.op_type);
                }
                if (!string.IsNullOrEmpty(filter.op_title))
                {
                    SQLStr.Append(" AND op_title=@0", filter.op_title);
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    SQLStr.Append(" AND Description=@0", filter.Description);
                }
                if (!string.IsNullOrEmpty(filter.op_content))
                {
                    SQLStr.Append(" AND op_content=@0", filter.op_content);
                }
                if (filter.hit.HasValue)
                {
                    SQLStr.Append(" AND hit=@0", filter.hit.Value);
                }
                if (filter.IsActive.HasValue)
                {
                    SQLStr.Append(" AND IsActive=@0", filter.IsActive.Value);
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