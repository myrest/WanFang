using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.AboutContent;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface IAboutContent_Manager
    {
        AboutContent_Info GetBySN(long AboutContentId);
        IEnumerable<AboutContent_Info> GetAll();
        IEnumerable<AboutContent_Info> GetByParameter(AboutContent_Filter Filter, string _orderby = "");
        long Insert(AboutContent_Info data);
        bool Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns);
        bool Update(AboutContent_Info data);
        int Delete(long AboutContentId);
        bool IsExist(long AboutContentId);
    }
    #endregion
    */
    #region implementation
    public class AboutContent_Manager //: IAboutContent_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(AboutContent_Manager));
        #endregion

        #region Operation: Select
        public AboutContent_Info GetBySN(long AboutContentId)
        {
            return new AboutContent_Repo().GetBySN(AboutContentId);
        }

        public IEnumerable<AboutContent_Info> GetAll()
        {
            return new AboutContent_Repo().GetAll();
        }

        public IEnumerable<AboutContent_Info> GetByParameter(AboutContent_Filter Filter, string _orderby = "")
        {
            return new AboutContent_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(AboutContent_Info data)
        {
            long newID = 0;
            try
            {
                newID = new AboutContent_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutContentId, AboutContent_Info data, IEnumerable<string> columns)
        {
            return new AboutContent_Repo().Update(AboutContentId, data, columns) > 0;
        }

        public bool Update(AboutContent_Info data)
        {
            return new AboutContent_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutContentId)
        {
            return new AboutContent_Repo().Delete(AboutContentId);
        }
        #endregion

        #region public functions
        public bool IsExist(long AboutContentId)
        {
            return (GetBySN(AboutContentId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}