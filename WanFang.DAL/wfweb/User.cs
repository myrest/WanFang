using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.User
{
    #region interface
    public interface IUser_Repo
    {
        User_Info GetBySN(long UserID);
        IEnumerable<User_Info> GetAll();
        IEnumerable<User_Info> GetByParam(User_Filter Filter, string _orderby = "");
        IEnumerable<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(User_Info data);
        int Update(long UserID, User_Info data, IEnumerable<string> columns);
        int Update(User_Info data);
        int Delete(long UserID);
    }
    #endregion

    #region Implementation
    public class User_Repo
    {
        #region Operation: Select
        public User_Info GetBySN(long UserID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM User")
                .Append("WHERE UserID=@0", UserID);

                var result = db.SingleOrDefault<User_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<User_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM User");
                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<User_Info> GetByParam(User_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(User_Info data)
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
        public int Update(long UserID, User_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, UserID, columns);
            }
        }

        public int Update(User_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long UserID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("User", "UserID", null, UserID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(User_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(User_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM User")
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