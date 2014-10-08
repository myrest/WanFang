using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.db_About;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL.db_About
{
    /*
    #region interface
    public interface Idb_About_Manager
    {
        db_About_Info GetBySN(long AboutId);
        IEnumerable<db_About_Info> GetAll();
        IEnumerable<db_About_Info> GetByParameter(db_About_Filter Filter, string _orderby = "");
        long Insert(db_About_Info data);
        bool Update(long AboutId, db_About_Info data, IEnumerable<string> columns);
        bool Update(db_About_Info data);
        int Delete(long AboutId);
        bool IsExist(long AboutId);
    }
    #endregion
    */
    #region implementation
    public class db_About_Manager //: Idb_About_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(db_About_Manager));
        #endregion

        #region Operation: Select
        public db_About_Info GetBySN(long AboutId)
        {
            return new db_About_Repo().GetBySN(AboutId);
        }

        public IEnumerable<db_About_Info> GetAll()
        {
            return new db_About_Repo().GetAll();
        }

        public IEnumerable<db_About_Info> GetByParameter(db_About_Filter Filter, string _orderby = "")
        {
            return new db_About_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(db_About_Info data)
        {
            long newID = 0;
            try
            {
                newID = new db_About_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutId, db_About_Info data, IEnumerable<string> columns)
        {
            return new db_About_Repo().Update(AboutId, data, columns) > 0;
        }

        public bool Update(db_About_Info data)
        {
            return new db_About_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutId)
        {
            return new db_About_Repo().Delete(AboutId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutId)
        {
            return (GetBySN(AboutId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}