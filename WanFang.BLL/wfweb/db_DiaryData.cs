using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.db_DiaryData;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL.db_DiaryData
{
    /*
    #region interface
    public interface Idb_DiaryData_Manager
    {
        db_DiaryData_Info GetBySN(long pd_id);
        IEnumerable<db_DiaryData_Info> GetAll();
        IEnumerable<db_DiaryData_Info> GetByParameter(db_DiaryData_Filter Filter, string _orderby = "");
        long Insert(db_DiaryData_Info data);
        bool Update(long pd_id, db_DiaryData_Info data, IEnumerable<string> columns);
        bool Update(db_DiaryData_Info data);
        int Delete(long pd_id);
        bool IsExist(long pd_id);
    }
    #endregion
    */
    #region implementation
    public class db_DiaryData_Manager //: Idb_DiaryData_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(db_DiaryData_Manager));
        #endregion

        #region Operation: Select
        public db_DiaryData_Info GetBySN(long pd_id)
        {
            return new db_DiaryData_Repo().GetBySN(pd_id);
        }

        public IEnumerable<db_DiaryData_Info> GetAll()
        {
            return new db_DiaryData_Repo().GetAll();
        }

        public IEnumerable<db_DiaryData_Info> GetByParameter(db_DiaryData_Filter Filter, string _orderby = "")
        {
            return new db_DiaryData_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(db_DiaryData_Info data)
        {
            long newID = 0;
            try
            {
                newID = new db_DiaryData_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long pd_id, db_DiaryData_Info data, IEnumerable<string> columns)
        {
            return new db_DiaryData_Repo().Update(pd_id, data, columns) > 0;
        }

        public bool Update(db_DiaryData_Info data)
        {
            return new db_DiaryData_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long pd_id)
        {
            return new db_DiaryData_Repo().Delete(pd_id);
        }
        #endregion

        #region public functions
        public bool IsExist(long pd_id)
        {
            return (GetBySN(pd_id) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}