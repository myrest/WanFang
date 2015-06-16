using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IReport_Info
    {
        int ReportID { get; set; }
        string IP { get; set; }
        string Url { get; set; }
        string Reff { get; set; }
        string ItemName { get; set; }
        DateTime CreateDateTime { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Report")]
    [Rest.Core.PetaPoco.PrimaryKey("ReportID")]
    public class Report_Info //: IReport_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int ReportID { get; set; }
        /// <summary>
        /// IP位置
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 網址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 前網址
        /// </summary>
        public string Reff { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        #endregion

        #region Constructor
        public Report_Info()
        {
        }
        #endregion
    }

    public class Report_Filter
    {
        public int? ReportID { get; set; }
        public string IP { get; set; }
        public string Url { get; set; }
        public string Reff { get; set; }
        public string ItemName { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int? DaysOfPeroid { get; set; }
        //You can copy/modify above Report_Info field for search criteria
    }
    #endregion
}