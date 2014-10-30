using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IEdu_Info
    {
        int EduId { get; set; }
        string CostName { get; set; }
        DateTime EduDate { get; set; }
        string DateStart { get; set; }
        string DateEnd { get; set; }
        string Title { get; set; }
        string Place { get; set; }
        string Teacher { get; set; }
        string Notes { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Edu")]
    [Rest.Core.PetaPoco.PrimaryKey("EduId")]
    public class Edu_Info //: IEdu_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int EduId { get; set; }
        /// <summary>
        /// 衛教類別
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 衛教日期
        /// </summary>
        public DateTime EduDate { get; set; }
        /// <summary>
        /// 衛教起始時間
        /// </summary>
        public string DateStart { get; set; }
        /// <summary>
        /// 衛教結束時間
        /// </summary>
        public string DateEnd { get; set; }
        /// <summary>
        /// 衛教標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 衛教地點
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// 衛教主講者
        /// </summary>
        public string Teacher { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Edu_Info()
        {
        }
        #endregion
    }

    public class Edu_Filter
    {
        public int? EduId { get; set; }
        public string CostName { get; set; }
        public DateTime? EduDate { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public string Teacher { get; set; }
        public string Notes { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Edu_Info field for search criteria
    }
    #endregion
}