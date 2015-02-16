using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IWebDownload_Info
    {
        int WebDownLoadID { get; set; }
        int SortNum { get; set; }
        string CostName { get; set; }
        string CostId { get; set; }
        string DeptName { get; set; }
        string File1 { get; set; }
        string DocumentName { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_WebDownload")]
    [Rest.Core.PetaPoco.PrimaryKey("WebDownLoadID")]
    public class WebDownload_Info //: IWebDownload_Info
    {
        #region private fields
        /// <summary>
        /// 特色醫療檔案下載管理流水號
        /// </summary>
        public int WebDownLoadID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 門診
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 科別代碼
        /// </summary>
        public string CostId { get; set; }
        /// <summary>
        /// 科別
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 檔案路徑
        /// </summary>
        public string File1 { get; set; }
        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// 上/下架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 更新人員
        /// </summary>
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public WebDownload_Info()
        {
        }
        #endregion
    }

    public class WebDownload_Filter
    {
        public int? WebDownLoadID { get; set; }
        public int? SortNum { get; set; }
        public string CostName { get; set; }
        public string CostId { get; set; }
        public string DeptName { get; set; }
        public string File1 { get; set; }
        public string DocumentName { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above WebDownload_Info field for search criteria
    }
    #endregion
}