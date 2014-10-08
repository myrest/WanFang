using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.db_About
{
    #region interface
    public interface Idb_About_Repo
    {
        db_About_Info GetBySN(long AboutId);
        IEnumerable<db_About_Info> GetAll();
        IEnumerable<db_About_Info> GetByParam(db_About_Filter Filter, string _orderby = "");
        IEnumerable<db_About_Info> GetByParam(db_About_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(db_About_Info data);
        int Update(long AboutId, db_About_Info data, IEnumerable<string> columns);
        int Update(db_About_Info data);
        int Delete(long AboutId);
    }
    #endregion

    #region Implementation
    public class db_About_Repo
    {
        #region Operation: Select
        public db_About_Info GetBySN(long AboutId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_About")
                .Append("WHERE AboutId=@0", AboutId);

                var result = db.SingleOrDefault<db_About_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<db_About_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_About");
                var result = db.Query<db_About_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_About_Info> GetByParam(db_About_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<db_About_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_About_Info> GetByParam(db_About_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<db_About_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(db_About_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long AboutId, db_About_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutId, columns);
            }
        }

        public int Update(db_About_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_About", "AboutId", null, AboutId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(db_About_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(db_About_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_About")
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