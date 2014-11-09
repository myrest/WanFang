using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IQuestion_Info
    {
        int QuestionId { get; set; }
        DateTime Q_time { get; set; }
        string Q_type { get; set; }
        string Q_object { get; set; }
        string Q_title { get; set; }
        string Q_question { get; set; }
        string Q_ans { get; set; }
        string Q_edit { get; set; }
        int hit { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Question")]
    [Rest.Core.PetaPoco.PrimaryKey("QuestionId")]
    public class Question_Info //: IQuestion_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// 發佈日期(原提單時間)
        /// </summary>
        public DateTime Q_time { get; set; }
        /// <summary>
        /// 諮詢類別(原提單類型)
        /// </summary>
        public string Q_type { get; set; }
        /// <summary>
        /// 科別(原相關科別)
        /// </summary>
        public string Q_object { get; set; }
        /// <summary>
        /// 提問標題
        /// </summary>
        public string Q_title { get; set; }
        /// <summary>
        /// 問題內容(原提問問題)
        /// </summary>
        public string Q_question { get; set; }
        /// <summary>
        /// 回覆內容
        /// </summary>
        public string Q_ans { get; set; }
        /// <summary>
        /// 回覆者(置於敬答前)
        /// </summary>
        public string Q_edit { get; set; }
        /// <summary>
        /// 點閱數(不顯示前台)
        /// </summary>
        public int hit { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Question_Info()
        {
        }
        #endregion
    }

    public class Question_Filter
    {
        public int? QuestionId { get; set; }
        public DateTime? Q_time { get; set; }
        public string Q_type { get; set; }
        public string Q_object { get; set; }
        public string Q_title { get; set; }
        public string Q_question { get; set; }
        public string Q_ans { get; set; }
        public string Q_edit { get; set; }
        public int? hit { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Question_Info field for search criteria
    }
    #endregion
}