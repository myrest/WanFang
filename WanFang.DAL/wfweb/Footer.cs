using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Footer
{
    #region interface
    public interface IFooter_Repo
    {
        Footer_Info GetBySN(long FooterId);
        IEnumerable<Footer_Info> GetAll();
        List<Footer_Info> GetByParam(Footer_Filter Filter);
        List<Footer_Info> GetByParam(Footer_Filter Filter, Paging Page);
        List<Footer_Info> GetByParam(Footer_Filter Filter, string _orderby);
        List<Footer_Info> GetByParam(Footer_Filter Filter, string _orderby, Paging Page);
        List<Footer_Info> GetByParam(Footer_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Footer_Info> GetByParam(Footer_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Footer_Info data);
        int Update(long FooterId, Footer_Info data, IEnumerable<string> columns);
        int Update(Footer_Info data);
        int Delete(long FooterId);
    }
    #endregion

    #region Implementation
    public class Footer_Repo
    {
        #region Operation: Select
        public Footer_Info GetBySN(long FooterId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Footer")
                .Append("WHERE FooterId=@0", FooterId);

                var result = db.SingleOrDefault<Footer_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Footer_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Footer");
                var result = db.Query<Footer_Info>(SQLStr);

                return result;
            }
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Footer_Info> GetByParam(Footer_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Footer_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Footer_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Footer_Info data)
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
        public int Update(long FooterId, Footer_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, FooterId, columns);
            }
        }

        public int Update(Footer_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long FooterId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Footer", "FooterId", null, FooterId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Footer_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Footer_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Footer")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.FooterId.HasValue)
                {
                    SQLStr.Append(" AND FooterId=@0", filter.FooterId.Value);
                }
                if (!string.IsNullOrEmpty(filter.FooterText))
                {
                    SQLStr.Append(" AND FooterText=@0", filter.FooterText);
                }
                if (!string.IsNullOrEmpty(filter.FooterTextMail))
                {
                    SQLStr.Append(" AND FooterTextMail=@0", filter.FooterTextMail);
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