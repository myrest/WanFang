using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IPilates_Info
    {
        int PilatesId { get; set; }
        string RegID { get; set; }
        string RegName { get; set; }
        string RegSubject { get; set; }
        DateTime PublishDate { get; set; }
        string TimeStart { get; set; }
        string TimeEnd { get; set; }
        string Memo { get; set; }
        string ContentBody { get; set; }
        int IsActive { get; set; }
        int HasTail { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Pilates")]
    [Rest.Core.PetaPoco.PrimaryKey("PilatesId")]
    public class Pilates_Info //: IPilates_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int PilatesId { get; set; }
        /// <summary>
        /// 課程代號P:Pilates核心復健M:孕婦健康瑜珈班Q:肩頸上背疼痛復健班C:兒童背部運動及姿態矯正班O:有氧太P力
        /// </summary>
        public string RegID { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string RegName { get; set; }
        /// <summary>
        /// 課程主題
        /// </summary>
        public string RegSubject { get; set; }
        /// <summary>
        /// 開課日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 上課開始時間
        /// </summary>
        public string TimeStart { get; set; }
        /// <summary>
        /// 上課結束時間
        /// </summary>
        public string TimeEnd { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 內容(新)
        /// </summary>
        public string ContentBody { get; set; }
        /// <summary>
        /// 上/下架(新)
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 前台是否顯示問題
        /// </summary>
        public int HasTail { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 更新人員
        /// </summary>
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public Pilates_Info()
        {
        }
        #endregion
    }

    public class Pilates_Filter
    {
        public int? PilatesId { get; set; }
        public string RegID { get; set; }
        public string RegName { get; set; }
        public string RegSubject { get; set; }
        public DateTime? PublishDate { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Memo { get; set; }
        public string ContentBody { get; set; }
        public int? IsActive { get; set; }
        public int? HasTail { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above Pilates_Info field for search criteria
    }
    #endregion
}