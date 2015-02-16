using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ICostKeyword_Info
    {
        int CostKeywordId { get; set; }
        string CostName { get; set; }
        string DeptName { get; set; }
        string KeyWord { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_CostKeyword")]
    [Rest.Core.PetaPoco.PrimaryKey("CostKeywordId")]
    public class CostKeyword_Info //: ICostKeyword_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int CostKeywordId { get; set; }
        /// <summary>
        /// 科別
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 診別
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 關鍵字
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 上下架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 最後更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 最後更新人員
        /// </summary>
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime? VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public CostKeyword_Info()
        {
        }
        #endregion
    }

    public class CostKeyword_Filter
    {
        public int? CostKeywordId { get; set; }
        public string CostName { get; set; }
        public string DeptName { get; set; }
        public string KeyWord { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above CostKeyword_Info field for search criteria
    }
    #endregion
}