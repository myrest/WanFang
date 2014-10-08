using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.db_AboutCategory;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL.db_AboutCategory
{
    /*
    #region interface
    public interface Idb_AboutCategory_Manager
    {
        db_AboutCategory_Info GetBySN(long AboutCategoryId);
        IEnumerable<db_AboutCategory_Info> GetAll();
        IEnumerable<db_AboutCategory_Info> GetByParameter(db_AboutCategory_Filter Filter, string _orderby = "");
        long Insert(db_AboutCategory_Info data);
        bool Update(long AboutCategoryId, db_AboutCategory_Info data, IEnumerable<string> columns);
        bool Update(db_AboutCategory_Info data);
        int Delete(long AboutCategoryId);
        bool IsExist(long AboutCategoryId);
    }
    #endregion
    */
    #region implementation
    public class db_AboutCategory_Manager //: Idb_AboutCategory_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(db_AboutCategory_Manager));
        #endregion

        #region Operation: Select
        public db_AboutCategory_Info GetBySN(long AboutCategoryId)
        {
            return new db_AboutCategory_Repo().GetBySN(AboutCategoryId);
        }

        public IEnumerable<db_AboutCategory_Info> GetAll()
        {
            return new db_AboutCategory_Repo().GetAll();
        }

        public IEnumerable<db_AboutCategory_Info> GetByParameter(db_AboutCategory_Filter Filter, string _orderby = "")
        {
            return new db_AboutCategory_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(db_AboutCategory_Info data)
        {
            long newID = 0;
            try
            {
                newID = new db_AboutCategory_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutCategoryId, db_AboutCategory_Info data, IEnumerable<string> columns)
        {
            return new db_AboutCategory_Repo().Update(AboutCategoryId, data, columns) > 0;
        }

        public bool Update(db_AboutCategory_Info data)
        {
            return new db_AboutCategory_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutCategoryId)
        {
            return new db_AboutCategory_Repo().Delete(AboutCategoryId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutCategoryId)
        {
            return (GetBySN(AboutCategoryId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}