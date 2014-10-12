using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.LogLogin;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface ILogLogin_Manager
    {
        LogLogin_Info GetBySN(long LogLoginId);
        IEnumerable<LogLogin_Info> GetAll();
        IEnumerable<LogLogin_Info> GetByParameter(LogLogin_Filter Filter, string _orderby = "");
        long Insert(LogLogin_Info data);
        bool Update(long LogLoginId, LogLogin_Info data, IEnumerable<string> columns);
        bool Update(LogLogin_Info data);
        int Delete(long LogLoginId);
        bool IsExist(long LogLoginId);
    }
    #endregion
    */
    #region implementation
    public class LogLogin_Manager //: ILogLogin_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(LogLogin_Manager));
        #endregion

        #region Operation: Select
        public LogLogin_Info GetBySN(long LogLoginId)
        {
            return new LogLogin_Repo().GetBySN(LogLoginId);
        }

        public IEnumerable<LogLogin_Info> GetAll()
        {
            return new LogLogin_Repo().GetAll();
        }

        public IEnumerable<LogLogin_Info> GetByParameter(LogLogin_Filter Filter, string _orderby = "")
        {
            return new LogLogin_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(LogLogin_Info data)
        {
            long newID = 0;
            try
            {
                newID = new LogLogin_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long LogLoginId, LogLogin_Info data, IEnumerable<string> columns)
        {
            return new LogLogin_Repo().Update(LogLoginId, data, columns) > 0;
        }

        public bool Update(LogLogin_Info data)
        {
            return new LogLogin_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long LogLoginId)
        {
            return new LogLogin_Repo().Delete(LogLoginId);
        }
        #endregion

        #region public functions
        public bool IsExist(long LogLoginId)
        {
            return (GetBySN(LogLoginId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}