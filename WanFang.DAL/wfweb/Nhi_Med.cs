using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.Nhi_Med
{
    #region interface
    public interface INhi_Med_Repo
    {
        Nhi_Med_Info GetBySN(long MedicationID);
        IEnumerable<Nhi_Med_Info> GetAll();
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter);
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, Paging Page);
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string _orderby);
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string _orderby, Paging Page);
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(Nhi_Med_Info data);
        int Update(long MedicationID, Nhi_Med_Info data, IEnumerable<string> columns);
        int Update(Nhi_Med_Info data);
        int Delete(long MedicationID);
    }
    #endregion

    #region Implementation
    public class Nhi_Med_Repo
    {
        #region Operation: Select
        public Nhi_Med_Info GetBySN(long MedicationID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_Nhi_Med")
                .Append("WHERE MedicationID=@0", MedicationID);

                var result = db.SingleOrDefault<Nhi_Med_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Nhi_Med_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_Nhi_Med");
                var result = db.Query<Nhi_Med_Info>(SQLStr);

                return result;
            }
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<Nhi_Med_Info> GetByParam(Nhi_Med_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<Nhi_Med_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<Nhi_Med_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(Nhi_Med_Info data)
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
        public int Update(long MedicationID, Nhi_Med_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, MedicationID, columns);
            }
        }

        public int Update(Nhi_Med_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long MedicationID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("Nhi_Med", "MedicationID", null, MedicationID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_Med_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Nhi_Med_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_Nhi_Med")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.MedicationID.HasValue)
                {
                    SQLStr.Append(" AND MedicationID=@0", filter.MedicationID.Value);
                }
                if (filter.SortNum.HasValue)
                {
                    SQLStr.Append(" AND SortNum=@0", filter.SortNum.Value);
                }
                if (filter.PublishDate.HasValue)
                {
                    SQLStr.Append(" AND PublishDate=@0", filter.PublishDate.Value);
                }
                if (!string.IsNullOrEmpty(filter.CodeOld))
                {
                    SQLStr.Append(" AND CodeOld=@0", filter.CodeOld);
                }
                if (!string.IsNullOrEmpty(filter.PCodeOld))
                {
                    SQLStr.Append(" AND PCodeOld=@0", filter.PCodeOld);
                }
                if (!string.IsNullOrEmpty(filter.PNameEngOld))
                {
                    SQLStr.Append(" AND PNameEngOld=@0", filter.PNameEngOld);
                }
                if (!string.IsNullOrEmpty(filter.PNameOld))
                {
                    SQLStr.Append(" AND PNameOld=@0", filter.PNameOld);
                }
                if (!string.IsNullOrEmpty(filter.PNameAndNumOld))
                {
                    SQLStr.Append(" AND PNameAndNumOld=@0", filter.PNameAndNumOld);
                }
                if (!string.IsNullOrEmpty(filter.ScientificNameOld))
                {
                    SQLStr.Append(" AND ScientificNameOld=@0", filter.ScientificNameOld);
                }
                if (!string.IsNullOrEmpty(filter.CompanyNameOld))
                {
                    SQLStr.Append(" AND CompanyNameOld=@0", filter.CompanyNameOld);
                }
                if (!string.IsNullOrEmpty(filter.ImageOld))
                {
                    SQLStr.Append(" AND ImageOld=@0", filter.ImageOld);
                }
                if (!string.IsNullOrEmpty(filter.SuitOld))
                {
                    SQLStr.Append(" AND SuitOld=@0", filter.SuitOld);
                }
                if (!string.IsNullOrEmpty(filter.UsageOld))
                {
                    SQLStr.Append(" AND UsageOld=@0", filter.UsageOld);
                }
                if (!string.IsNullOrEmpty(filter.SideEffectOld))
                {
                    SQLStr.Append(" AND SideEffectOld=@0", filter.SideEffectOld);
                }
                if (!string.IsNullOrEmpty(filter.NotificationOld))
                {
                    SQLStr.Append(" AND NotificationOld=@0", filter.NotificationOld);
                }
                if (!string.IsNullOrEmpty(filter.ModifiedContent))
                {
                    SQLStr.Append(" AND ModifiedContent=@0", filter.ModifiedContent);
                }
                if (filter.HitOld.HasValue)
                {
                    SQLStr.Append(" AND HitOld=@0", filter.HitOld.Value);
                }
                if (!string.IsNullOrEmpty(filter.Code))
                {
                    SQLStr.Append(" AND Code=@0", filter.Code);
                }
                if (!string.IsNullOrEmpty(filter.PCode))
                {
                    SQLStr.Append(" AND PCode=@0", filter.PCode);
                }
                if (!string.IsNullOrEmpty(filter.PNameEng))
                {
                    SQLStr.Append(" AND PNameEng=@0", filter.PNameEng);
                }
                if (!string.IsNullOrEmpty(filter.ScientificName))
                {
                    SQLStr.Append(" AND ScientificName=@0", filter.ScientificName);
                }
                if (!string.IsNullOrEmpty(filter.PName))
                {
                    SQLStr.Append(" AND PName=@0", filter.PName);
                }
                if (!string.IsNullOrEmpty(filter.PNameAndNum))
                {
                    SQLStr.Append(" AND PNameAndNum=@0", filter.PNameAndNum);
                }
                if (!string.IsNullOrEmpty(filter.CompanyName))
                {
                    SQLStr.Append(" AND CompanyName=@0", filter.CompanyName);
                }
                if (!string.IsNullOrEmpty(filter.Image))
                {
                    SQLStr.Append(" AND Image=@0", filter.Image);
                }
                if (!string.IsNullOrEmpty(filter.Suit))
                {
                    SQLStr.Append(" AND Suit=@0", filter.Suit);
                }
                if (!string.IsNullOrEmpty(filter.Usage))
                {
                    SQLStr.Append(" AND Usage=@0", filter.Usage);
                }
                if (!string.IsNullOrEmpty(filter.SideEffect))
                {
                    SQLStr.Append(" AND SideEffect=@0", filter.SideEffect);
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
                    SQLStr.Append("ORDER BY @0", _orderby);

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