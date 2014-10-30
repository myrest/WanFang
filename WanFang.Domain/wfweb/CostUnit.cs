using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ICostUnit_Info
    {
        int CostUnitId { get; set; }
        string CostName { get; set; }
        string DeptName { get; set; }
        string UnitName { get; set; }
        string ContentBody { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_CostUnit")]
    [Rest.Core.PetaPoco.PrimaryKey("CostUnitId")]
    public class CostUnit_Info //: ICostUnit_Info
    {
        #region private fields
        /// <summary>
        /// 順序(特色醫療單元管理)
        /// </summary>
        public int CostUnitId { get; set; }
        /// <summary>
        /// 單元名稱(特色醫療單元管理)
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 內容(特色醫療單元管理)
        /// </summary>
        public string DeptName { get; set; }
        public string UnitName { get; set; }
        public string ContentBody { get; set; }
        /// <summary>
        /// 圖片上傳(特色醫療單元管理)
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 圖片上傳2(特色醫療單元管理)
        /// </summary>
        public string Image2 { get; set; }
        /// <summary>
        /// 圖片上傳3(特色醫療單元管理)
        /// </summary>
        public string Image3 { get; set; }
        /// <summary>
        /// 圖片上傳4(特色醫療單元管理)
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 上/下架
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public CostUnit_Info()
        {
        }
        #endregion
    }

    public class CostUnit_Filter
    {
        public int? CostUnitId { get; set; }
        public string CostName { get; set; }
        public string DeptName { get; set; }
        public string UnitName { get; set; }
        public string ContentBody { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above CostUnit_Info field for search criteria
    }
    #endregion
}