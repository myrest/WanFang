using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IAboutCategory_Info
    {
        int AboutCategoryId { get; set; }
        int AboutId { get; set; }
        int SortNum { get; set; }
        string Category { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_AboutCategory")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutCategoryId")]
    public class AboutCategory_Info //: IAboutCategory_Info
    {
        #region private fields
        /// <summary>
        /// 關於萬芳系列ID
        /// </summary>
        public int AboutCategoryId { get; set; }
        /// <summary>
        /// 關於萬芳ID
        /// </summary>
        public int AboutId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 是否上架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 最後更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public AboutCategory_Info()
        {
        }
        #endregion
    }

    public class AboutCategory_Filter
    {
        public int? AboutCategoryId { get; set; }
        public int? AboutId { get; set; }
        public int? SortNum { get; set; }
        public string Category { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above AboutCategory_Info field for search criteria
    }
    #endregion
}