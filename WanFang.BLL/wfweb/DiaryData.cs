using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.DiaryData;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface IDiaryData_Manager
    {
        DiaryData_Info GetBySN(long DiaryDataID);
        IEnumerable<DiaryData_Info> GetAll();
        IEnumerable<DiaryData_Info> GetByParameter(DiaryData_Filter Filter, string _orderby = "");
        long Insert(DiaryData_Info data);
        bool Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns);
        bool Update(DiaryData_Info data);
        int Delete(long DiaryDataID);
        bool IsExist(long DiaryDataID);
    }
    #endregion
    */
    #region implementation
    public class DiaryData_Manager //: IDiaryData_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(DiaryData_Manager));
        #endregion

        #region Operation: Select
        public DiaryData_Info GetBySN(long DiaryDataID)
        {
            return new DiaryData_Repo().GetBySN(DiaryDataID);
        }

        public IEnumerable<DiaryData_Info> GetAll()
        {
            return new DiaryData_Repo().GetAll();
        }

        public IEnumerable<DiaryData_Info> GetByParameter(DiaryData_Filter Filter, string _orderby = "")
        {
            return new DiaryData_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(DiaryData_Info data)
        {
            long newID = 0;
            try
            {
                newID = new DiaryData_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns)
        {
            return new DiaryData_Repo().Update(DiaryDataID, data, columns) > 0;
        }

        public bool Update(DiaryData_Info data)
        {
            return new DiaryData_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long DiaryDataID)
        {
            return new DiaryData_Repo().Delete(DiaryDataID);
        }
        #endregion

        #region public functions
        public bool IsExist(long DiaryDataID)
        {
            return (GetBySN(DiaryDataID) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}