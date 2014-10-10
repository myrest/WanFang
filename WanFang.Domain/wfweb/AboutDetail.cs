using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IAboutDetail_Info
    {
        string CategoryName { get; set; }
        string SeriesName { get; set; }
        string StrName { get; set; }
        string ShowType { get; set; }
        string ShowType2 { get; set; }
        string Link { get; set; }
        string Date { get; set; }
        string Date2 { get; set; }
        string Date3 { get; set; }
        string Photo { get; set; }
        string Photo2 { get; set; }
        string Photo3 { get; set; }
        string Radio { get; set; }
        string Radio2 { get; set; }
        string Radio3 { get; set; }
        string Radio4 { get; set; }
        string Radio5 { get; set; }
        string Radio6 { get; set; }
        string IsActive { get; set; }
        string lastUpdate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("AboutDetail")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class AboutDetail_Info //: IAboutDetail_Info
    {
        #region private fields
        /// <summary>
        /// 類別名稱(新)
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 系列名稱(新)
        /// </summary>
        public string SeriesName { get; set; }
        /// <summary>
        /// 單元名稱(新)
        /// </summary>
        public string StrName { get; set; }
        /// <summary>
        /// 類型一(新)
        /// </summary>
        public string ShowType { get; set; }
        /// <summary>
        /// 類型二(新)
        /// </summary>
        public string ShowType2 { get; set; }
        /// <summary>
        /// 連結-選擇一(新)
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 內容-類型二(新)
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 內容2-類型二(新)
        /// </summary>
        public string Date2 { get; set; }
        /// <summary>
        /// 內容3-類型二(新)
        /// </summary>
        public string Date3 { get; set; }
        /// <summary>
        /// 圖片上傳-類型二(新)
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 圖片上傳2-類型二(新)
        /// </summary>
        public string Photo2 { get; set; }
        /// <summary>
        /// 圖片上傳3-類型二(新)
        /// </summary>
        public string Photo3 { get; set; }
        /// <summary>
        /// 圖片置左/右-類型二(新)
        /// </summary>
        public string Radio { get; set; }
        /// <summary>
        /// 圖片置左/右2-類型二(新)
        /// </summary>
        public string Radio2 { get; set; }
        /// <summary>
        /// 圖片置左/右3-類型二(新)
        /// </summary>
        public string Radio3 { get; set; }
        /// <summary>
        /// 圖片置左/右4-類型二(新)
        /// </summary>
        public string Radio4 { get; set; }
        /// <summary>
        /// 圖片置左/右5-類型二(新)
        /// </summary>
        public string Radio5 { get; set; }
        /// <summary>
        /// 圖片置左/右6-類型二(新)
        /// </summary>
        public string Radio6 { get; set; }
        /// <summary>
        /// 上/下架(新)
        /// </summary>
        public string IsActive { get; set; }
        /// <summary>
        /// 更新日期(新)
        /// </summary>
        public string lastUpdate { get; set; }
        #endregion

        #region Constructor
        public AboutDetail_Info()
        {
        }
        #endregion
    }

    public class AboutDetail_Filter
    {
        public string CategoryName { get; set; }
        public string SeriesName { get; set; }
        public string StrName { get; set; }
        public string ShowType { get; set; }
        public string ShowType2 { get; set; }
        public string Link { get; set; }
        public string Date { get; set; }
        public string Date2 { get; set; }
        public string Date3 { get; set; }
        public string Photo { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Radio { get; set; }
        public string Radio2 { get; set; }
        public string Radio3 { get; set; }
        public string Radio4 { get; set; }
        public string Radio5 { get; set; }
        public string Radio6 { get; set; }
        public string IsActive { get; set; }
        public string lastUpdate { get; set; }
        //You can copy/modify above AboutDetail_Info field for search criteria
    }
    #endregion
}