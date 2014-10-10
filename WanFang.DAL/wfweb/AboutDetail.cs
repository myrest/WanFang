using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutDetail
{
    #region interface
    public interface IAboutDetail_Repo
    {
        AboutDetail_Info GetBySN(long NoPk);
        IEnumerable<AboutDetail_Info> GetAll();
        IEnumerable<AboutDetail_Info> GetByParam(AboutDetail_Filter Filter, string _orderby = "");
        IEnumerable<AboutDetail_Info> GetByParam(AboutDetail_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(AboutDetail_Info data);
        int Update(long NoPk, AboutDetail_Info data, IEnumerable<string> columns);
        int Update(AboutDetail_Info data);
        int Delete(long NoPk);
    }
    #endregion

    #region Implementation
    public class AboutDetail_Repo
    {
        #region Operation: Select
        public AboutDetail_Info GetBySN(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM AboutDetail")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<AboutDetail_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutDetail_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM AboutDetail");
                var result = db.Query<AboutDetail_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<AboutDetail_Info> GetByParam(AboutDetail_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<AboutDetail_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<AboutDetail_Info> GetByParam(AboutDetail_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<AboutDetail_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(AboutDetail_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long NoPk, AboutDetail_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, NoPk, columns);
            }
        }

        public int Update(AboutDetail_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("AboutDetail", "NoPk", null, NoPk);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutDetail_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutDetail_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM AboutDetail")
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