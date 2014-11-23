using WanFang.Domain;

using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Nhi_p
{
    #region interface
    public interface INhi_p_Repo
    {
        Nhi_p_Info GetBySN(long nhi_pId);
        IEnumerable<Nhi_p_Info> GetAll();
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter);
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, Paging Page);
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string _orderby);
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string _orderby, Paging Page);
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Nhi_p_Info data);
        int Update(long nhi_pId, Nhi_p_Info data, IEnumerable<string> columns);
        int Update(Nhi_p_Info data);
        int Delete(long nhi_pId);
    }
    #endregion

    #region Implementation
    public class Nhi_p_Repo
    {
        #region Operation: Select
        public Nhi_p_Info GetBySN(long nhi_pId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Nhi_p")
                .Append("WHERE nhi_pId=@0", nhi_pId);

                var result = db.SingleOrDefault<Nhi_p_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Nhi_p_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Nhi_p");
                var result = db.Query<Nhi_p_Info>(SQLStr);

                return result;
            }
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_p_Info> GetByParam(Nhi_p_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Nhi_p_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Nhi_p_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Nhi_p_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                long NewID = 0;
                var result = db.Insert(data);
                if (result != null)
                {
                    long.TryParse(result.ToString(), out NewID);
                }
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long nhi_pId, Nhi_p_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, nhi_pId, columns);
            }
        }

        public int Update(Nhi_p_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long nhi_pId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("db_Nhi_p", "nhi_pId", null, nhi_pId);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_p_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_p_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Nhi_p")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.nhi_pId.HasValue)
                {
                    SQLStr.Append(" AND nhi_pId=@0", filter.nhi_pId.Value);
                }
                if (filter.nhi_date.HasValue)
                {
                    SQLStr.Append(" AND nhi_date=@0", filter.nhi_date.Value);
                }
                if (!string.IsNullOrEmpty(filter.nhi_code))
                {
                    SQLStr.Append(" AND nhi_code=@0", filter.nhi_code);
                }
                if (!string.IsNullOrEmpty(filter.nhi_type))
                {
                    SQLStr.Append(" AND nhi_type=@0", filter.nhi_type);
                }
                if (!string.IsNullOrEmpty(filter.nhi_cname))
                {
                    SQLStr.Append(" AND nhi_cname like @0", "%" + filter.nhi_cname + "%");
                }
                if (!string.IsNullOrEmpty(filter.nhi_ename))
                {
                    SQLStr.Append(" AND nhi_ename=@0", filter.nhi_ename);
                }
                if (!string.IsNullOrEmpty(filter.fee_code))
                {
                    SQLStr.Append(" AND fee_code=@0", filter.fee_code);
                }
                if (!string.IsNullOrEmpty(filter.HealthCode))
                {
                    SQLStr.Append(" AND HealthCode=@0", filter.HealthCode);
                }
                if (!string.IsNullOrEmpty(filter.mark_name))
                {
                    SQLStr.Append(" AND mark_name=@0", filter.mark_name);
                }
                if (!string.IsNullOrEmpty(filter.unit))
                {
                    SQLStr.Append(" AND unit=@0", filter.unit);
                }
                if (!string.IsNullOrEmpty(filter.nhi_cost))
                {
                    SQLStr.Append(" AND nhi_cost=@0", filter.nhi_cost);
                }
                if (!string.IsNullOrEmpty(filter.self_cost))
                {
                    SQLStr.Append(" AND self_cost=@0", filter.self_cost);
                }
                if (!string.IsNullOrEmpty(filter.price_dif))
                {
                    SQLStr.Append(" AND price_dif=@0", filter.price_dif);
                }
                if (filter.hit.HasValue)
                {
                    SQLStr.Append(" AND hit=@0", filter.hit.Value);
                }
                if (!string.IsNullOrEmpty(filter.warnings))
                {
                    SQLStr.Append(" AND warnings=@0", filter.warnings);
                }
                if (!string.IsNullOrEmpty(filter.contrain))
                {
                    SQLStr.Append(" AND contrain=@0", filter.contrain);
                }
                if (!string.IsNullOrEmpty(filter.sideffect))
                {
                    SQLStr.Append(" AND sideffect=@0", filter.sideffect);
                }
                if (filter.LastUpdate.HasValue)
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate.Value);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdator))
                {
                    SQLStr.Append(" AND LastUpdator=@0", filter.LastUpdator);
                }
                if (_orderby != "")
                    SQLStr.OrderBy(_orderby);

            }
            return SQLStr;
        }

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {
            return string.Join(", ", fieldNames);
        }
        #endregion
    }
    #endregion

}