using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IHomePage_Info
    {
        int HomePageId { get; set; }
        string Title { get; set; }
        string Link { get; set; }
        DateTime DisplayDateTime { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_HomePage")]
    [Rest.Core.PetaPoco.PrimaryKey("HomePageId")]
    public class HomePage_Info //: IHomePage_Info
    {
        #region private fields
        public int HomePageId { get; set; }
        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 連結
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 顯示時間
        /// </summary>
        public DateTime DisplayDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public HomePage_Info()
        {
        }
        #endregion
    }

    public class HomePage_Filter
    {
        public int? HomePageId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime? DisplayDateTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above HomePage_Info field for search criteria
    }
    #endregion
}