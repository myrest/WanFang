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
        List<User_Info> GetByParam(User_Filter Filter);
        List<User_Info> GetByParam(User_Filter Filter, Paging Page);
        List<User_Info> GetByParam(User_Filter Filter, string _orderby);
        List<User_Info> GetByParam(User_Filter Filter, string _orderby, Paging Page);
        List<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<User_Info> GetByParam(User_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
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
                .Append("SELECT * FROM db_User")
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
                    .Append("SELECT * FROM db_User");
                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }

        public List<User_Info> GetByParam(User_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<User_Info> GetByParam(User_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<User_Info> GetByParam(User_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<User_Info> GetByParam(User_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<User_Info> GetByParam(User_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<User_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<User_Info>(result);

                return result.Items;
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
                return db.Delete("db_User", "UserID", null, UserID);
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
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_User")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.UserID.HasValue)
                {
                    SQLStr.Append(" AND UserID=@0", filter.UserID.Value);
                }
                if (!string.IsNullOrEmpty(filter.UserName))
                {
                    SQLStr.Append(" AND UserName=@0", filter.UserName);
                }
                if (!string.IsNullOrEmpty(filter.LoginId))
                {
                    SQLStr.Append(" AND LoginId=@0", filter.LoginId);
                }
                if (!string.IsNullOrEmpty(filter.Password))
                {
                    SQLStr.Append(" AND Password=@0", filter.Password);
                }
                if (filter.PermissionType.HasValue)
                {
                    SQLStr.Append(" AND PermissionType=@0", filter.PermissionType.Value);
                }
                if (!string.IsNullOrEmpty(filter.DeptType))
                {
                    SQLStr.Append(" AND DeptType=@0", filter.DeptType);
                }
                if (!string.IsNullOrEmpty(filter.CostName))
                {
                    SQLStr.Append(" AND CostName=@0", filter.CostName);
                }
                if (!string.IsNullOrEmpty(filter.CostCode))
                {
                    SQLStr.Append(" AND CostCode=@0", filter.CostCode);
                }
                if (!string.IsNullOrEmpty(filter.Permission))
                {
                    SQLStr.Append(" AND Permission=@0", filter.Permission);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdator))
                {
                    SQLStr.Append(" AND LastUpdator=@0", filter.LastUpdator);
                }
                if (_orderby != "")
                    SQLStr.OrderBy(_orderby);

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