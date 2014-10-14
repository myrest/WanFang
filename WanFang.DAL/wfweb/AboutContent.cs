using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutContent
{
    #region interface
    public interface IAboutContent_Repo
    {
        AboutContent_Info GetBySN(long AboutContentId);
        IEnumerable<AboutContent_Info> GetAll();
        IEnumerable<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby = "");
        IEnumerable<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(AboutContent_Info data);
        int Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns);
        int Update(AboutContent_Info data);
        int Delete(long AboutContentId);
    }
    #endregion

    #region Implementation
    public class AboutContent_Repo
    {
        #region Operation: Select
        public AboutContent_Info GetBySN(long AboutContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM AboutContent")
                .Append("WHERE AboutContentId=@0", AboutContentId);

                var result = db.SingleOrDefault<AboutContent_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutContent_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM AboutContent");
                var result = db.Query<AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<AboutContent_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(AboutContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, AboutContentId, columns);
            }
        }

        public int Update(AboutContent_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("AboutContent", "AboutContentId", null, AboutContentId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM AboutContent")
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