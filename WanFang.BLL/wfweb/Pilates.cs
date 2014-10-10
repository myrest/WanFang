using System;
using System.Collections.Generic;
using System.Linq;
using WanFang.DAL.Pilates;
using WanFang.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    /*
    #region interface
    public interface IPilates_Manager
    {
        Pilates_Info GetBySN(long PilatesId);
        IEnumerable<Pilates_Info> GetAll();
        IEnumerable<Pilates_Info> GetByParameter(Pilates_Filter Filter, string _orderby = "");
        long Insert(Pilates_Info data);
        bool Update(long PilatesId, Pilates_Info data, IEnumerable<string> columns);
        bool Update(Pilates_Info data);
        int Delete(long PilatesId);
        bool IsExist(long PilatesId);
    }
    #endregion
    */
    #region implementation
    public class Pilates_Manager //: IPilates_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Pilates_Manager));
        #endregion

        #region Operation: Select
        public Pilates_Info GetBySN(long PilatesId)
        {
            return new Pilates_Repo().GetBySN(PilatesId);
        }

        public IEnumerable<Pilates_Info> GetAll()
        {
            return new Pilates_Repo().GetAll();
        }

        public IEnumerable<Pilates_Info> GetByParameter(Pilates_Filter Filter, string _orderby = "")
        {
            return new Pilates_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Pilates_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Pilates_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long PilatesId, Pilates_Info data, IEnumerable<string> columns)
        {
            return new Pilates_Repo().Update(PilatesId, data, columns) > 0;
        }

        public bool Update(Pilates_Info data)
        {
            return new Pilates_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long PilatesId)
        {
            return new Pilates_Repo().Delete(PilatesId);
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