using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IOp_Qa_Info
    {
        int Op_QaId { get; set; }
        string op_type { get; set; }
        string op_title { get; set; }
        string Description { get; set; }
        string op_content { get; set; }
        int hit { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        DateTime VerifiedDate { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Op_Qa")]
    [Rest.Core.PetaPoco.PrimaryKey("Op_QaId")]
    public class Op_Qa_Info //: IOp_Qa_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int Op_QaId { get; set; }
        /// <summary>
        /// 類別名稱
        /// </summary>
        public string op_type { get; set; }
        /// <summary>
        /// 問題標題
        /// </summary>
        public string op_title { get; set; }
        /// <summary>
        /// 清單頁簡述(新)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 回覆內容
        /// </summary>
        public string op_content { get; set; }
        /// <summary>
        /// 點閱數
        /// </summary>
        public int hit { get; set; }
        /// <summary>
        /// 上下架
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
        public Op_Qa_Info()
        {
        }
        #endregion
    }

    public class Op_Qa_Filter
    {
        public int? Op_QaId { get; set; }
        public string op_type { get; set; }
        public string op_title { get; set; }
        public string Description { get; set; }
        public string op_content { get; set; }
        public int? hit { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public DateTime? VerifiedDate { get; set; }
        //You can copy/modify above Op_Qa_Info field for search criteria
    }
    #endregion
}