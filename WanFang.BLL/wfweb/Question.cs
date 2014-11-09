using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Question;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class Question_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Question_Manager));
        #endregion

        #region Operation: Select
        public Question_Info GetBySN(long QuestionId)
        {
            return new Question_Repo().GetBySN(QuestionId);
        }

        public IEnumerable<Question_Info> GetAll()
        {
            return new Question_Repo().GetAll();
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter)
        {
            return new Question_Repo().GetByParam(Filter);
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter, Rest.Core.Paging Page)
        {
            return new Question_Repo().GetByParam(Filter, Page);
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter, string _orderby)
        {
            return new Question_Repo().GetByParam(Filter, _orderby);
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new Question_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new Question_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Question_Info> GetByParameter(Question_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new Question_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Question_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Question_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long QuestionId, Question_Info data, IEnumerable<string> columns)
        {
            return new Question_Repo().Update(QuestionId, data, columns) > 0;
        }

        public bool Update(Question_Info data)
        {
            return new Question_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long QuestionId)
        {
            return new Question_Repo().Delete(QuestionId);
        }
        #endregion

        #region public functions
        public bool IsExist(long QuestionId)
        {
            return (GetBySN(QuestionId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}