using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.DiaryData
{
    #region interface
    public interface IDiaryData_Repo
    {
        DiaryData_Info GetBySN(long DiaryDataID);
        IEnumerable<DiaryData_Info> GetAll();
        IEnumerable<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby = "");
        IEnumerable<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(DiaryData_Info data);
        int Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns);
        int Update(DiaryData_Info data);
        int Delete(long DiaryDataID);
    }
    #endregion

    #region Implementation
    public class DiaryData_Repo
    {
        #region Operation: Select
        public DiaryData_Info GetBySN(long DiaryDataID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM DiaryData")
                .Append("WHERE DiaryDataID=@0", DiaryDataID);

                var result = db.SingleOrDefault<DiaryData_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<DiaryData_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM DiaryData");
                var result = db.Query<DiaryData_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<DiaryData_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<DiaryData_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(DiaryData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, DiaryDataID, columns);
            }
        }

        public int Update(DiaryData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long DiaryDataID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("DiaryData", "DiaryDataID", null, DiaryDataID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(DiaryData_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(DiaryData_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM DiaryData")
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