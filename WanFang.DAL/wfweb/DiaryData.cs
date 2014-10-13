using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.DiaryData
{
    #region interface
    public interface IDiaryData_Repo
    {
        DiaryData_Info GetBySN(long DiaryDataID);
        IEnumerable<DiaryData_Info> GetAll();
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter);
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, Paging Page);
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby);
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby, Paging Page);
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string[] fieldNames, string _orderby, Paging Page);
        List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, Paging Page, string[] fieldNames, string _orderby);
        long Insert(DiaryData_Info data);
        int Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns);
        int Update(DiaryData_Info data);
        int Delete(long DiaryDataID);
    }
    #endregion

    #region Implementation
    public class DiaryData_Repo
    {
        #region Operation: Select
        public DiaryData_Info GetBySN(long DiaryDataID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM db_DiaryData")
                .Append("WHERE DiaryDataID=@0", DiaryDataID);

                var result = db.SingleOrDefault<DiaryData_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<DiaryData_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_DiaryData");
                var result = db.Query<DiaryData_Info>(SQLStr);

                return result;
            }
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<DiaryData_Info> GetByParam(DiaryData_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<DiaryData_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<DiaryData_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region Operation: Insert
        public long Insert(DiaryData_Info data)
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
        public int Update(long DiaryDataID, DiaryData_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data, DiaryDataID, columns);
            }
        }

        public int Update(DiaryData_Info data)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long DiaryDataID)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                return db.Delete("DiaryData", "DiaryDataID", null, DiaryDataID);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(DiaryData_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(DiaryData_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_DiaryData")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.DiaryDataID.HasValue)
                {
                    SQLStr.Append(" AND DiaryDataID=@0", filter.DiaryDataID.Value);
                }
                if (filter.PublishDate.HasValue)
                {
                    SQLStr.Append(" AND PublishDate=@0", filter.PublishDate.Value);
                }
                if (!string.IsNullOrEmpty(filter.Subject))
                {
                    SQLStr.Append(" AND Subject=@0", filter.Subject);
                }
                if (!string.IsNullOrEmpty(filter.ContentBody))
                {
                    SQLStr.Append(" AND ContentBody=@0", filter.ContentBody);
                }
                if (!string.IsNullOrEmpty(filter.Image1))
                {
                    SQLStr.Append(" AND Image1=@0", filter.Image1);
                }
                if (!string.IsNullOrEmpty(filter.Image2))
                {
                    SQLStr.Append(" AND Image2=@0", filter.Image2);
                }
                if (!string.IsNullOrEmpty(filter.Image3))
                {
                    SQLStr.Append(" AND Image3=@0", filter.Image3);
                }
                if (!string.IsNullOrEmpty(filter.Image4))
                {
                    SQLStr.Append(" AND Image4=@0", filter.Image4);
                }
                if (!string.IsNullOrEmpty(filter.FileDocument))
                {
                    SQLStr.Append(" AND FileDocument=@0", filter.FileDocument);
                }
                if (!string.IsNullOrEmpty(filter.YoutubeLink))
                {
                    SQLStr.Append(" AND YoutubeLink=@0", filter.YoutubeLink);
                }
                if (filter.IsShowInHeader.HasValue)
                {
                    SQLStr.Append(" AND IsShowInHeader=@0", filter.IsShowInHeader.Value);
                }
                if (filter.Hit.HasValue)
                {
                    SQLStr.Append(" AND Hit=@0", filter.Hit.Value);
                }
                if (!string.IsNullOrEmpty(filter.DiaryType))
                {
                    SQLStr.Append(" AND DiaryType=@0", filter.DiaryType);
                }
                if (!string.IsNullOrEmpty(filter.DiaryTypeCode))
                {
                    SQLStr.Append(" AND DiaryTypeCode=@0", filter.DiaryTypeCode);
                }
                if (!string.IsNullOrEmpty(filter.TopThreeColumn))
                {
                    SQLStr.Append(" AND TopThreeColumn=@0", filter.TopThreeColumn);
                }
                if (!string.IsNullOrEmpty(filter.LastUpdate))
                {
                    SQLStr.Append(" AND LastUpdate=@0", filter.LastUpdate);
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