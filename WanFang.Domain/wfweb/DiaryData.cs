using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IDiaryData_Info
    {
        int DiaryDataID { get; set; }
        DateTime PublishDate { get; set; }
        string Subject { get; set; }
        string ContentBody { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        string Image4 { get; set; }
        string FileDocument { get; set; }
        string YoutubeLink { get; set; }
        int IsShowInHeader { get; set; }
        int Hit { get; set; }
        string DiaryType { get; set; }
        string DiaryTypeCode { get; set; }
        string TopThreeColumn { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_DiaryData")]
    [Rest.Core.PetaPoco.PrimaryKey("DiaryDataID")]
    public class DiaryData_Info //: IDiaryData_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int DiaryDataID { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 發佈主題
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 發佈內容
        /// </summary>
        public string ContentBody { get; set; }
        /// <summary>
        /// 圖片上傳1
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
        /// 圖片上傳4
        /// </summary>
        public string Image4 { get; set; }
        /// <summary>
        /// 檔案上傳
        /// </summary>
        public string FileDocument { get; set; }
        /// <summary>
        /// youtube上傳
        /// </summary>
        public string YoutubeLink { get; set; }
        /// <summary>
        /// 是否放在頭條首頁1:首頁0:非首頁
        /// </summary>
        public int IsShowInHeader { get; set; }
        /// <summary>
        /// 點閱率
        /// </summary>
        public int Hit { get; set; }
        /// <summary>
        /// 新聞類型
        /// </summary>
        public string DiaryType { get; set; }
        /// <summary>
        /// 新聞類型代碼
        /// </summary>
        public string DiaryTypeCode { get; set; }
        /// <summary>
        /// 首頁三欄內(新版沒有)
        /// </summary>
        public string TopThreeColumn { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public DiaryData_Info()
        {
        }
        #endregion
    }

    public class DiaryData_Filter
    {
        public int? DiaryDataID { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Subject { get; set; }
        public string ContentBody { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string FileDocument { get; set; }
        public string YoutubeLink { get; set; }
        public int? IsShowInHeader { get; set; }
        public int? Hit { get; set; }
        public string DiaryType { get; set; }
        public string DiaryTypeCode { get; set; }
        public string TopThreeColumn { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above DiaryData_Info field for search criteria
    }
    #endregion
}