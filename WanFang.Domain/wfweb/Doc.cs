using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IDoc_Info
    {
        int DocId { get; set; }
        string CostName { get; set; }
        string DeptName { get; set; }
        string Dept { get; set; }
        string DocCode { get; set; }
        string DocName { get; set; }
        string DocNameE { get; set; }
        string MainMajor1 { get; set; }
        string MainMajor2 { get; set; }
        string MainMajor3 { get; set; }
        string MainMajor4 { get; set; }
        string MainMajor5 { get; set; }
        string smain { get; set; }
        string school { get; set; }
        string career { get; set; }
        string sci { get; set; }
        int webtype { get; set; }
        string web { get; set; }
        string webcontent { get; set; }
        string otime { get; set; }
        int status { get; set; }
        string pic { get; set; }
        int seq_id { get; set; }
        string slic { get; set; }
        string Association { get; set; }
        string steach { get; set; }
        string learn { get; set; }
        int conf_flag { get; set; }
        DateTime conf_date { get; set; }
        string ncareer { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Doc")]
    [Rest.Core.PetaPoco.PrimaryKey("DocId")]
    public class Doc_Info //: IDoc_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int DocId { get; set; }
        /// <summary>
        /// 門診類別
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 科別中文名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 科別中文代號(舊系統保留)
        /// </summary>
        public string Dept { get; set; }
        /// <summary>
        /// 醫師員編
        /// </summary>
        public string DocCode { get; set; }
        /// <summary>
        /// 醫師中文名字
        /// </summary>
        public string DocName { get; set; }
        /// <summary>
        /// 醫師英文名字
        /// </summary>
        public string DocNameE { get; set; }
        /// <summary>
        /// 主治項目-上方1
        /// </summary>
        public string MainMajor1 { get; set; }
        /// <summary>
        /// 主治項目-上方2
        /// </summary>
        public string MainMajor2 { get; set; }
        /// <summary>
        /// 主治項目-上方3
        /// </summary>
        public string MainMajor3 { get; set; }
        /// <summary>
        /// 主治項目-上方4
        /// </summary>
        public string MainMajor4 { get; set; }
        /// <summary>
        /// 主治項目-上方5
        /// </summary>
        public string MainMajor5 { get; set; }
        /// <summary>
        /// 主治項目介紹(原主治項目)(出現於清單頁名稱下方簡介)
        /// </summary>
        public string smain { get; set; }
        /// <summary>
        /// 學歷
        /// </summary>
        public string school { get; set; }
        /// <summary>
        /// 經歷
        /// </summary>
        public string career { get; set; }
        /// <summary>
        /// 醫師著作
        /// </summary>
        public string sci { get; set; }
        /// <summary>
        /// 連絡方式-種類,0連結,1內容
        /// </summary>
        public int webtype { get; set; }
        /// <summary>
        /// 連絡方式-連結
        /// </summary>
        public string web { get; set; }
        /// <summary>
        /// 聯絡方式-內容
        /// </summary>
        public string webcontent { get; set; }
        /// <summary>
        /// 門診時段
        /// </summary>
        public string otime { get; set; }
        /// <summary>
        /// 狀態:1.在職0.離職(未顯示於前台)
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 醫師照片上傳
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 醫師排序
        /// </summary>
        public int seq_id { get; set; }
        /// <summary>
        /// 專科證書
        /// </summary>
        public string slic { get; set; }
        /// <summary>
        /// 專科學會
        /// </summary>
        public string Association { get; set; }
        /// <summary>
        /// 教職
        /// </summary>
        public string steach { get; set; }
        /// <summary>
        /// 進修
        /// </summary>
        public string learn { get; set; }
        /// <summary>
        /// 人資核定狀態:1.核定發布0.尚未核准
        /// </summary>
        public int conf_flag { get; set; }
        /// <summary>
        /// 核定日期
        /// </summary>
        public DateTime? conf_date { get; set; }
        /// <summary>
        /// 現職
        /// </summary>
        public string ncareer { get; set; }
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Doc_Info()
        {
        }
        #endregion
    }

    public class Doc_Filter
    {
        public int? DocId { get; set; }
        public string CostName { get; set; }
        public string DeptName { get; set; }
        public string Dept { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public string DocNameE { get; set; }
        public string MainMajor1 { get; set; }
        public string MainMajor2 { get; set; }
        public string MainMajor3 { get; set; }
        public string MainMajor4 { get; set; }
        public string MainMajor5 { get; set; }
        public string smain { get; set; }
        public string school { get; set; }
        public string career { get; set; }
        public string sci { get; set; }
        public int? webtype { get; set; }
        public string web { get; set; }
        public string webcontent { get; set; }
        public string otime { get; set; }
        public int? status { get; set; }
        public string pic { get; set; }
        public int? seq_id { get; set; }
        public string slic { get; set; }
        public string Association { get; set; }
        public string steach { get; set; }
        public string learn { get; set; }
        public int? conf_flag { get; set; }
        public DateTime? conf_date { get; set; }
        public string ncareer { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Doc_Info field for search criteria
    }
    #endregion
}