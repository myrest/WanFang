using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IAboutService_Info
    {
        int AboutServiceId { get; set; }
        int SortNum { get; set; }
        string UnitName { get; set; }
        string Description { get; set; }
        int OpenType { get; set; }
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
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_AboutService")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutServiceId")]
    public class AboutService_Info //: IAboutService_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int AboutServiceId { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 簡述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 開啟目標(0:self, 1:blank)
        /// </summary>
        public int OpenType { get; set; }
        /// <summary>
        /// 開啟方式(0:Link, 1:Content)
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
        /// 圖檔1
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 圖檔2
        /// </summary>
        public string Image2 { get; set; }
        /// <summary>
        /// 圖檔3
        /// </summary>
        public string Image3 { get; set; }
        /// <summary>
        /// 位置1
        /// </summary>
        public int Position1 { get; set; }
        /// <summary>
        /// 位置2
        /// </summary>
        public int Position2 { get; set; }
        /// <summary>
        /// 位置3
        /// </summary>
        public int Position3 { get; set; }
        /// <summary>
        /// 上/下架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 最後更新人員
        /// </summary>
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public AboutService_Info()
        {
        }
        #endregion
    }

    public class AboutService_Filter
    {
        public int? AboutServiceId { get; set; }
        public int? SortNum { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public int? OpenType { get; set; }
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
        //You can copy/modify above AboutService_Info field for search criteria
    }
    #endregion
}