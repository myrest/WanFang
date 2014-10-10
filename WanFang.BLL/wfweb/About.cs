using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.About;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface IAbout_Manager
    {
        About_Info GetBySN(long AboutId);
        IEnumerable<About_Info> GetAll();
        IEnumerable<About_Info> GetByParameter(About_Filter Filter, string _orderby = "");
        long Insert(About_Info data);
        bool Update(long AboutId, About_Info data, IEnumerable<string> columns);
        bool Update(About_Info data);
        int Delete(long AboutId);
        bool IsExist(long AboutId);
    }
    #endregion
    */
    #region implementation
    public class About_Manager //: IAbout_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(About_Manager));
        #endregion

        #region Operation: Select
        public About_Info GetBySN(long AboutId)
        {
            return new About_Repo().GetBySN(AboutId);
        }

        public IEnumerable<About_Info> GetAll()
        {
            return new About_Repo().GetAll();
        }

        public IEnumerable<About_Info> GetByParameter(About_Filter Filter, string _orderby = "")
        {
            return new About_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(About_Info data)
        {
            long newID = 0;
            try
            {
                newID = new About_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutId, About_Info data, IEnumerable<string> columns)
        {
            return new About_Repo().Update(AboutId, data, columns) > 0;
        }

        public bool Update(About_Info data)
        {
            return new About_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutId)
        {
            return new About_Repo().Delete(AboutId);
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