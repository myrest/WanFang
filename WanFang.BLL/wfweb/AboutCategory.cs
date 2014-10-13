using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.AboutCategory;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class AboutCategory_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(AboutCategory_Manager));
        #endregion

        #region Operation: Select
        public AboutCategory_Info GetBySN(long AboutCategoryId)
        {
            return new AboutCategory_Repo().GetBySN(AboutCategoryId);
        }

        public IEnumerable<AboutCategory_Info> GetAll()
        {
            return new AboutCategory_Repo().GetAll();
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter)
        {
            return new AboutCategory_Repo().GetByParam(Filter);
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter, Rest.Core.Paging Page)
        {
            return new AboutCategory_Repo().GetByParam(Filter, Page);
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter, string _orderby)
        {
            return new AboutCategory_Repo().GetByParam(Filter, _orderby);
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutCategory_Repo().GetByParam(Filter, _orderby, Page);
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter, Rest.Core.Paging Page, string[] fieldNames, string _orderby)
        {
            return new AboutCategory_Repo().GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutCategory_Info> GetByParameter(AboutCategory_Filter Filter, string[] fieldNames, string _orderby, Rest.Core.Paging Page)
        {
            return new AboutCategory_Repo().GetByParam(Filter, fieldNames, _orderby, Page);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(AboutCategory_Info data)
        {
            long newID = 0;
            try
            {
                newID = new AboutCategory_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AboutCategoryId, AboutCategory_Info data, IEnumerable<string> columns)
        {
            return new AboutCategory_Repo().Update(AboutCategoryId, data, columns) > 0;
        }

        public bool Update(AboutCategory_Info data)
        {
            return new AboutCategory_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AboutCategoryId)
        {
            return new AboutCategory_Repo().Delete(AboutCategoryId);
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
}