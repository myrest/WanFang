using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Pilates
{
    #region interface
    public interface IPilates_Repo
    {
        Pilates_Info GetBySN(long PilatesId);
        IEnumerable<Pilates_Info> GetAll();
        IEnumerable<Pilates_Info> GetByParam(Pilates_Filter Filter, string _orderby = "");
        IEnumerable<Pilates_Info> GetByParam(Pilates_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(Pilates_Info data);
        int Update(long PilatesId, Pilates_Info data, IEnumerable<string> columns);
        int Update(Pilates_Info data);
        int Delete(long PilatesId);
    }
    #endregion

    #region Implementation
    public class Pilates_Repo
    {
        #region Operation: Select
        public Pilates_Info GetBySN(long PilatesId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Pilates")
                .Append("WHERE PilatesId=@0", PilatesId);

                var result = db.SingleOrDefault<Pilates_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Pilates_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Pilates");
                var result = db.Query<Pilates_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Pilates_Info> GetByParam(Pilates_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Pilates_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Pilates_Info> GetByParam(Pilates_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Pilates_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(Pilates_Info data)
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
        public int Update(long PilatesId, Pilates_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, PilatesId, columns);
            }
        }

        public int Update(Pilates_Info data)
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
                return db.Delete("Pilates", "PilatesId", null, PilatesId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Pilates_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Pilates_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Pilates")
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