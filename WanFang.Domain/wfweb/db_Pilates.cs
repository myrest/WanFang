using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface Idb_Pilates_Info
    {
        int PilatesId { get; set; }
        string RegNo { get; set; }
        string RegType { get; set; }
        string RegName { get; set; }
        DateTime RegDate { get; set; }
        string RegtimeStart { get; set; }
        string RegtimeEnd { get; set; }
        string Memo { get; set; }
        string Description { get; set; }
        int IsActive { get; set; }
        string Updator { get; set; }
        DateTime LastUpdate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Pilates")]
    [Rest.Core.PetaPoco.PrimaryKey("PilatesId")]
    public class db_Pilates_Info //: Idb_Pilates_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int PilatesId { get; set; }
        /// <summary>
        /// 課程代號P:Pilates核心復健M:孕婦健康瑜珈班Q:肩頸上背疼痛復健班C:兒童背部運動及姿態矯正班O:有氧太P力
        /// </summary>
        public string RegNo { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string RegType { get; set; }
        /// <summary>
        /// 課程主題
        /// </summary>
        public string RegName { get; set; }
        /// <summary>
        /// 開課日期
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 上課開始時間
        /// </summary>
        public string RegtimeStart { get; set; }
        /// <summary>
        /// 上課結束時間
        /// </summary>
        public string RegtimeEnd { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public string Updator { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructor
        public db_Pilates_Info()
        {
        }
        #endregion
    }

    public class db_Pilates_Filter
    {
        public int? PilatesId { get; set; }
        public string RegNo { get; set; }
        public string RegType { get; set; }
        public string RegName { get; set; }
        public DateTime? RegDate { get; set; }
        public string RegtimeStart { get; set; }
        public string RegtimeEnd { get; set; }
        public string Memo { get; set; }
        public string Description { get; set; }
        public int? IsActive { get; set; }
        public string Updator { get; set; }
        public DateTime? LastUpdate { get; set; }
        //You can copy/modify above db_Pilates_Info field for search criteria
    }
    #endregion
}