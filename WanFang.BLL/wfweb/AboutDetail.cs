using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.AboutDetail;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface IAboutDetail_Manager
    {
        AboutDetail_Info GetBySN(long NoPk);
        IEnumerable<AboutDetail_Info> GetAll();
        IEnumerable<AboutDetail_Info> GetByParameter(AboutDetail_Filter Filter, string _orderby = "");
        long Insert(AboutDetail_Info data);
        bool Update(long NoPk, AboutDetail_Info data, IEnumerable<string> columns);
        bool Update(AboutDetail_Info data);
        int Delete(long NoPk);
        bool IsExist(long NoPk);
    }
    #endregion
    */
    #region implementation
    public class AboutDetail_Manager //: IAboutDetail_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(AboutDetail_Manager));
        #endregion

        #region Operation: Select
        public AboutDetail_Info GetBySN(long NoPk)
        {
            return new AboutDetail_Repo().GetBySN(NoPk);
        }

        public IEnumerable<AboutDetail_Info> GetAll()
        {
            return new AboutDetail_Repo().GetAll();
        }

        public IEnumerable<AboutDetail_Info> GetByParameter(AboutDetail_Filter Filter, string _orderby = "")
        {
            return new AboutDetail_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(AboutDetail_Info data)
        {
            long newID = 0;
            try
            {
                newID = new AboutDetail_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long NoPk, AboutDetail_Info data, IEnumerable<string> columns)
        {
            return new AboutDetail_Repo().Update(NoPk, data, columns) > 0;
        }

        public bool Update(AboutDetail_Info data)
        {
            return new AboutDetail_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new AboutDetail_Repo().Delete(NoPk);
        }
        #endregion

        #region public functions
        public bool IsExist(long NoPk)
        {
            return (GetBySN(NoPk) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}