using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface Idb_DiaryData_Info
    {
        int pd_id { get; set; }
        DateTime pd_date { get; set; }
        string pd_subject { get; set; }
        string pd_content { get; set; }
        string pd_photo1 { get; set; }
        string pd_photo2 { get; set; }
        string pd_photo3 { get; set; }
        string pd_photo4 { get; set; }
        string pd_file1 { get; set; }
        string Youtube { get; set; }
        int link { get; set; }
        int hit { get; set; }
        string pd_type { get; set; }
        string pd_code { get; set; }
        string pd_index { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_DiaryData")]
    [Rest.Core.PetaPoco.PrimaryKey("pd_id")]
    public class db_DiaryData_Info //: Idb_DiaryData_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int pd_id { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime pd_date { get; set; }
        /// <summary>
        /// 發佈主題
        /// </summary>
        public string pd_subject { get; set; }
        /// <summary>
        /// 發佈內容
        /// </summary>
        public string pd_content { get; set; }
        /// <summary>
        /// 圖片上傳1
        /// </summary>
        public string pd_photo1 { get; set; }
        /// <summary>
        /// 圖片上傳2
        /// </summary>
        public string pd_photo2 { get; set; }
        /// <summary>
        /// 圖片上傳3
        /// </summary>
        public string pd_photo3 { get; set; }
        /// <summary>
        /// 圖片上傳4
        /// </summary>
        public string pd_photo4 { get; set; }
        /// <summary>
        /// 檔案上傳
        /// </summary>
        public string pd_file1 { get; set; }
        /// <summary>
        /// youtube上傳
        /// </summary>
        public string Youtube { get; set; }
        /// <summary>
        /// 是否放在頭條首頁1:首頁0:非首頁
        /// </summary>
        public int link { get; set; }
        /// <summary>
        /// 點閱率
        /// </summary>
        public int hit { get; set; }
        /// <summary>
        /// 新聞類型
        /// </summary>
        public string pd_type { get; set; }
        /// <summary>
        /// 新聞類型代碼
        /// </summary>
        public string pd_code { get; set; }
        /// <summary>
        /// 首頁三欄內(新版沒有)
        /// </summary>
        public string pd_index { get; set; }
        #endregion

        #region Constructor
        public db_DiaryData_Info()
        {
        }
        #endregion
    }

    public class db_DiaryData_Filter
    {
        public int? pd_id { get; set; }
        public DateTime? pd_date { get; set; }
        public string pd_subject { get; set; }
        public string pd_content { get; set; }
        public string pd_photo1 { get; set; }
        public string pd_photo2 { get; set; }
        public string pd_photo3 { get; set; }
        public string pd_photo4 { get; set; }
        public string pd_file1 { get; set; }
        public string Youtube { get; set; }
        public int? link { get; set; }
        public int? hit { get; set; }
        public string pd_type { get; set; }
        public string pd_code { get; set; }
        public string pd_index { get; set; }
        //You can copy/modify above db_DiaryData_Info field for search criteria
    }
    #endregion
}