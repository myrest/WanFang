using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface INewsData_Info
    {
        int NewsId { get; set; }
        DateTime PublishDate { get; set; }
        string CostName { get; set; }
        string Cost { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Keyword { get; set; }
        string ContentBody { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        string Image4 { get; set; }
        int IsShowOnTeam { get; set; }
        int Hit { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpadtor { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_NewsData")]
    [Rest.Core.PetaPoco.PrimaryKey("NewsId")]
    public class NewsData_Info //: INewsData_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 發表科別中文名稱
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 發表科別代號
        /// </summary>
        public string Cost { get; set; }
        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 發表者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 後台關鍵字(新)
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string ContentBody { get; set; }
        /// <summary>
        /// 圖片上傳(新)
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 圖片上傳2(新)
        /// </summary>
        public string Image2 { get; set; }
        /// <summary>
        /// 圖片上傳3(新)
        /// </summary>
        public string Image3 { get; set; }
        /// <summary>
        /// 圖片上傳4(新)
        /// </summary>
        public string Image4 { get; set; }
        /// <summary>
        /// 顯示在團隊介紹
        /// </summary>
        public int IsShowOnTeam { get; set; }
        /// <summary>
        /// 點閱率
        /// </summary>
        public int Hit { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpadtor { get; set; }
        #endregion

        #region Constructor
        public NewsData_Info()
        {
        }
        #endregion
    }

    public class NewsData_Filter
    {
        public int? NewsId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string CostName { get; set; }
        public string Cost { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keyword { get; set; }
        public string ContentBody { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public int? IsShowOnTeam { get; set; }
        public int? Hit { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpadtor { get; set; }
        //You can copy/modify above NewsData_Info field for search criteria
    }
    #endregion
}