using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Doc
{
    #region interface
    public interface IDoc_Repo
    {
        Doc_Info GetBySN(long DocId);
        IEnumerable<Doc_Info> GetAll();
        List<Doc_Info> GetByParam(Doc_Filter Filter);
        List<Doc_Info> GetByParam(Doc_Filter Filter, Paging Page);
        List<Doc_Info> GetByParam(Doc_Filter Filter, string _orderby);
        List<Doc_Info> GetByParam(Doc_Filter Filter, string _orderby, Paging Page);
        List<Doc_Info> GetByParam(Doc_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Doc_Info> GetByParam(Doc_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Doc_Info data);
        int Update(long DocId, Doc_Info data, IEnumerable<string> columns);
        int Update(Doc_Info data);
        int Delete(long DocId);
    }
    #endregion

    #region Implementation
    public class Doc_Repo
    {
        #region Operation: Select
        public Doc_Info GetBySN(long DocId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Doc")
                .Append("WHERE DocId=@0", DocId);

                var result = db.SingleOrDefault<Doc_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Doc_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Doc");
                var result = db.Query<Doc_Info>(SQLStr);

                return result;
            }
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Doc_Info> GetByParam(Doc_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Doc_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Doc_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Doc_Info data)
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
        public int Update(long DocId, Doc_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, DocId, columns);
            }
        }

        public int Update(Doc_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long DocId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Doc", "DocId", null, DocId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Doc_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Doc_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Doc")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.DocId.HasValue)
                {
                    SQLStr.Append(" AND DocId=@0", filter.DocId.Value);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.DeptName))
                {
                    SQLStr.Append(" AND DeptName=@0", filter.DeptName);
                }
                if (!string.IsNullOrEmpty(filter.Dept))
                {
                    SQLStr.Append(" AND Dept=@0", filter.Dept);
                }
                if (!string.IsNullOrEmpty(filter.DocCode))
                {
                    SQLStr.Append(" AND DocCode=@0", filter.DocCode);
                }
                if (!string.IsNullOrEmpty(filter.DocName))
                {
                    SQLStr.Append(" AND (DocName like @0 or DocCode like  @0) ", "%" + filter.DocName + "%");
                }
                if (!string.IsNullOrEmpty(filter.DocNameE))
                {
                    SQLStr.Append(" AND DocNameE=@0", filter.DocNameE);
                }
                if (!string.IsNullOrEmpty(filter.MainMajor1))
                {
                    SQLStr.Append(" AND MainMajor1=@0", filter.MainMajor1);
                }
                if (!string.IsNullOrEmpty(filter.MainMajor2))
                {
                    SQLStr.Append(" AND MainMajor2=@0", filter.MainMajor2);
                }
                if (!string.IsNullOrEmpty(filter.MainMajor3))
                {
                    SQLStr.Append(" AND MainMajor3=@0", filter.MainMajor3);
                }
                if (!string.IsNullOrEmpty(filter.MainMajor4))
                {
                    SQLStr.Append(" AND MainMajor4=@0", filter.MainMajor4);
                }
                if (!string.IsNullOrEmpty(filter.MainMajor5))
                {
                    SQLStr.Append(" AND MainMajor5=@0", filter.MainMajor5);
                }
                if (!string.IsNullOrEmpty(filter.smain))
                {
                    SQLStr.Append(" AND smain=@0", filter.smain);
                }
                if (!string.IsNullOrEmpty(filter.school))
                {
                    SQLStr.Append(" AND school=@0", filter.school);
                }
                if (!string.IsNullOrEmpty(filter.career))
                {
                    SQLStr.Append(" AND career=@0", filter.career);
                }
                if (!string.IsNullOrEmpty(filter.sci))
                {
                    SQLStr.Append(" AND sci=@0", filter.sci);
                }
                if (filter.webtype.HasValue)
                {
                    SQLStr.Append(" AND webtype=@0", filter.webtype.Value);
                }
                if (!string.IsNullOrEmpty(filter.web))
                {
                    SQLStr.Append(" AND web=@0", filter.web);
                }
                if (!string.IsNullOrEmpty(filter.webcontent))
                {
                    SQLStr.Append(" AND webcontent=@0", filter.webcontent);
                }
                if (!string.IsNullOrEmpty(filter.otime))
                {
                    SQLStr.Append(" AND otime=@0", filter.otime);
                }
                if (filter.status.HasValue)
                {
                    SQLStr.Append(" AND status=@0", filter.status.Value);
                }
                if (!string.IsNullOrEmpty(filter.pic))
                {
                    SQLStr.Append(" AND pic=@0", filter.pic);
                }
                if (filter.seq_id.HasValue)
                {
                    SQLStr.Append(" AND seq_id=@0", filter.seq_id.Value);
                }
                if (!string.IsNullOrEmpty(filter.slic))
                {
                    SQLStr.Append(" AND slic=@0", filter.slic);
                }
                if (!string.IsNullOrEmpty(filter.Association))
                {
                    SQLStr.Append(" AND Association=@0", filter.Association);
                }
                if (!string.IsNullOrEmpty(filter.steach))
                {
                    SQLStr.Append(" AND steach=@0", filter.steach);
                }
                if (!string.IsNullOrEmpty(filter.learn))
                {
                    SQLStr.Append(" AND learn=@0", filter.learn);
                }
                if (filter.conf_flag.HasValue)
                {
                    SQLStr.Append(" AND conf_flag=@0", filter.conf_flag.Value);
                }
                if (filter.conf_date.HasValue)
                {
                    SQLStr.Append(" AND conf_date=@0", filter.conf_date.Value);
                }
                if (!string.IsNullOrEmpty(filter.ncareer))
                {
                    SQLStr.Append(" AND ncareer=@0", filter.ncareer);
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