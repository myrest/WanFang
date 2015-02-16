using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ICostNews_Info
    {
        int CostNewsId { get; set; }
        string CostName { get; set; }
        string CostId { get; set; }
        string DeptName { get; set; }
        DateTime PublishDate { get; set; }
        string Subject { get; set; }
        string ContentBody { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        string Image4 { get; set; }
        int IsActive { get; set; }
        string UploadFile { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_CostNews")]
    [Rest.Core.PetaPoco.PrimaryKey("CostNewsId")]
    public class CostNews_Info //: ICostNews_Info
    {
        #region private fields
        /// <summary>
        /// 特色醫療最新消息管理
        /// </summary>
        public int CostNewsId { get; set; }
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
        /// 發佈日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 發佈主題
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 發布內容(特色醫療最新消息管理)
        /// </summary>
        public string ContentBody { get; set; }
        /// <summary>
        /// 圖片上傳(特色醫療最新消息管理)
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 圖片上傳2(特色醫療最新消息管理)
        /// </summary>
        public string Image2 { get; set; }
        /// <summary>
        /// 圖片上傳3(特色醫療最新消息管理)
        /// </summary>
        public string Image3 { get; set; }
        /// <summary>
        /// 圖片上傳4(特色醫療最新消息管理)
        /// </summary>
        public string Image4 { get; set; }
        public int IsActive { get; set; }
        /// <summary>
        /// 檔案上傳
        /// </summary>
        public string UploadFile { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public CostNews_Info()
        {
        }
        #endregion
    }

    public class CostNews_Filter
    {
        public int? CostNewsId { get; set; }
        public string CostName { get; set; }
        public string CostId { get; set; }
        public string DeptName { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Subject { get; set; }
        public string ContentBody { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public int? IsActive { get; set; }
        public string UploadFile { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above CostNews_Info field for search criteria
    }
    #endregion
}