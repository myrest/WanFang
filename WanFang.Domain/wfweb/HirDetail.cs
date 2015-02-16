using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IHirDetail_Info
    {
        int HirDetailId { get; set; }
        int HirCategoryId { get; set; }
        string HirName { get; set; }
        string Dept { get; set; }
        string DeptName { get; set; }
        string CostName { get; set; }
        string JobTitle { get; set; }
        int Nums { get; set; }
        string SchoolLimit { get; set; }
        string Condition { get; set; }
        DateTime PublishDate { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_HirDetail")]
    [Rest.Core.PetaPoco.PrimaryKey("HirDetailId")]
    public class HirDetail_Info //: IHirDetail_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int HirDetailId { get; set; }
        /// <summary>
        /// 職缺類別代號
        /// </summary>
        public int HirCategoryId { get; set; }
        /// <summary>
        /// 職缺類別
        /// </summary>
        public string HirName { get; set; }
        /// <summary>
        /// 診別代碼
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 診別
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 職缺單位(職缺科別改名稱)
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 職缺名稱
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 職缺數量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 學歷限制
        /// </summary>
        public string SchoolLimit { get; set; }
        /// <summary>
        /// 其他條件
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 發佈狀態:1.有效2.無效關閉此職缺
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        /// <summary>
        /// 審核時間
        /// </summary>
        public DateTime VerifiedDate { get; set; }
        #endregion

        #region Constructor
        public HirDetail_Info()
        {
        }
        #endregion
    }

    public class HirDetail_Filter
    {
        public int? HirDetailId { get; set; }
        public int? HirCategoryId { get; set; }
        public string HirName { get; set; }
        public string Dept { get; set; }
        public string DeptName { get; set; }
        public string CostName { get; set; }
        public string JobTitle { get; set; }
        public int? Nums { get; set; }
        public string SchoolLimit { get; set; }
        public string Condition { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above HirDetail_Info field for search criteria
    }
    #endregion
}