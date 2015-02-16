using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IAboutTeam_Info
    {
        int AboutTeamId { get; set; }
        int SortNum { get; set; }
        string StrName { get; set; }
        string UserName { get; set; }
        string Introduction { get; set; }
        string Description { get; set; }
        string ContentBody { get; set; }
        string Photo1 { get; set; }
        string Photo2 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_AboutTeam")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutTeamId")]
    public class AboutTeam_Info //: IAboutTeam_Info
    {
        #region private fields
        public int AboutTeamId { get; set; }
        /// <summary>
        /// 順序(新)
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 職稱(新)
        /// </summary>
        public string StrName { get; set; }
        /// <summary>
        /// 姓名(新)
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 簡介(新)
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 簡述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 內容(新)
        /// </summary>
        public string ContentBody { get; set; }
        /// <summary>
        /// 清單圖片(新)
        /// </summary>
        public string Photo1 { get; set; }
        /// <summary>
        /// 圖片上ˋ傳(新)
        /// </summary>
        public string Photo2 { get; set; }
        /// <summary>
        /// 上/下架
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// 最後更新人員
        /// </summary>
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime? VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public AboutTeam_Info()
        {
        }
        #endregion
    }

    public class AboutTeam_Filter
    {
        public int? AboutTeamId { get; set; }
        public int? SortNum { get; set; }
        public string StrName { get; set; }
        public string UserName { get; set; }
        public string Introduction { get; set; }
        public string Description { get; set; }
        public string ContentBody { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above AboutTeam_Info field for search criteria
    }
    #endregion
}