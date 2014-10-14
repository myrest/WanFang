using WanFang.Domain;
using WanFang.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanFang.DAL.AboutContent
{
    public class AboutBindingListing
    {
        #region Operation: Select
        public AboutContent_Info GetBySN(long AboutContentId)
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"SELECT *, b.Category as AboutName FROM db_AboutContent a 
                            inner join db_About b on a.AboutId = b.AboutId 
                            inner join db_AboutCategory c on c.AboutCategoryId = a.AboutCategoryId")
                .Append("WHERE AboutContentId=@0", AboutContentId);

                var result = db.SingleOrDefault<AboutContent_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<AboutContent_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM db_AboutContent");
                var result = db.Query<AboutContent_Info>(SQLStr);

                return result;
            }
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter)
        {
            return GetByParam(Filter, null, null, "");
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page)
        {
            return GetByParam(Filter, Page, null, "");
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby)
        {
            return GetByParam(Filter, null, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, null, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, string[] fieldNames, string _orderby, Paging Page)
        {
            return GetByParam(Filter, Page, fieldNames, _orderby);
        }

        public List<AboutContent_Info> GetByParam(AboutContent_Filter Filter, Paging Page, string[] fieldNames, string _orderby)
        {
            if (fieldNames == null) { fieldNames = new string[] { "*" }; }
            if (Page == null) { Page = new Paging(); }
            using (var db = new DBExecutor().GetDatabase())
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Page<AboutContent_Info>(Page.CurrentPage, Page.ItemsPerPage, SQLStr);
                Page.Convert<AboutContent_Info>(result);

                return result.Items;
            }
        }

        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(AboutContent_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM db_AboutContent")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.AboutContentId.HasValue)
                {
                    SQLStr.Append(" AND AboutContentId=@0", filter.AboutContentId.Value);
                }
                if (filter.AboutCategoryId.HasValue)
                {
                    SQLStr.Append(" AND AboutCategoryId=@0", filter.AboutCategoryId.Value);
                }
                if (!string.IsNullOrEmpty(filter.UnitName))
                {
                    SQLStr.Append(" AND UnitName=@0", filter.UnitName);
                }
                if (filter.OpenType.HasValue)
                {
                    SQLStr.Append(" AND OpenType=@0", filter.OpenType.Value);
                }
                if (!string.IsNullOrEmpty(filter.OpenUrl))
                {
                    SQLStr.Append(" AND OpenUrl=@0", filter.OpenUrl);
                }
                if (!string.IsNullOrEmpty(filter.Content1))
                {
                    SQLStr.Append(" AND Content1=@0", filter.Content1);
                }
                if (!string.IsNullOrEmpty(filter.Content2))
                {
                    SQLStr.Append(" AND Content2=@0", filter.Content2);
                }
                if (!string.IsNullOrEmpty(filter.Content3))
                {
                    SQLStr.Append(" AND Content3=@0", filter.Content3);
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
                if (filter.Position1.HasValue)
                {
                    SQLStr.Append(" AND Position1=@0", filter.Position1.Value);
                }
                if (filter.Position2.HasValue)
                {
                    SQLStr.Append(" AND Position2=@0", filter.Position2.Value);
                }
                if (filter.Position3.HasValue)
                {
                    SQLStr.Append(" AND Position3=@0", filter.Position3.Value);
                }
                if (filter.IsActive.HasValue)
                {
                    SQLStr.Append(" AND IsActive=@0", filter.IsActive.Value);
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
}