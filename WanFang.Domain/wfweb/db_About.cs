using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface Idb_About_Info
    {
        int AboutId { get; set; }
        int SortNum { get; set; }
        string Category { get; set; }
        int IsActive { get; set; }
        DateTime lastUpdate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_About")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutId")]
    public class db_About_Info //: Idb_About_Info
    {
        #region private fields
        /// <summary>
        /// 關於萬芳-類別
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
        public DateTime lastUpdate { get; set; }
        #endregion

        #region Constructor
        public db_About_Info()
        {
        }
        #endregion
    }

    public class db_About_Filter
    {
        public int? AboutId { get; set; }
        public int? SortNum { get; set; }
        public string Category { get; set; }
        public int? IsActive { get; set; }
        public DateTime? lastUpdate { get; set; }
        //You can copy/modify above db_About_Info field for search criteria
    }
    #endregion
}