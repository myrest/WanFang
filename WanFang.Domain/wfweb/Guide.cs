using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IGuide_Info
    {
        int GuideId { get; set; }
        int SortNum { get; set; }
        string ItemName { get; set; }
        int DisplayType { get; set; }
        string Link { get; set; }
        string ContentBody1 { get; set; }
        string ContentBody2 { get; set; }
        string ContentBody3 { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        int Position1 { get; set; }
        int Position2 { get; set; }
        int Position3 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Guide")]
    [Rest.Core.PetaPoco.PrimaryKey("GuideId")]
    public class Guide_Info //: IGuide_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int GuideId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 項目名稱
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 顯示方式
        /// </summary>
        public int DisplayType { get; set; }
        /// <summary>
        /// 連結
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 內容1
        /// </summary>
        public string ContentBody1 { get; set; }
        /// <summary>
        /// 內容2
        /// </summary>
        public string ContentBody2 { get; set; }
        /// <summary>
        /// 內容3
        /// </summary>
        public string ContentBody3 { get; set; }
        /// <summary>
        /// 圖片上傳
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 圖片上傳2
        /// </summary>
        public string Image2 { get; set; }
        /// <summary>
        /// 圖片上傳3
        /// </summary>
        public string Image3 { get; set; }
        /// <summary>
        /// 圖片置左/右
        /// </summary>
        public int Position1 { get; set; }
        /// <summary>
        /// 圖片置左/右
        /// </summary>
        public int Position2 { get; set; }
        /// <summary>
        /// 圖片置左/右
        /// </summary>
        public int Position3 { get; set; }
        /// <summary>
        /// 上/下架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期(新)
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime? VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public Guide_Info()
        {
        }
        #endregion
    }

    public class Guide_Filter
    {
        public int? GuideId { get; set; }
        public int? SortNum { get; set; }
        public string ItemName { get; set; }
        public int? DisplayType { get; set; }
        public string Link { get; set; }
        public string ContentBody1 { get; set; }
        public string ContentBody2 { get; set; }
        public string ContentBody3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int? Position1 { get; set; }
        public int? Position2 { get; set; }
        public int? Position3 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above Guide_Info field for search criteria
    }
    #endregion
}