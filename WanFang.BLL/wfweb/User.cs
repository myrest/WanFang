using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.User;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class User_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(User_Manager));
        #endregion

        #region Operation: Select
        public User_Info GetBySN(long UserID)
        {
            return new User_Repo().GetBySN(UserID);
        }

        public IEnumerable<User_Info> GetAll()
        {
            return new User_Repo().GetAll();
        }

        public List<User_Info> GetByParameter(User_Filter Filter)
        {
            return new User_Repo().GetByParam(Filter);
        }

        public List<User_Info> GetByParameter(User_Filter Filter, Rest.Core.Paging Page)
        {
            return new User_Repo().GetByParam(Filter, Page);
        }

        public List<User_Info> GetByParameter(User_Filter Filter, string _orderby)
        {
            return new User_Repo().GetByParam(Filter, _orderby);
        }

        public List<User_Info> GetByParameter(User_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new User_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<User_Info> GetByParameter(User_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new User_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<User_Info> GetByParameter(User_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new User_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(User_Info data)
        {
            long newID = 0;
            try
            {
                data.Password = Encrypt.EncryptPassword(data.Password, data.LoginId);
                data.LastUpdate = DateTime.Now;
                newID = new User_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long UserID, User_Info data, IEnumerable<string> columns)
        {
            return new User_Repo().Update(UserID, data, columns) > 0;
        }

        public bool Update(User_Info data)
        {
            return new User_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long UserID)
        {
            return new User_Repo().Delete(UserID);
        }
        #endregion

        #region public functions
        public bool IsExist(long UserID)
        {
            return (GetBySN(UserID) != null);
        }

        public bool Login(string LoginId, string Password)
        {
            var user = new User_Repo().GetByParam(new User_Filter()
            {
                LoginId = LoginId,
            }).FirstOrDefault();
            if (user != null)
            {
                string encPwd = Encrypt.EncryptPassword(Password, user.LoginId);
                return (string.Compare(encPwd, user.Password) == 0);
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region private functions
        #endregion
    }
}