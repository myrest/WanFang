using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ITeamIntroduce_Info
    {
        int TeamIntroduceId { get; set; }
        string DeptName { get; set; }
        string CostName { get; set; }
        string CostId { get; set; }
        string WebMenuCode { get; set; }
        string WebMenuName { get; set; }
        string ContentBody { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        string Image4 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_TeamIntroduce")]
    [Rest.Core.PetaPoco.PrimaryKey("TeamIntroduceId")]
    public class TeamIntroduce_Info //: ITeamIntroduce_Info
    {
        #region private fields
        /// <summary>
        /// 流水序號
        /// </summary>
        public int TeamIntroduceId { get; set; }
        /// <summary>
        /// 門診類別
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 科別中文名稱(新)
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 科別代號
        /// </summary>
        public string CostId { get; set; }
        /// <summary>
        /// 網頁選單代號
        /// </summary>
        public string WebMenuCode { get; set; }
        /// <summary>
        /// 網頁選單名稱ex:本科介紹
        /// </summary>
        public string WebMenuName { get; set; }
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
        /// 狀態
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public TeamIntroduce_Info()
        {
        }
        #endregion
    }

    public class TeamIntroduce_Filter
    {
        public int? TeamIntroduceId { get; set; }
        public string DeptName { get; set; }
        public string CostName { get; set; }
        public string CostId { get; set; }
        public string WebMenuCode { get; set; }
        public string WebMenuName { get; set; }
        public string ContentBody { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above TeamIntroduce_Info field for search criteria
    }
    #endregion
}