using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface INormallContent_Info
    {
        int NormallContentId { get; set; }
        string ContentName { get; set; }
        string UnitName { get; set; }
        int OpenType { get; set; }
        string OpenUrl { get; set; }
        int UrlTarget { get; set; }
        string Content1 { get; set; }
        string Content2 { get; set; }
        string Content3 { get; set; }
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
    [Rest.Core.PetaPoco.TableName("db_NormallContent")]
    [Rest.Core.PetaPoco.PrimaryKey("NormallContentId")]
    public class NormallContent_Info //: INormallContent_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int NormallContentId { get; set; }
        /// <summary>
        /// 圖文類別名稱(方便記憶及取用)
        /// </summary>
        public string ContentName { get; set; }
        /// <summary>
        /// 單元名稱
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 開啟方式
        /// </summary>
        public int OpenType { get; set; }
        public string OpenUrl { get; set; }
        /// <summary>
        /// 開啟方式(0:開啟於原頁面,1:開啟於新視窗)
        /// </summary>
        public int UrlTarget { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public int Position3 { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime? VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public NormallContent_Info()
        {
        }
        #endregion
    }

    public class NormallContent_Filter
    {
        public int? NormallContentId { get; set; }
        public string ContentName { get; set; }
        public string UnitName { get; set; }
        public int? OpenType { get; set; }
        public string OpenUrl { get; set; }
        public int? UrlTarget { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
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
        //You can copy/modify above NormallContent_Info field for search criteria
    }
    #endregion
}