using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.HomePage;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class HomePage_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(HomePage_Manager));
        #endregion

        #region Operation: Select
        public HomePage_Info GetBySN(long HomePageId)
        {
            return new HomePage_Repo().GetBySN(HomePageId);
        }

        public IEnumerable<HomePage_Info> GetAll()
        {
            return new HomePage_Repo().GetAll();
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter)
        {
            return new HomePage_Repo().GetByParam(Filter);
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter, Rest.Core.Paging Page)
        {
            return new HomePage_Repo().GetByParam(Filter, Page);
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter, string _orderby)
        {
            return new HomePage_Repo().GetByParam(Filter, _orderby);
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new HomePage_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new HomePage_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<HomePage_Info> GetByParameter(HomePage_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new HomePage_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(HomePage_Info data)
        {
            long newID = 0;
            try
            {
                newID = new HomePage_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long HomePageId, HomePage_Info data, IEnumerable<string> columns)
        {
            return new HomePage_Repo().Update(HomePageId, data, columns) > 0;
        }

        public bool Update(HomePage_Info data)
        {
            return new HomePage_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long HomePageId)
        {
            return new HomePage_Repo().Delete(HomePageId);
        }
        #endregion

        #region public functions
        public bool IsExist(long HomePageId)
        {
            return (GetBySN(HomePageId) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
}