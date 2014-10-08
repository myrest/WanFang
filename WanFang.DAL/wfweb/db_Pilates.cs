using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.db_Pilates
{
    #region interface
    public interface Idb_Pilates_Repo
    {
        db_Pilates_Info GetBySN(long PilatesId);
        IEnumerable<db_Pilates_Info> GetAll();
        IEnumerable<db_Pilates_Info> GetByParam(db_Pilates_Filter Filter, string _orderby = "");
        IEnumerable<db_Pilates_Info> GetByParam(db_Pilates_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(db_Pilates_Info data);
        int Update(long PilatesId, db_Pilates_Info data, IEnumerable<string> columns);
        int Update(db_Pilates_Info data);
        int Delete(long PilatesId);
    }
    #endregion

    #region Implementation
    public class db_Pilates_Repo
    {
        #region Operation: Select
        public db_Pilates_Info GetBySN(long PilatesId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Pilates")
                .Append("WHERE PilatesId=@0", PilatesId);

                var result = db.SingleOrDefault<db_Pilates_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<db_Pilates_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Pilates");
                var result = db.Query<db_Pilates_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_Pilates_Info> GetByParam(db_Pilates_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<db_Pilates_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_Pilates_Info> GetByParam(db_Pilates_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<db_Pilates_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(db_Pilates_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long PilatesId, db_Pilates_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, PilatesId, columns);
            }
        }

        public int Update(db_Pilates_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long PilatesId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Pilates", "PilatesId", null, PilatesId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(db_Pilates_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(db_Pilates_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Pilates")
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