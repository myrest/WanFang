using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.db_AboutContent
{
    #region interface
    public interface Idb_AboutContent_Repo
    {
        db_AboutContent_Info GetBySN(long AboutContent);
        IEnumerable<db_AboutContent_Info> GetAll();
        IEnumerable<db_AboutContent_Info> GetByParam(db_AboutContent_Filter Filter, string _orderby = "");
        IEnumerable<db_AboutContent_Info> GetByParam(db_AboutContent_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(db_AboutContent_Info data);
        int Update(long AboutContent, db_AboutContent_Info data, IEnumerable<string> columns);
        int Update(db_AboutContent_Info data);
        int Delete(long AboutContent);
    }
    #endregion

    #region Implementation
    public class db_AboutContent_Repo
    {
        #region Operation: Select
        public db_AboutContent_Info GetBySN(long AboutContent)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutContent")
                .Append("WHERE AboutContent=@0", AboutContent);

                var result = db.SingleOrDefault<db_AboutContent_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<db_AboutContent_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutContent");
                var result = db.Query<db_AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_AboutContent_Info> GetByParam(db_AboutContent_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<db_AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_AboutContent_Info> GetByParam(db_AboutContent_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<db_AboutContent_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(db_AboutContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long AboutContent, db_AboutContent_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutContent, columns);
            }
        }

        public int Update(db_AboutContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutContent)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutContent", "AboutContent", null, AboutContent);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(db_AboutContent_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(db_AboutContent_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutContent")
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