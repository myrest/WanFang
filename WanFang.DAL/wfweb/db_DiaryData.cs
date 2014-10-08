using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.db_DiaryData
{
    #region interface
    public interface Idb_DiaryData_Repo
    {
        db_DiaryData_Info GetBySN(long pd_id);
        IEnumerable<db_DiaryData_Info> GetAll();
        IEnumerable<db_DiaryData_Info> GetByParam(db_DiaryData_Filter Filter, string _orderby = "");
        IEnumerable<db_DiaryData_Info> GetByParam(db_DiaryData_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(db_DiaryData_Info data);
        int Update(long pd_id, db_DiaryData_Info data, IEnumerable<string> columns);
        int Update(db_DiaryData_Info data);
        int Delete(long pd_id);
    }
    #endregion

    #region Implementation
    public class db_DiaryData_Repo
    {
        #region Operation: Select
        public db_DiaryData_Info GetBySN(long pd_id)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_DiaryData")
                .Append("WHERE pd_id=@0", pd_id);

                var result = db.SingleOrDefault<db_DiaryData_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<db_DiaryData_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_DiaryData");
                var result = db.Query<db_DiaryData_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_DiaryData_Info> GetByParam(db_DiaryData_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<db_DiaryData_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_DiaryData_Info> GetByParam(db_DiaryData_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<db_DiaryData_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(db_DiaryData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long pd_id, db_DiaryData_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, pd_id, columns);
            }
        }

        public int Update(db_DiaryData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long pd_id)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_DiaryData", "pd_id", null, pd_id);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(db_DiaryData_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(db_DiaryData_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_DiaryData")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (_orderby != "")
                    SQLStr.Append("ORDER BY @0", _orderby);

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