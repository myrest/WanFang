using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.db_Pilates;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL.db_Pilates
{
    /*
    #region interface
    public interface Idb_Pilates_Manager
    {
        db_Pilates_Info GetBySN(long PilatesId);
        IEnumerable<db_Pilates_Info> GetAll();
        IEnumerable<db_Pilates_Info> GetByParameter(db_Pilates_Filter Filter, string _orderby = "");
        long Insert(db_Pilates_Info data);
        bool Update(long PilatesId, db_Pilates_Info data, IEnumerable<string> columns);
        bool Update(db_Pilates_Info data);
        int Delete(long PilatesId);
        bool IsExist(long PilatesId);
    }
    #endregion
    */
    #region implementation
    public class db_Pilates_Manager //: Idb_Pilates_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(db_Pilates_Manager));
        #endregion

        #region Operation: Select
        public db_Pilates_Info GetBySN(long PilatesId)
        {
            return new db_Pilates_Repo().GetBySN(PilatesId);
        }

        public IEnumerable<db_Pilates_Info> GetAll()
        {
            return new db_Pilates_Repo().GetAll();
        }

        public IEnumerable<db_Pilates_Info> GetByParameter(db_Pilates_Filter Filter, string _orderby = "")
        {
            return new db_Pilates_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(db_Pilates_Info data)
        {
            long newID = 0;
            try
            {
                newID = new db_Pilates_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long PilatesId, db_Pilates_Info data, IEnumerable<string> columns)
        {
            return new db_Pilates_Repo().Update(PilatesId, data, columns) > 0;
        }

        public bool Update(db_Pilates_Info data)
        {
            return new db_Pilates_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long PilatesId)
        {
            return new db_Pilates_Repo().Delete(PilatesId);
        }
        #endregion

        #region public functions
        public bool IsExist(long PilatesId)
        {
            return (GetBySN(PilatesId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}