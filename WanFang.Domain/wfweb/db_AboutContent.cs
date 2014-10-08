using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface Idb_AboutContent_Info
    {
        int AboutContent { get; set; }
        int AboutCategoryId { get; set; }
        string UnitName { get; set; }
        int OpenType { get; set; }
        string OpenUrl { get; set; }
        string Content1 { get; set; }
        string Content2 { get; set; }
        string Content3 { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        int Position1 { get; set; }
        int Position2 { get; set; }
        int Position3 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_AboutContent")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutContent")]
    public class db_AboutContent_Info //: Idb_AboutContent_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int AboutContent { get; set; }
        /// <summary>
        /// 類別ID
        /// </summary>
        public int AboutCategoryId { get; set; }
        /// <summary>
        /// 單元名稱
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 開啟方式
        /// </summary>
        public int OpenType { get; set; }
        public string OpenUrl { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public int Position3 { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructor
        public db_AboutContent_Info()
        {
        }
        #endregion
    }

    public class db_AboutContent_Filter
    {
        public int? AboutContent { get; set; }
        public int? AboutCategoryId { get; set; }
        public string UnitName { get; set; }
        public int? OpenType { get; set; }
        public string OpenUrl { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int? Position1 { get; set; }
        public int? Position2 { get; set; }
        public int? Position3 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        //You can copy/modify above db_AboutContent_Info field for search criteria
    }
    #endregion
}