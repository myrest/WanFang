using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.db_AboutContent;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL.db_AboutContent
{
    /*
    #region interface
    public interface Idb_AboutContent_Manager
    {
        db_AboutContent_Info GetBySN(long AboutContent);
        IEnumerable<db_AboutContent_Info> GetAll();
        IEnumerable<db_AboutContent_Info> GetByParameter(db_AboutContent_Filter Filter, string _orderby = "");
        long Insert(db_AboutContent_Info data);
        bool Update(long AboutContent, db_AboutContent_Info data, IEnumerable<string> columns);
        bool Update(db_AboutContent_Info data);
        int Delete(long AboutContent);
        bool IsExist(long AboutContent);
    }
    #endregion
    */
    #region implementation
    public class db_AboutContent_Manager //: Idb_AboutContent_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(db_AboutContent_Manager));
        #endregion

        #region Operation: Select
        public db_AboutContent_Info GetBySN(long AboutContent)
        {
            return new db_AboutContent_Repo().GetBySN(AboutContent);
        }

        public IEnumerable<db_AboutContent_Info> GetAll()
        {
            return new db_AboutContent_Repo().GetAll();
        }

        public IEnumerable<db_AboutContent_Info> GetByParameter(db_AboutContent_Filter Filter, string _orderby = "")
        {
            return new db_AboutContent_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(db_AboutContent_Info data)
        {
            long newID = 0;
            try
            {
                newID = new db_AboutContent_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutContent, db_AboutContent_Info data, IEnumerable<string> columns)
        {
            return new db_AboutContent_Repo().Update(AboutContent, data, columns) > 0;
        }

        public bool Update(db_AboutContent_Info data)
        {
            return new db_AboutContent_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutContent)
        {
            return new db_AboutContent_Repo().Delete(AboutContent);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutContent)
        {
            return (GetBySN(AboutContent) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}