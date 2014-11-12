using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Question
{
    #region interface
    public interface IQuestion_Repo
    {
        Question_Info GetBySN(long QuestionId);
        IEnumerable<Question_Info> GetAll();
        List<Question_Info> GetByParam(Question_Filter Filter);
        List<Question_Info> GetByParam(Question_Filter Filter, Paging Page);
        List<Question_Info> GetByParam(Question_Filter Filter, string _orderby);
        List<Question_Info> GetByParam(Question_Filter Filter, string _orderby, Paging Page);
        List<Question_Info> GetByParam(Question_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Question_Info> GetByParam(Question_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Question_Info data);
        int Update(long QuestionId, Question_Info data, IEnumerable<string> columns);
        int Update(Question_Info data);
        int Delete(long QuestionId);
    }
    #endregion

    #region Implementation
    public class Question_Repo
    {
        #region Operation: Select
        public Question_Info GetBySN(long QuestionId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Question")
                .Append("WHERE QuestionId=@0", QuestionId);

                var result = db.SingleOrDefault<Question_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Question_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Question");
                var result = db.Query<Question_Info>(SQLStr);

                return result;
            }
        }

        public List<Question_Info> GetByParam(Question_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Question_Info> GetByParam(Question_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Question_Info> GetByParam(Question_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Question_Info> GetByParam(Question_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Question_Info> GetByParam(Question_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Question_Info> GetByParam(Question_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Question_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Question_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Question_Info data)
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
        public int Update(long QuestionId, Question_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, QuestionId, columns);
            }
        }

        public int Update(Question_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long QuestionId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Question", "QuestionId", null, QuestionId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Question_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Question_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Question")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.QuestionId.HasValue)
                {
                    SQLStr.Append(" AND QuestionId=@0", filter.QuestionId.Value);
                }
                if (filter.Q_time.HasValue)
                {
                    SQLStr.Append(" AND Q_time=@0", filter.Q_time.Value);
                }
                if (!string.IsNullOrEmpty(filter.Q_type))
                {
                    SQLStr.Append(" AND Q_type=@0", filter.Q_type);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.Dept))
                {
                    SQLStr.Append(" AND Dept=@0", filter.Dept);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.Q_title))
                {
                    SQLStr.Append(" AND Q_title=@0", filter.Q_title);
                }
                if (!string.IsNullOrEmpty(filter.Q_question))
                {
                    SQLStr.Append(" AND Q_question like @0", "%" + filter.Q_question + "%");
                }
                if (!string.IsNullOrEmpty(filter.Q_ans))
                {
                    SQLStr.Append(" AND Q_ans=@0", filter.Q_ans);
                }
                if (!string.IsNullOrEmpty(filter.Q_edit))
                {
                    SQLStr.Append(" AND Q_edit=@0", filter.Q_edit);
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