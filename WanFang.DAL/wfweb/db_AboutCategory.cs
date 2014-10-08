using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.db_AboutCategory
{
    #region interface
    public interface Idb_AboutCategory_Repo
    {
        db_AboutCategory_Info GetBySN(long AboutCategoryId);
        IEnumerable<db_AboutCategory_Info> GetAll();
        IEnumerable<db_AboutCategory_Info> GetByParam(db_AboutCategory_Filter Filter, string _orderby = "");
        IEnumerable<db_AboutCategory_Info> GetByParam(db_AboutCategory_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(db_AboutCategory_Info data);
        int Update(long AboutCategoryId, db_AboutCategory_Info data, IEnumerable<string> columns);
        int Update(db_AboutCategory_Info data);
        int Delete(long AboutCategoryId);
    }
    #endregion

    #region Implementation
    public class db_AboutCategory_Repo
    {
        #region Operation: Select
        public db_AboutCategory_Info GetBySN(long AboutCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_AboutCategory")
                .Append("WHERE AboutCategoryId=@0", AboutCategoryId);

                var result = db.SingleOrDefault<db_AboutCategory_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<db_AboutCategory_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutCategory");
                var result = db.Query<db_AboutCategory_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_AboutCategory_Info> GetByParam(db_AboutCategory_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<db_AboutCategory_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<db_AboutCategory_Info> GetByParam(db_AboutCategory_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<db_AboutCategory_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(db_AboutCategory_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long AboutCategoryId, db_AboutCategory_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutCategoryId, columns);
            }
        }

        public int Update(db_AboutCategory_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutCategoryId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_AboutCategory", "AboutCategoryId", null, AboutCategoryId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(db_AboutCategory_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(db_AboutCategory_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutCategory")
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