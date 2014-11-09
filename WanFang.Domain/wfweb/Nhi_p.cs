using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface INhi_p_Info
    {
        int nhi_pId { get; set; }
        DateTime nhi_date { get; set; }
        string nhi_code { get; set; }
        string nhi_type { get; set; }
        string nhi_cname { get; set; }
        string nhi_ename { get; set; }
        string fee_code { get; set; }
        string HealthCode { get; set; }
        string mark_name { get; set; }
        string unit { get; set; }
        string nhi_cost { get; set; }
        string self_cost { get; set; }
        string price_dif { get; set; }
        int hit { get; set; }
        string warnings { get; set; }
        string contrain { get; set; }
        string sideffect { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Nhi_p")]
    [Rest.Core.PetaPoco.PrimaryKey("nhi_pId")]
    public class Nhi_p_Info //: INhi_p_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int nhi_pId { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime nhi_date { get; set; }
        /// <summary>
        ///  特材類型
        /// </summary>
        public string nhi_code { get; set; }
        /// <summary>
        /// 品項名稱
        /// </summary>
        public string nhi_type { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public string nhi_cname { get; set; }
        /// <summary>
        /// 英文品名 / 許可證號
        /// </summary>
        public string nhi_ename { get; set; }
        /// <summary>
        /// 院內代碼
        /// </summary>
        public string fee_code { get; set; }
        /// <summary>
        /// 健保代碼(新)
        /// </summary>
        public string HealthCode { get; set; }
        /// <summary>
        /// 品項代碼 / 廠牌名稱
        /// </summary>
        public string mark_name { get; set; }
        /// <summary>
        /// 計價單位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 健保金額
        /// </summary>
        public string nhi_cost { get; set; }
        /// <summary>
        /// 自費金額
        /// </summary>
        public string self_cost { get; set; }
        /// <summary>
        /// 自費差額
        /// </summary>
        public string price_dif { get; set; }
        /// <summary>
        /// 點閱數
        /// </summary>
        public int hit { get; set; }
        /// <summary>
        /// 警語
        /// </summary>
        public string warnings { get; set; }
        /// <summary>
        /// 禁忌症
        /// </summary>
        public string contrain { get; set; }
        /// <summary>
        /// 副作用
        /// </summary>
        public string sideffect { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Nhi_p_Info()
        {
        }
        #endregion
    }

    public class Nhi_p_Filter
    {
        public int? nhi_pId { get; set; }
        public DateTime? nhi_date { get; set; }
        public string nhi_code { get; set; }
        public string nhi_type { get; set; }
        public string nhi_cname { get; set; }
        public string nhi_ename { get; set; }
        public string fee_code { get; set; }
        public string HealthCode { get; set; }
        public string mark_name { get; set; }
        public string unit { get; set; }
        public string nhi_cost { get; set; }
        public string self_cost { get; set; }
        public string price_dif { get; set; }
        public int? hit { get; set; }
        public string warnings { get; set; }
        public string contrain { get; set; }
        public string sideffect { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Nhi_p_Info field for search criteria
    }
    #endregion
}